using EventRegistration.Application.Ports;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Application.Services;
using EventRegistration.Domain.Entities;
using EventRegistration.Infrastructure.Email;
using EventRegistration.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// --- OpenAPI / Swagger (viene del template) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ============================================================================
// Wire up de puertos hexagonales
// ============================================================================

// Puertos secundarios / adapters de persistencia:
// Singleton porque el ConcurrentDictionary in-memory debe preservar estado
// entre requests. Con EF Core esto pasaría a Scoped.
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IEventRepository, InMemoryEventRepository>();
builder.Services.AddSingleton<IUserEventRepository, InMemoryUserEventRepository>();

// Puerto secundario / adapter de notificaciones:
// Scoped — el stub no tiene estado, pero un futuro SmtpClient real podría
// mantener conexión por request.
builder.Services.AddScoped<INotificationService, SmtpNotificationService>();

// Puertos primarios / servicios de Application:
// Scoped — una instancia por request HTTP.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IInvitationService, InvitationService>();

var app = builder.Build();

// --- Pipeline HTTP ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ============================================================================
// Middleware de manejo de excepciones de negocio
// ============================================================================
// InvalidOperationException  → 400 BadRequest  (violación de reglas de dominio)
// UnauthorizedAccessException → 403 Forbidden   (permisos insuficientes)
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (UnauthorizedAccessException ex) when (!context.Response.HasStarted)
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsJsonAsync(new { error = ex.Message });
    }
    catch (InvalidOperationException ex) when (!context.Response.HasStarted)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new { error = ex.Message });
    }
});

// ============================================================================
// Endpoints — /api/users
// ============================================================================
var users = app.MapGroup("/api/users").WithTags("Users");

users.MapPost("", async (RegisterUserRequest req, IUserService svc) =>
{
    User user = await svc.RegisterAsync(
        req.Username, req.Email, req.Password, req.FullName,
        req.Age, req.CountryOfResidence, req.PhoneNumber);
    return Results.Created($"/api/users/{user.Id}", user);
});

users.MapPost("/auth", async (LoginRequest req, IUserService svc) =>
{
    Session session = await svc.AuthenticateAsync(req.Username, req.Password);
    return Results.Ok(session);
});

users.MapGet("", async (IUserService svc) => Results.Ok(await svc.ListAllAsync()));

users.MapGet("/{id:guid}", async (Guid id, IUserService svc) =>
{
    User? user = await svc.GetByIdAsync(id);
    return user is null ? Results.NotFound() : Results.Ok(user);
});

users.MapPut("/{id:guid}", async (Guid id, UpdateUserRequest req, IUserService svc) =>
{
    User user = await svc.UpdateAsync(id, req);
    return Results.Ok(user);
});

users.MapDelete("/{id:guid}", async (Guid id, IUserService svc) =>
{
    await svc.DeleteAsync(id);
    return Results.NoContent();
});

// ============================================================================
// Endpoints — /api/events
// ============================================================================
var events = app.MapGroup("/api/events").WithTags("Events");

events.MapPost("", async (HttpContext ctx, CreateEventRequest req, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    Event evt = await svc.CreateEventAsync(currentUserId, req.Title, req.Description, req.Date);
    return Results.Created($"/api/events/{evt.Id}", evt);
});

events.MapGet("", async (IEventService svc) => Results.Ok(await svc.ListAllEventsAsync()));

events.MapGet("/{id:guid}/organizer", async (Guid id, HttpContext ctx, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    EventWithAttendees? view = await svc.GetEventDetailForOrganizerAsync(id, currentUserId);
    return view is null ? Results.NotFound() : Results.Ok(view);
});

events.MapGet("/{id:guid}/attendee", async (Guid id, HttpContext ctx, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    EventBasicView? view = await svc.GetEventDetailForAttendeeAsync(id, currentUserId);
    return view is null ? Results.NotFound() : Results.Ok(view);
});

events.MapPut("/{id:guid}", async (Guid id, HttpContext ctx, UpdateEventRequest req, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    Event evt = await svc.UpdateEventAsync(id, req, currentUserId);
    return Results.Ok(evt);
});

events.MapDelete("/{id:guid}", async (Guid id, HttpContext ctx, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    await svc.DeleteEventAsync(id, currentUserId);
    return Results.NoContent();
});

events.MapGet("/created-by/{userId:guid}", async (Guid userId, IEventService svc) =>
    Results.Ok(await svc.ListEventsCreatedByAsync(userId)));

events.MapGet("/accepted-by/{userId:guid}", async (Guid userId, IEventService svc) =>
    Results.Ok(await svc.ListEventsAcceptedByAsync(userId)));

events.MapGet("/{id:guid}/meet-link", async (Guid id, HttpContext ctx, IEventService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    string link = await svc.GetGoogleMeetLinkAsync(id, currentUserId);
    return Results.Ok(new { link });
});

// ============================================================================
// Endpoints — /api/events/{id}/invitations
// ============================================================================
events.MapPost("/{id:guid}/invitations", async (Guid id, HttpContext ctx, InviteRequest req, IInvitationService svc) =>
{
    Guid organizerId = RequireUserId(ctx);
    IReadOnlyList<UserEvent> created = await svc.InviteAttendeesAsync(id, req.UserIds, organizerId);
    return Results.Ok(created);
});

events.MapGet("/{id:guid}/invitations", async (Guid id, HttpContext ctx, IInvitationService svc) =>
{
    Guid organizerId = RequireUserId(ctx);
    IReadOnlyList<UserEvent> attendees = await svc.ListAttendeesForEventAsync(id, organizerId);
    return Results.Ok(attendees);
});

// ============================================================================
// Endpoints — /api/invitations
// ============================================================================
var invitations = app.MapGroup("/api/invitations").WithTags("Invitations");

invitations.MapGet("/user/{userId:guid}", async (Guid userId, IInvitationService svc) =>
    Results.Ok(await svc.ListInvitationsForUserAsync(userId)));

invitations.MapPost("/{id:guid}/accept", async (Guid id, HttpContext ctx, IInvitationService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    UserEvent updated = await svc.AcceptInvitationAsync(id, currentUserId);
    return Results.Ok(updated);
});

invitations.MapPost("/{id:guid}/reject", async (Guid id, HttpContext ctx, IInvitationService svc) =>
{
    Guid currentUserId = RequireUserId(ctx);
    UserEvent updated = await svc.RejectInvitationAsync(id, currentUserId);
    return Results.Ok(updated);
});

app.Run();

// ============================================================================
// Helper de autenticación stub
// ============================================================================
// El header X-User-Id identifica al usuario autenticado.
// En producción esto se reemplaza por JWT/cookies validados por middleware.
static Guid RequireUserId(HttpContext ctx)
{
    if (!ctx.Request.Headers.TryGetValue("X-User-Id", out var value) ||
        !Guid.TryParse(value, out Guid userId))
    {
        throw new UnauthorizedAccessException(
            "Falta o es inválido el header X-User-Id. Ejemplo: X-User-Id: 11111111-1111-1111-1111-111111111111");
    }
    return userId;
}

// ============================================================================
// DTOs de request — inline en Program.cs por ahora.
// Si crecen, se extraen a EventRegistration.Web/Contracts/.
// ============================================================================
record RegisterUserRequest(
    string Username,
    string Email,
    string Password,
    string FullName,
    int Age,
    string CountryOfResidence,
    string PhoneNumber);

record LoginRequest(string Username, string Password);

record CreateEventRequest(string Title, string? Description, DateTimeOffset Date);

record InviteRequest(IEnumerable<Guid> UserIds);
