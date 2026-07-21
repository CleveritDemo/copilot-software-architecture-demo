using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Ports;

public interface IUserService
{
    Task<User> RegisterAsync(
        string username,
        string email,
        string password,
        string fullName,
        int age,
        string countryOfResidence,
        string phoneNumber);

    Task<Session> AuthenticateAsync(string username, string password);

    Task<User?> GetByIdAsync(Guid userId);

    Task<User> UpdateAsync(Guid userId, UpdateUserRequest updatedFields);

    Task DeleteAsync(Guid userId);

    Task<IReadOnlyList<User>> ListAllAsync();

    Task<User> CreateByAdminAsync(
        string username,
        string email,
        string password,
        string fullName,
        int age,
        string countryOfResidence,
        string phoneNumber);
}

public record Session(Guid UserId, UserRole Role);

public record UpdateUserRequest(
    string? Username = null,
    string? Email = null,
    string? Password = null,
    string? FullName = null,
    int? Age = null,
    string? CountryOfResidence = null,
    string? PhoneNumber = null);
