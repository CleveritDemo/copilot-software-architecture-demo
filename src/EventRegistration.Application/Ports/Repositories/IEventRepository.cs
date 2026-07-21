using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports.Repositories;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid eventId);

    Task<IReadOnlyList<Event>> GetByCreatorAsync(Guid creatorUserId);

    Task<IReadOnlyList<Event>> GetAllAsync();

    Task<bool> HasActiveByCreatorAsync(Guid creatorUserId);

    Task AddAsync(Event @event);

    Task UpdateAsync(Event @event);

    Task DeleteAsync(Guid eventId);
}
