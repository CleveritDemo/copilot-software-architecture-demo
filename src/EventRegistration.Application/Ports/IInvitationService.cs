using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports;

public interface IInvitationService
{
    Task<IReadOnlyList<UserEvent>> InviteAttendeesAsync(
        Guid eventId,
        IEnumerable<Guid> userIds,
        Guid organizerId);

    Task<IReadOnlyList<UserEvent>> ListAttendeesForEventAsync(
        Guid eventId,
        Guid organizerId);

    Task<IReadOnlyList<UserEvent>> ListInvitationsForUserAsync(Guid userId);

    Task<UserEvent> AcceptInvitationAsync(Guid userEventId, Guid userId);

    Task<UserEvent> RejectInvitationAsync(Guid userEventId, Guid userId);

    Task<bool> HasAcceptedInvitationAsync(Guid eventId, Guid userId);

    Task DeleteInvitationsForEventAsync(Guid eventId);

    Task DeleteInvitationsForUserAsync(Guid userId);
}
