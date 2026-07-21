using EventRegistration.Application.Ports;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Services;

public sealed class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IInvitationService _invitationService;

    public EventService(
        IEventRepository eventRepository,
        IInvitationService invitationService)
    {
        _eventRepository = eventRepository;
        _invitationService = invitationService;
    }

    public Task<Event> CreateEventAsync(
        Guid creatorUserId,
        string title,
        string? description,
        DateTimeOffset date)
    {
        // TODO: validar que date sea futura (date > DateTimeOffset.UtcNow).
        // TODO: generar googleMeetLink (placeholder inicial: "https://meet.google.com/new").
        // TODO: construir Event con Id = Guid.NewGuid(), state = EventState.Active, creatorUserId.
        // TODO: persistir vía _eventRepository.AddAsync y retornar el Event creado.
        throw new NotImplementedException();
    }

    public async Task<Event> UpdateEventAsync(
        Guid eventId,
        UpdateEventRequest updatedFields,
        Guid currentUserId)
    {
        Event? existing = await _eventRepository.GetByIdAsync(eventId);
        if (existing is null)
        {
            throw new InvalidOperationException($"Event {eventId} no existe.");
        }

        // Guard clause: Regla 5 — solo el creador puede modificar el evento.
        // NOTA: el rol Administrator puede modificar cualquier evento, pero esa
        // autorización se resuelve en la capa Web mediante un endpoint separado o
        // un short-circuit del guard antes de invocar este método.
        if (existing.CreatorUserId != currentUserId)
        {
            throw new UnauthorizedAccessException(
                "Solo el creador del evento puede modificarlo (Regla 5).");
        }

        // TODO: aplicar updatedFields (partial merge sobre 'existing').
        // TODO: validar formato de los campos modificados.
        // TODO: persistir vía _eventRepository.UpdateAsync y retornar el Event actualizado.
        throw new NotImplementedException();
    }

    public async Task DeleteEventAsync(Guid eventId, Guid currentUserId)
    {
        Event? existing = await _eventRepository.GetByIdAsync(eventId);
        if (existing is null)
        {
            throw new InvalidOperationException($"Event {eventId} no existe.");
        }

        // Guard clause: Regla 5 (misma nota que UpdateEventAsync sobre el rol Administrator).
        if (existing.CreatorUserId != currentUserId)
        {
            throw new UnauthorizedAccessException(
                "Solo el creador del evento puede eliminarlo (Regla 5).");
        }

        // Cascade: eliminar todas las filas UserEvent asociadas al evento.
        await _invitationService.DeleteInvitationsForEventAsync(eventId);

        // Persistir eliminación del Event.
        await _eventRepository.DeleteAsync(eventId);
    }

    public Task<EventWithAttendees?> GetEventDetailForOrganizerAsync(Guid eventId, Guid organizerId)
    {
        // TODO: recuperar Event, validar que organizerId sea el creador.
        // TODO: obtener lista de asistentes vía _invitationService.ListAttendeesForEventAsync (Regla 11).
        // TODO: retornar EventWithAttendees con Event + asistentes.
        throw new NotImplementedException();
    }

    public Task<EventBasicView?> GetEventDetailForAttendeeAsync(Guid eventId, Guid attendeeUserId)
    {
        // TODO: validar acceso vía _invitationService.HasAcceptedInvitationAsync.
        // TODO: recuperar Event y mapear a EventBasicView (SIN listado de asistentes, Regla 12).
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Event>> ListEventsCreatedByAsync(Guid userId)
    {
        return await _eventRepository.GetByCreatorAsync(userId);
    }

    public Task<IReadOnlyList<Event>> ListEventsAcceptedByAsync(Guid userId)
    {
        // TODO: obtener UserEvents con userId + status = Accepted (vía _invitationService).
        // TODO: hidratar los Events correspondientes vía _eventRepository.GetByIdAsync por cada uno.
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Event>> ListAllEventsAsync()
    {
        // NOTA: la restricción de rol Administrator (Regla 8) se valida en la capa Web.
        return await _eventRepository.GetAllAsync();
    }

    public Task<string> GetGoogleMeetLinkAsync(Guid eventId, Guid currentUserId)
    {
        // TODO: validar acceso — currentUserId es el creador O tiene invitación aceptada.
        // TODO: validar que event.State == EventState.Active.
        // TODO: retornar event.GoogleMeetLink.
        throw new NotImplementedException();
    }

    public async Task<bool> HasActiveEventsAsOrganizerAsync(Guid userId)
    {
        return await _eventRepository.HasActiveByCreatorAsync(userId);
    }
}
