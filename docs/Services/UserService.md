# UserService

## Descripción

`UserService` es el servicio de dominio responsable de todo el ciclo de vida
de la entidad [`User`](../Entities/User.md): registro público, autenticación
de ambos roles (`común` y `administrador`), gestión de datos de cuenta,
eliminación de cuenta (con validación de la Regla 13), y operaciones
administrativas de CRUD sobre usuarios ejercidas por el `Usuario
Administrador`. Es el único servicio que persiste y modifica la entidad
`User`.

## Entidades involucradas

- [`User`](../Entities/User.md) — entidad principal, gestionada de extremo a
  extremo por este servicio.

## Casos de uso orquestados

### Usuario Común

- [Registrarse en la aplicación](../UseCases/CommonUserUseCases.md)
- [Iniciar sesión](../UseCases/CommonUserUseCases.md)
- [Gestionar cuenta](../UseCases/CommonUserUseCases.md)
- [Eliminar cuenta](../UseCases/CommonUserUseCases.md)

### Usuario Administrador

- [Iniciar sesión como administrador](../UseCases/AdminUserUseCases.md)
- [Ver listado de todos los usuarios](../UseCases/AdminUserUseCases.md)
- [Agregar usuario](../UseCases/AdminUserUseCases.md)
- [Modificar usuario](../UseCases/AdminUserUseCases.md)
- [Eliminar usuario](../UseCases/AdminUserUseCases.md)

## Operaciones

- `Register(username, email, password, fullName, age, countryOfResidence, phoneNumber) → User`
  — Crea un nuevo `User` con `role = común`, valida unicidad y cifra la
  contraseña. Cubre "Registrarse en la aplicación".

- `Authenticate(username, password) → Session`
  — Valida credenciales contra un `User` registrado o contra el administrador
  integrado por defecto (`admin`/`admin123`). Retorna una sesión con el rol
  correspondiente. Cubre "Iniciar sesión" y "Iniciar sesión como
  administrador".

- `GetById(userId) → User`
  — Recupera un `User` por su identificador. Usado por otros servicios y por
  el módulo de cuenta.

- `Update(userId, updatedFields) → User`
  — Actualiza los campos indicados del `User`, validando unicidad si cambian
  `username` o `email` y cifrando la contraseña si fue modificada. Cubre
  "Gestionar cuenta" y "Modificar usuario".

- `Delete(userId) → void`
  — Elimina el `User`. Antes de eliminar consulta
  `EventService.HasActiveEventsAsOrganizer(userId)` para hacer cumplir la
  Regla 13. Cubre "Eliminar cuenta" y "Eliminar usuario" (para admin, con
  posibilidad de cascada explícita).

- `ListAll() → List<User>`
  — Retorna todos los usuarios del sistema. Restringido al rol
  `administrador`. Cubre "Ver listado de todos los usuarios".

- `CreateByAdmin(newUserData) → User`
  — Crea un `User` con `role = común` sin pasar por el flujo público de
  registro. Cubre "Agregar usuario".

## Servicios colaboradores

- [`EventService`](EventService.md) — consulta
  `HasActiveEventsAsOrganizer(userId)` antes de eliminar un `User` para
  hacer cumplir la Regla 13.
