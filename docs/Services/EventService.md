# EventService

## Descripción

`EventService` es el servicio de dominio responsable del ciclo de vida de
la entidad [`Event`](../Entities/Event.md): creación con generación
automática del `googleMeetLink`, modificación y eliminación (con las
restricciones de propiedad de la Regla 5), consultas diferenciadas según
el rol del solicitante (organizador, asistente, administrador), y
validación del acceso al enlace de Google Meet al momento de unirse al
evento. También expone la consulta de "eventos activos como organizador"
que `UserService` necesita para hacer cumplir la Regla 13.

## Entidades involucradas

- [`Event`](../Entities/Event.md) — entidad principal, gestionada de extremo
  a extremo por este servicio.
- [`UserEvent`](../Entities/UserEvent.md) — consultada para listar eventos
  aceptados por un usuario y coordinada con `InvitationService` en la
  eliminación en cascada.

## Casos de uso orquestados

### Usuario Común

- [Crear evento](../UseCases/CommonUserUseCases.md)
- [Modificar evento](../UseCases/CommonUserUseCases.md)
- [Eliminar evento](../UseCases/CommonUserUseCases.md)
- [Ver detalle de evento propio](../UseCases/CommonUserUseCases.md)
- [Ver detalle de evento como asistente](../UseCases/CommonUserUseCases.md)
- [Unirse al evento](../UseCases/CommonUserUseCases.md)

### Usuario Administrador

- [Ver listado de todos los eventos](../UseCases/AdminUserUseCases.md)
- [Modificar cualquier evento](../UseCases/AdminUserUseCases.md)
- [Eliminar cualquier evento](../UseCases/AdminUserUseCases.md)

## Operaciones

- `CreateEvent(creatorUserId, title, description, date) → Event`
  — Crea un nuevo `Event` con `state = activo` y genera automáticamente el
  `googleMeetLink`. Cubre "Crear evento".

- `UpdateEvent(eventId, updatedFields, currentUserId) → Event`
  — Modifica el `Event` validando que `currentUserId` sea el creador
  (`Event.creatorUserId`) o tenga rol `administrador` (Regla 5). Cubre
  "Modificar evento" y "Modificar cualquier evento".

- `DeleteEvent(eventId, currentUserId) → void`
  — Elimina el `Event` validando la propiedad según la Regla 5, y coordina
  con `InvitationService.DeleteInvitationsForEvent(eventId)` para limpiar
  las filas `UserEvent` asociadas. Cubre "Eliminar evento" y "Eliminar
  cualquier evento".

- `GetEventDetailForOrganizer(eventId, organizerId) → EventWithAttendees`
  — Retorna la información completa del evento incluyendo el listado de
  asistentes (Regla 11). Cubre "Ver detalle de evento propio".

- `GetEventDetailForAttendee(eventId, attendeeUserId) → EventBasicView`
  — Retorna solo la información básica del evento (título, descripción,
  fecha, `googleMeetLink`), sin listado de asistentes (Regla 12). Delega
  la validación de acceso a
  `InvitationService.HasAcceptedInvitation(eventId, attendeeUserId)`.
  Cubre "Ver detalle de evento como asistente".

- `ListEventsCreatedBy(userId) → List<Event>`
  — Lista los eventos donde `userId = creatorUserId`. Usado por el módulo de
  contenido para mostrar "Mis eventos creados".

- `ListEventsAcceptedBy(userId) → List<Event>`
  — Lista los eventos donde el usuario tiene una `UserEvent` con `status =
  aceptado`. Usado por el módulo de contenido para mostrar "Mis eventos
  aceptados".

- `ListAllEvents() → List<Event>`
  — Retorna todos los eventos del sistema, sin filtrar. Restringido al rol
  `administrador` (Regla 8). Cubre "Ver listado de todos los eventos".

- `GetGoogleMeetLink(eventId, currentUserId) → string`
  — Retorna el enlace de Google Meet del evento en la fecha programada,
  validando que el `currentUserId` sea el creador o tenga una `UserEvent`
  con `status = aceptado`, y que `Event.state = activo`. Cubre "Unirse al
  evento".

- `HasActiveEventsAsOrganizer(userId) → bool`
  — Consulta booleana: retorna `true` si existe algún `Event` con
  `creatorUserId = userId` y `state = activo`. Es la operación que
  `UserService.Delete` invoca para hacer cumplir la Regla 13.

## Servicios colaboradores

- [`InvitationService`](InvitationService.md) — invocado para eliminar filas
  `UserEvent` cuando se elimina un `Event`, y consultado para validar
  acceso en "Ver detalle como asistente" y "Unirse al evento".
