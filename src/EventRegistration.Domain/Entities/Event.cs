namespace EventRegistration.Domain.Entities;

public enum EventState
{
    Active,
    Finished
}

public record Event(
    Guid Id,
    string Title,
    string? Description,
    DateTimeOffset Date,
    Guid CreatorUserId,
    EventState State,
    string GoogleMeetLink
);
