# UserEvent

## Descripción

La entidad `UserEvent` representa la relación muchos-a-muchos entre `User` y
`Event`. Cada instancia registra la participación de un usuario específico como
asistente en un evento específico, junto con el estado de su respuesta a la
invitación. Esta entidad reemplaza la noción de "asistente" como entidad
independiente: un usuario que asiste a un evento no es un tipo distinto de
usuario, sino un `User` vinculado a un `Event` mediante una fila en `UserEvent`.

## Atributos

| Atributo      | Tipo de Dato | Descripción                                                                     | Reglas de Negocio                                                                                          |
|---------------|--------------|---------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------|
| `userEventId` | `String`     | Identificador único de la relación entre un usuario y un evento.                | Debe ser único y no nulo. Generado por el sistema.                                                         |
| `userId`      | `String`     | Identificador del `User` invitado al evento.                                    | Debe referenciar un `userId` existente. La combinación (`userId`, `eventId`) debe ser única.               |
| `eventId`     | `String`     | Identificador del `Event` al que el usuario está invitado.                      | Debe referenciar un `eventId` existente. La combinación (`userId`, `eventId`) debe ser única.              |
| `status`      | `String`     | Estado de la respuesta del usuario a la invitación al evento.                   | Debe ser `aceptado` o `rechazado`. Se actualiza cuando el usuario responde desde el enlace de invitación.  |

## Relaciones

- Un `UserEvent` vincula un [`User`](User.md) con un [`Event`](Event.md).
- Un [`User`](User.md) puede tener múltiples entradas `UserEvent`, una por cada
  evento al que ha sido invitado.
- Un [`Event`](Event.md) puede tener múltiples entradas `UserEvent`, una por
  cada usuario invitado.
- Un [`User`](User.md) solo puede visualizar aquellos [`Event`](Event.md) para
  los cuales existe una entrada `UserEvent` que lo vincula (excepto los
  administradores, que ven todos los eventos).
