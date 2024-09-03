using System;
using System.Threading.Tasks;
using DummyEventApp.Core.Entities;
using DummyEventApp.Core.Interfaces;

namespace DummyEventApp.Core.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(string username, string email, string password)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username is required.", nameof(username));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email is required.", nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password is required.", nameof(password));

            // Check if user already exists
            var existingUser = await _userRepository.GetUserByEmail(email);
            if (existingUser != null)
                throw new InvalidOperationException("User with the same email already exists.");

            // Create a new user
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // Save the user to the repository
            await _userRepository.AddUser(user);

            return user;
        }
    }
}