using System.Collections.Concurrent;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Infrastructure.Persistence;

public sealed class InMemoryEventRepository : IEventRepository
{
    private readonly ConcurrentDictionary<Guid, Event> _store = new();

    public Task<Event?> GetByIdAsync(Guid eventId)
    {
        _store.TryGetValue(eventId, out Event? evt);
        return Task.FromResult(evt);
    }

    public Task<IReadOnlyList<Event>> GetByCreatorAsync(Guid creatorUserId)
    {
        IReadOnlyList<Event> list = _store.Values
            .Where(e => e.CreatorUserId == creatorUserId)
            .ToList();
        return Task.FromResult(list);
    }

    public Task<IReadOnlyList<Event>> GetAllAsync()
    {
        IReadOnlyList<Event> list = _store.Values.ToList();
        return Task.FromResult(list);
    }

    public Task<bool> HasActiveByCreatorAsync(Guid creatorUserId)
    {
        bool hasActive = _store.Values.Any(e =>
            e.CreatorUserId == creatorUserId && e.State == EventState.Active);
        return Task.FromResult(hasActive);
    }

    public Task AddAsync(Event @event)
    {
        _store[@event.Id] = @event;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Event @event)
    {
        _store[@event.Id] = @event;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid eventId)
    {
        _store.TryRemove(eventId, out _);
        return Task.CompletedTask;
    }
}
