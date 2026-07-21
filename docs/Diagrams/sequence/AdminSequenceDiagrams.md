# Diagramas de Secuencia — Usuario Administrador

Cada diagrama refleja el flujo paso a paso documentado en
[../../UseCases/AdminUserUseCases.md](../../UseCases/AdminUserUseCases.md),
usando los servicios definidos en [../../Services/](../../Services/) y las
entidades bajo [../../Entities/](../../Entities/).

---

## Iniciar sesión como administrador

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant UI as UI de Login
    participant US as UserService

    Admin ->> UI: Abre pantalla de login
    UI -->> Admin: Muestra formulario
    Admin ->> UI: Ingresa admin / admin123
    UI ->> US: Authenticate(username, password)
    US ->> US: Valida contra credenciales de administrador
    US -->> UI: Sesión (role = administrador)
    UI -->> Admin: Redirige al módulo de administración
    Note right of US: A1 · Credenciales inválidas → error, sin sesión
```

---

## Ver listado de todos los usuarios

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant US as UserService
    participant U as User

    Admin ->> US: ListAll()
    US ->> U: Query todos los registros
    U -->> US: List<User>
    US -->> Admin: Listado con username, email, rol
```

---

## Agregar usuario

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant US as UserService
    participant U as User

    Admin ->> US: CreateByAdmin(newUserData)
    US ->> US: Valida formato y unicidad
    US ->> U: Persist (role = común, contraseña cifrada)
    U -->> US: User creado
    US -->> Admin: User
    Note right of US: A1 · Username o email duplicado → error, no persiste
```

---

## Modificar usuario

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant US as UserService
    participant U as User

    Admin ->> US: GetById(userId)
    US ->> U: Query por ID
    U -->> US: User
    US -->> Admin: Datos actuales
    Admin ->> US: Update(userId, updatedFields)
    US ->> US: Valida formato y unicidad
    US ->> U: Persist changes
    U -->> US: User actualizado
    US -->> Admin: User
    Note right of US: A1 · Conflicto de unicidad → error
```

---

## Eliminar usuario

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant US as UserService
    participant ES as EventService
    participant IS as InvitationService
    participant U as User

    Admin ->> US: Delete(userId)
    US ->> ES: HasActiveEventsAsOrganizer(userId)
    ES -->> US: bool
    Note right of US: A1 · Si hay eventos activos → advertencia; admin puede forzar cascada
    US ->> IS: DeleteInvitationsForUser(userId)
    IS -->> US: void
    US ->> U: Delete record
    U -->> US: void
    US -->> Admin: Eliminación confirmada
```

---

## Ver listado de todos los eventos

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant ES as EventService
    participant E as Event

    Admin ->> ES: ListAllEvents()
    ES ->> E: Query todos los registros (Regla 8)
    E -->> ES: List<Event>
    ES -->> Admin: Listado con creador, fecha, estado, enlace
```

---

## Modificar cualquier evento

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant ES as EventService
    participant E as Event

    Admin ->> ES: GetById(eventId)
    ES ->> E: Query por ID
    E -->> ES: Event
    ES -->> Admin: Datos actuales
    Admin ->> ES: UpdateEvent(eventId, updatedFields, adminId)
    ES ->> ES: Valida rol administrador (Regla 5)
    ES ->> E: Persist changes
    E -->> ES: Event actualizado
    ES -->> Admin: Event
```

---

## Eliminar cualquier evento

```mermaid
sequenceDiagram
    actor Admin as Usuario Administrador
    participant ES as EventService
    participant IS as InvitationService
    participant E as Event

    Admin ->> ES: DeleteEvent(eventId, adminId)
    ES ->> ES: Valida rol administrador (Regla 5)
    ES ->> IS: DeleteInvitationsForEvent(eventId)
    IS -->> ES: void
    ES ->> E: Delete record
    E -->> ES: void
    ES -->> Admin: Eliminación confirmada
```
