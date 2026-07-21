using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports;

public interface INotificationService
{
    Task SendInvitationEmailAsync(
        string recipientEmail,
        Event @event,
        string responseLink);
}
