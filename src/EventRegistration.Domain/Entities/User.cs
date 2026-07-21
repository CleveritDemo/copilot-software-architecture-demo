namespace EventRegistration.Domain.Entities;

public enum UserRole
{
    Common,
    Administrator
}

public record User(
    Guid Id,
    string Username,
    string Email,
    string FullName,
    int Age,
    string CountryOfResidence,
    string PhoneNumber,
    string PasswordHash,
    UserRole Role
);
