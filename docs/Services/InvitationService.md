# InvitationService

## Descripción

`InvitationService` es el servicio de dominio responsable de la relación
muchos-a-muchos entre [`User`](../Entities/User.md) y
[`Event`](../Entities/Event.md), materializada a través de
[`UserEvent`](../Entities/UserEvent.md). Gestiona la creación de
invitaciones (con envío de correos delegado a `NotificationService`), las
respuestas del asistente (aceptar/rechazar), los listados de asistentes
para el organizador (Regla 11) y de invitaciones para el asistente, y la
validación de acceso que `EventService` necesita para diferenciar la vista
de organizador vs asistente.

## Entidades involucradas

- [`UserEvent`](../Entities/UserEvent.md) — entidad principal, gestionada de
  extremo a extremo por este servicio.
- [`User`](../Entities/User.md) — referenciada como destinatario de la
  invitación.
- [`Event`](../Entities/Event.md) — referenciada como contexto de la
  invitación.

## Casos de uso orquestados

- [Invitar asistentes](../UseCases/CommonUserUseCases.md)
- [Ver listado de asistentes](../UseCases/CommonUserUseCases.md)
- [Ver mis invitaciones](../UseCases/CommonUserUseCases.md)
- [Aceptar invitación](../UseCases/CommonUserUseCases.md)
- [Rechazar invitación](../UseCases/CommonUserUseCases.md)

## Operaciones

- `InviteAttendees(eventId, userIds, organizerId) → List<UserEvent>`
  — Crea una fila `UserEvent` por cada `userId` invitado, validando que
  `organizerId` sea el creador del evento y omitiendo duplicados. Por
  cada invitación creada, invoca
  `NotificationService.SendInvitationEmail(...)` con el correo del
  destinatario, los datos del evento y el enlace de respuesta.
  Cubre "Invitar asistentes".

- `ListAttendeesForEvent(eventId, organizerId) → List<UserEvent>`
  — Retorna todas las filas `UserEvent` asociadas al evento, con el
  `status` de respuesta de cada asistente. Restringido al organizador
  (Regla 11). Cubre "Ver listado de asistentes".

- `ListInvitationsForUser(userId) → List<UserEvent>`
  — Retorna todas las filas `UserEvent` donde `UserEvent.userId = userId`,
  con el estado de respuesta actual. Cubre "Ver mis invitaciones".

- `AcceptInvitation(userEventId, userId) → UserEvent`
  — Actualiza `UserEvent.status = aceptado`, validando que el
  `UserEvent.userId` coincida con el `userId` autenticado. Cubre "Aceptar
  invitación".

- `RejectInvitation(userEventId, userId) → UserEvent`
  — Actualiza `UserEvent.status = rechazado`, con la misma validación de
  propiedad. Cubre "Rechazar invitación".

- `HasAcceptedInvitation(eventId, userId) → bool`
  — Consulta booleana: retorna `true` si existe una fila `UserEvent` con
  `userId` y `eventId` dados y `status = aceptado`. Usada por
  `EventService` para validar acceso en "Ver detalle como asistente" y
  "Unirse al evento".

- `DeleteInvitationsForEvent(eventId) → void`
  — Elimina todas las filas `UserEvent` asociadas a un evento. Invocada por
  `EventService.DeleteEvent` para mantener integridad referencial.

- `DeleteInvitationsForUser(userId) → void`
  — Elimina todas las filas `UserEvent` asociadas a un usuario. Invocada
  por `UserService.Delete` para mantener integridad referencial.

## Servicios colaboradores

- [`NotificationService`](NotificationService.md) — invocado por
  `InviteAttendees` para enviar el correo de invitación a cada asistente.
