namespace EventRegistration.Domain.Entities;

public enum InvitationStatus
{
    Pending,
    Accepted,
    Rejected
}

public record UserEvent(
    Guid Id,
    Guid UserId,
    Guid EventId,
    InvitationStatus Status
);
