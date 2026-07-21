using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports.Repositories;

public interface IUserEventRepository
{
    Task<UserEvent?> GetByIdAsync(Guid userEventId);

    Task<UserEvent?> FindAsync(Guid userId, Guid eventId);

    Task<IReadOnlyList<UserEvent>> GetByEventIdAsync(Guid eventId);

    Task<IReadOnlyList<UserEvent>> GetByUserIdAsync(Guid userId);

    Task<bool> ExistsAsync(Guid userId, Guid eventId);

    Task AddAsync(UserEvent userEvent);

    Task UpdateAsync(UserEvent userEvent);

    Task DeleteAsync(Guid userEventId);

    Task DeleteByEventIdAsync(Guid eventId);

    Task DeleteByUserIdAsync(Guid userId);
}
