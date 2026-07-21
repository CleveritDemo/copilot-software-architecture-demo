# Event

## Descripción

La entidad `Event` representa un evento en línea registrado en el sistema. Cada
evento incluye la información necesaria para que sus asistentes puedan unirse en
la fecha programada: título, descripción, fecha, un enlace de sala de
videoconferencia de Google Meet generado automáticamente al momento del registro,
y el usuario creador. Un evento tiene dos estados: `activo` mientras aún no ha
ocurrido, y `finalizado` una vez que la fecha del evento ha pasado. La aplicación
no crea las salas de videoconferencia por sí misma — solo genera el enlace hacia
Google Meet.

## Atributos

| Atributo         | Tipo de Dato | Descripción                                                                       | Reglas de Negocio                                                                                                             |
|------------------|--------------|-----------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|
| `eventId`        | `String`     | Identificador único del evento.                                                   | Debe ser único y no nulo. Generado por el sistema en el momento de la creación.                                               |
| `title`          | `String`     | Título del evento.                                                                | Debe ser no nulo y no vacío.                                                                                                  |
| `description`    | `String`     | Descripción del evento.                                                           | Opcional.                                                                                                                     |
| `date`           | `Date`       | Fecha y hora en que ocurrirá el evento.                                           | Debe ser una fecha válida. Determina la transición del estado `activo` a `finalizado`.                                        |
| `creatorUserId`  | `String`     | Identificador del `User` que creó el evento.                                      | Debe referenciar un `userId` existente. Solo este usuario (o un administrador) puede modificar o eliminar el evento.          |
| `state`          | `String`     | Estado actual del evento.                                                         | Debe ser `activo` (evento aún no ocurrido) o `finalizado` (evento ya ocurrido).                                               |
| `googleMeetLink` | `String`     | Enlace URL hacia la sala de videoconferencia de Google Meet asociada al evento.   | Generado automáticamente al momento de crear el evento. Debe ser una URL válida.                                              |

## Relaciones

- Un `Event` es creado por exactamente un [`User`](User.md) (referenciado por
  `creatorUserId`).
- Un `Event` puede tener múltiples entradas [`UserEvent`](UserEvent.md), una por
  cada usuario invitado al evento.
- Solo el `User` creador del evento o un `User` con rol `administrador` pueden
  modificar o eliminar el evento.
- Un `Event` no puede ser visualizado por un `User` que no haya sido invitado, a
  menos que el usuario tenga rol `administrador`.
