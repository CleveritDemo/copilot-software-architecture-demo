using EventRegistration.Application.Ports;
using EventRegistration.Application.Ports.Repositories;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEventService _eventService;
    private readonly IInvitationService _invitationService;

    public UserService(
        IUserRepository userRepository,
        IEventService eventService,
        IInvitationService invitationService)
    {
        _userRepository = userRepository;
        _eventService = eventService;
        _invitationService = invitationService;
    }

    public Task<User> RegisterAsync(
        string username,
        string email,
        string password,
        string fullName,
        int age,
        string countryOfResidence,
        string phoneNumber)
    {
        // TODO: validar formato de email/username (regex o FluentValidation).
        // TODO: validar unicidad vía _userRepository.GetByUsernameAsync + GetByEmailAsync.
        // TODO: hashear contraseña con BCrypt.Net-Next antes de persistir.
        // TODO: construir User con Id = Guid.NewGuid() y Role = UserRole.Common.
        // TODO: persistir vía _userRepository.AddAsync y retornar el User creado.
        throw new NotImplementedException();
    }

    public Task<Session> AuthenticateAsync(string username, string password)
    {
        // TODO: si username == "admin" y password == "admin123", retornar Session con role = Administrator.
        // TODO: caso general — buscar User por username, verificar hash de contraseña, retornar Session.
        // TODO: si credenciales inválidas, lanzar UnauthorizedAccessException.
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public Task<User> UpdateAsync(Guid userId, UpdateUserRequest updatedFields)
    {
        // TODO: recuperar User existente vía _userRepository.GetByIdAsync (lanzar si no existe).
        // TODO: aplicar updatedFields solo para las propiedades no nulas (partial update).
        // TODO: validar unicidad si cambian email/username.
        // TODO: si updatedFields.Password no es null, hashear.
        // TODO: persistir vía _userRepository.UpdateAsync y retornar el User actualizado.
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid userId)
    {
        // Guard clause: Regla 13 — no eliminar cuenta con eventos activos como organizador.
        bool hasActiveEvents = await _eventService.HasActiveEventsAsOrganizerAsync(userId);
        if (hasActiveEvents)
        {
            throw new InvalidOperationException(
                "El usuario no puede ser eliminado porque es organizador de al menos un evento activo (Regla 13).");
        }

        // Cascade: eliminar todas las filas UserEvent asociadas al usuario.
        await _invitationService.DeleteInvitationsForUserAsync(userId);

        // Persistir eliminación del User.
        await _userRepository.DeleteAsync(userId);
    }

    public async Task<IReadOnlyList<User>> ListAllAsync()
    {
        // NOTA: la restricción de rol Administrator se valida en la capa Web.
        return await _userRepository.GetAllAsync();
    }

    public Task<User> CreateByAdminAsync(
        string username,
        string email,
        string password,
        string fullName,
        int age,
        string countryOfResidence,
        string phoneNumber)
    {
        // TODO: mismas validaciones que RegisterAsync (formato + unicidad + hash).
        // TODO: crear User con Role = UserRole.Common y persistir.
        //       Los usuarios administradores están integrados en el sistema, no se crean por esta vía.
        throw new NotImplementedException();
    }
}
