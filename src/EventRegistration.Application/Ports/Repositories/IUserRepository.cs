using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid userId);

    Task<User?> GetByUsernameAsync(string username);

    Task<User?> GetByEmailAsync(string email);

    Task<IReadOnlyList<User>> GetAllAsync();

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(Guid userId);
}
