using EventRegistration.Application.Ports;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Services;

public sealed class InvitationService : IInvitationService
{
    private readonly IUserEventRepository _userEventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEventRepository _eventRepository;
    private readonly INotificationService _notificationService;

    public InvitationService(
        IUserEventRepository userEventRepository,
        IUserRepository userRepository,
        IEventRepository eventRepository,
        INotificationService notificationService)
    {
        _userEventRepository = userEventRepository;
        _userRepository = userRepository;
        _eventRepository = eventRepository;
        _notificationService = notificationService;
    }

    public Task<IReadOnlyList<UserEvent>> InviteAttendeesAsync(
        Guid eventId,
        IEnumerable<Guid> userIds,
        Guid organizerId)
    {
        // TODO: recuperar Event vía _eventRepository.GetByIdAsync (lanzar si no existe).
        // TODO: validar que organizerId sea el creador del Event.
        // TODO: por cada userId en userIds:
        //         - omitir si ya existe UserEvent (ExistsAsync);
        //         - crear UserEvent con Id = Guid.NewGuid() y Status = InvitationStatus.Pending;
        //         - persistir vía _userEventRepository.AddAsync;
        //         - recuperar User destinatario vía _userRepository.GetByIdAsync para obtener el email;
        //         - invocar _notificationService.SendInvitationEmailAsync(email, event, responseLink).
        // TODO: retornar la lista de UserEvents creadas.
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<UserEvent>> ListAttendeesForEventAsync(Guid eventId, Guid organizerId)
    {
        // TODO: validar que organizerId sea el creador del Event (Regla 11).
        // TODO: retornar _userEventRepository.GetByEventIdAsync(eventId).
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<UserEvent>> ListInvitationsForUserAsync(Guid userId)
    {
        return await _userEventRepository.GetByUserIdAsync(userId);
    }

    public async Task<UserEvent> AcceptInvitationAsync(Guid userEventId, Guid userId)
    {
        UserEvent? invitation = await _userEventRepository.GetByIdAsync(userEventId);
        if (invitation is null)
        {
            throw new InvalidOperationException($"Invitación {userEventId} no existe.");
        }

        // Guard clause: solo el usuario destinatario puede aceptar su propia invitación.
        if (invitation.UserId != userId)
        {
            throw new UnauthorizedAccessException(
                "Solo el usuario destinatario puede aceptar esta invitación.");
        }

        // TODO: crear UserEvent actualizado con Status = InvitationStatus.Accepted
        //       (record 'with' expression) y persistir vía _userEventRepository.UpdateAsync.
        // TODO: retornar el UserEvent actualizado.
        throw new NotImplementedException();
    }

    public async Task<UserEvent> RejectInvitationAsync(Guid userEventId, Guid userId)
    {
        UserEvent? invitation = await _userEventRepository.GetByIdAsync(userEventId);
        if (invitation is null)
        {
            throw new InvalidOperationException($"Invitación {userEventId} no existe.");
        }

        // Guard clause: solo el usuario destinatario puede rechazar su propia invitación.
        if (invitation.UserId != userId)
        {
            throw new UnauthorizedAccessException(
                "Solo el usuario destinatario puede rechazar esta invitación.");
        }

        // TODO: crear UserEvent actualizado con Status = InvitationStatus.Rejected
        //       (record 'with' expression) y persistir vía _userEventRepository.UpdateAsync.
        // TODO: retornar el UserEvent actualizado.
        throw new NotImplementedException();
    }

    public async Task<bool> HasAcceptedInvitationAsync(Guid eventId, Guid userId)
    {
        UserEvent? invitation = await _userEventRepository.FindAsync(userId, eventId);
        return invitation is not null && invitation.Status == InvitationStatus.Accepted;
    }

    public async Task DeleteInvitationsForEventAsync(Guid eventId)
    {
        await _userEventRepository.DeleteByEventIdAsync(eventId);
    }

    public async Task DeleteInvitationsForUserAsync(Guid userId)
    {
        await _userEventRepository.DeleteByUserIdAsync(userId);
    }
}
