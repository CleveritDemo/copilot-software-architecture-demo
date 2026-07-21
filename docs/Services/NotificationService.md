# NotificationService

## Descripción

`NotificationService` es un servicio de **infraestructura** que encapsula
el envío de correos electrónicos. Aisla el proveedor concreto de correo
(SMTP, SendGrid, AWS SES, etc.) detrás de una interfaz simple, para que
el resto de servicios de dominio no dependan de esa elección técnica.

A diferencia del resto de servicios documentados, **no orquesta ningún
caso de uso end-to-end**: es invocado como subrutina por `InvitationService`
durante "Invitar asistentes", y no persiste ni modifica ninguna entidad.
Su inclusión como servicio propio se justifica por dos razones:

1. Permite probar `InvitationService` con un doble (fake/mock) de
   `NotificationService`, sin depender de un proveedor real.
2. Permite reemplazar el proveedor de correo sin tocar ningún servicio de
   dominio.

## Entidades involucradas

No persiste ni modifica ninguna entidad. Consume datos de solo lectura de:

- [`User`](../Entities/User.md) — para obtener el `email` del destinatario.
- [`Event`](../Entities/Event.md) — para el contenido del correo
  (título, descripción, fecha, `googleMeetLink`).

## Casos de uso orquestados

Ninguno directamente. Es soporte para el caso de uso
[Invitar asistentes](../UseCases/CommonUserUseCases.md), invocado desde
`InvitationService.InviteAttendees(...)`.

## Operaciones

- `SendInvitationEmail(recipientEmail, event, responseLink) → void`
  — Envía un correo electrónico al `recipientEmail` con la información del
  evento y un enlace hacia la aplicación donde el destinatario puede
  aceptar o rechazar la invitación. Es la única operación del servicio en
  el alcance actual.

## Servicios colaboradores

Ninguno. Es una hoja del grafo de dependencias entre servicios.
