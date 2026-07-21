using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports;

public interface IEventService
{
    Task<Event> CreateEventAsync(
        Guid creatorUserId,
        string title,
        string? description,
        DateTimeOffset date);

    Task<Event> UpdateEventAsync(
        Guid eventId,
        UpdateEventRequest updatedFields,
        Guid currentUserId);

    Task DeleteEventAsync(Guid eventId, Guid currentUserId);

    Task<EventWithAttendees?> GetEventDetailForOrganizerAsync(Guid eventId, Guid organizerId);

    Task<EventBasicView?> GetEventDetailForAttendeeAsync(Guid eventId, Guid attendeeUserId);

    Task<IReadOnlyList<Event>> ListEventsCreatedByAsync(Guid userId);

    Task<IReadOnlyList<Event>> ListEventsAcceptedByAsync(Guid userId);

    Task<IReadOnlyList<Event>> ListAllEventsAsync();

    Task<string> GetGoogleMeetLinkAsync(Guid eventId, Guid currentUserId);

    Task<bool> HasActiveEventsAsOrganizerAsync(Guid userId);
}

public record EventWithAttendees(Event Event, IReadOnlyList<UserEvent> Attendees);

public record EventBasicView(
    Guid Id,
    string Title,
    string? Description,
    DateTimeOffset Date,
    string GoogleMeetLink);

public record UpdateEventRequest(
    string? Title = null,
    string? Description = null,
    DateTimeOffset? Date = null);
