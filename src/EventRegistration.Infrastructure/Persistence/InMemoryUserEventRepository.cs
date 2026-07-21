using System.Collections.Concurrent;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Infrastructure.Persistence;

public sealed class InMemoryUserEventRepository : IUserEventRepository
{
    private readonly ConcurrentDictionary<Guid, UserEvent> _store = new();

    public Task<UserEvent?> GetByIdAsync(Guid userEventId)
    {
        _store.TryGetValue(userEventId, out UserEvent? ue);
        return Task.FromResult(ue);
    }

    public Task<UserEvent?> FindAsync(Guid userId, Guid eventId)
    {
        UserEvent? found = _store.Values
            .FirstOrDefault(ue => ue.UserId == userId && ue.EventId == eventId);
        return Task.FromResult(found);
    }

    public Task<IReadOnlyList<UserEvent>> GetByEventIdAsync(Guid eventId)
    {
        IReadOnlyList<UserEvent> list = _store.Values
            .Where(ue => ue.EventId == eventId)
            .ToList();
        return Task.FromResult(list);
    }

    public Task<IReadOnlyList<UserEvent>> GetByUserIdAsync(Guid userId)
    {
        IReadOnlyList<UserEvent> list = _store.Values
            .Where(ue => ue.UserId == userId)
            .ToList();
        return Task.FromResult(list);
    }

    public Task<bool> ExistsAsync(Guid userId, Guid eventId)
    {
        bool exists = _store.Values.Any(ue => ue.UserId == userId && ue.EventId == eventId);
        return Task.FromResult(exists);
    }

    public Task AddAsync(UserEvent userEvent)
    {
        _store[userEvent.Id] = userEvent;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(UserEvent userEvent)
    {
        _store[userEvent.Id] = userEvent;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid userEventId)
    {
        _store.TryRemove(userEventId, out _);
        return Task.CompletedTask;
    }

    public Task DeleteByEventIdAsync(Guid eventId)
    {
        List<Guid> toRemove = _store.Values
            .Where(ue => ue.EventId == eventId)
            .Select(ue => ue.Id)
            .ToList();

        foreach (Guid id in toRemove)
        {
            _store.TryRemove(id, out _);
        }

        return Task.CompletedTask;
    }

    public Task DeleteByUserIdAsync(Guid userId)
    {
        List<Guid> toRemove = _store.Values
            .Where(ue => ue.UserId == userId)
            .Select(ue => ue.Id)
            .ToList();

        foreach (Guid id in toRemove)
        {
            _store.TryRemove(id, out _);
        }

        return Task.CompletedTask;
    }
}
