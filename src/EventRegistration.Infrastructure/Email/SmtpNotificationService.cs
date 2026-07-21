using EventRegistration.Application.Ports;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Infrastructure.Email;

/// <summary>
/// Stub inicial de INotificationService. En esta iteración imprime el correo
/// por consola con formato estructurado, para permitir smoke tests sin
/// dependencias externas.
///
/// La implementación real vía SmtpClient (o SendGrid/AWS SES) se agregará
/// más adelante — el nombre "Smtp" refleja la intención arquitectural,
/// no el proveedor concreto usado en este stub.
/// </summary>
public sealed class SmtpNotificationService : INotificationService
{
    public Task SendInvitationEmailAsync(
        string recipientEmail,
        Event @event,
        string responseLink)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("[NotificationService] Sending invitation");
        Console.WriteLine($"  To:          {recipientEmail}");
        Console.WriteLine($"  Event:       {@event.Title} ({@event.Id})");
        Console.WriteLine($"  Date:        {@event.Date:yyyy-MM-dd HH:mm zzz}");
        Console.WriteLine($"  Meet link:   {@event.GoogleMeetLink}");
        Console.WriteLine($"  Response:    {responseLink}");
        Console.WriteLine("========================================");
        return Task.CompletedTask;
    }
}
