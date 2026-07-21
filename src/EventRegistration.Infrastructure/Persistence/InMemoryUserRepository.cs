using System.Collections.Concurrent;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Infrastructure.Persistence;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<Guid, User> _store = new();

    public Task<User?> GetByIdAsync(Guid userId)
    {
        _store.TryGetValue(userId, out User? user);
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? user = _store.Values.FirstOrDefault(u => u.Username == username);
        return Task.FromResult(user);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        User? user = _store.Values.FirstOrDefault(u => u.Email == email);
        return Task.FromResult(user);
    }

    public Task<IReadOnlyList<User>> GetAllAsync()
    {
        IReadOnlyList<User> list = _store.Values.ToList();
        return Task.FromResult(list);
    }

    public Task AddAsync(User user)
    {
        _store[user.Id] = user;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user)
    {
        _store[user.Id] = user;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid userId)
    {
        _store.TryRemove(userId, out _);
        return Task.CompletedTask;
    }
}
