# Usuario Común

## Descripción

El actor **Usuario Común** representa a un usuario final que se registra desde
la propia aplicación. Es el único tipo de actor que puede darse de alta a
través de la UI pública — los administradores están integrados en el sistema y
no se registran. Un mismo `Usuario Común` puede desempeñar dos roles
funcionales dentro del sistema, de forma simultánea y por evento:

- Como **organizador**, cuando figura como creador de un
  [`Event`](../Entities/Event.md) (regla derivada del atributo
  `creatorUserId`).
- Como **asistente**, cuando existe una fila en
  [`UserEvent`](../Entities/UserEvent.md) que lo vincula a un evento al que fue
  invitado.

Estos dos roles no son actores independientes: son comportamientos que emergen
de la relación entre `User`, `Event` y `UserEvent`.

## Responsabilidades

### Como usuario registrado

- Registrarse en la aplicación proporcionando la información requerida por su
  cuenta (username, email, nombre completo, edad, país de residencia,
  número de teléfono, contraseña).
- Autenticarse con sus credenciales para acceder a los módulos de contenido,
  evento y cuenta.
- Gestionar la información de su propia cuenta desde el módulo de cuenta.
- Eliminar su propia cuenta, respetando la restricción asociada a eventos
  activos que organiza.

### Como organizador

- Crear eventos, definiendo título, descripción y fecha. El sistema genera
  automáticamente el enlace de Google Meet asociado al evento.
- Modificar eventos que él mismo creó.
- Eliminar eventos que él mismo creó.
- Invitar a otros `Usuario Común` al evento (el sistema envía las invitaciones
  por correo electrónico a cada asistente).
- Ver el listado completo de asistentes de sus propios eventos, con el estado
  de respuesta de cada uno.

### Como asistente

- Recibir por correo electrónico las invitaciones a eventos a los que fue
  agregado.
- Aceptar o rechazar una invitación desde el enlace incluido en el correo.
- Ver la información básica de los eventos a los que fue invitado (título,
  descripción, fecha, enlace de Google Meet).
- Acceder al enlace de Google Meet del evento en la fecha programada.

## Restricciones

- Solo puede visualizar los eventos que él creó y los eventos a los que fue
  invitado. **No puede** ver ningún otro evento del sistema.
- Como asistente, **no puede** ver el listado de asistentes del evento; solo
  ve la información básica.
- Solo puede modificar o eliminar eventos que él mismo creó.
- **No puede** eliminar su cuenta si es organizador de al menos un
  [`Event`](../Entities/Event.md) cuyo `state` sea `activo`. Todos sus
  eventos deben haber pasado al estado `finalizado` antes de poder darse de
  baja.
- No tiene acceso al módulo de administración ni a las operaciones exclusivas
  del `Usuario Administrador`.
- No puede crear salas de videoconferencia — el sistema solo genera el
  enlace hacia Google Meet, la creación de la sala está fuera del alcance.

## Reglas de negocio aplicables

1. **Regla 1** — Requiere una cuenta de usuario para poder utilizar la
   aplicación.
2. **Regla 2** — Puede crear eventos y puede ser invitado a eventos.
3. **Regla 3** — Puede ser organizador de múltiples eventos y asistente de
   múltiples eventos simultáneamente (relación M:N con `Event` a través de
   `UserEvent`).
4. **Regla 4** — Solo puede visualizar los eventos a los que fue invitado o
   que él creó.
5. **Regla 5** — Solo puede modificar o eliminar los eventos que él mismo
   creó (los administradores también pueden hacerlo).
6. **Regla 6** — Un evento que creó tiene dos estados: `activo` (aún no
   ocurrió) y `finalizado` (ya ocurrió).
7. **Regla 11** — Como organizador de un evento, puede ver el listado de
   todos los asistentes del evento.
8. **Regla 12** — Como asistente de un evento, solo ve la información
   básica; no ve el listado de asistentes.
9. **Regla 13** — No puede eliminar su cuenta si es organizador de eventos
   activos.

## Casos de uso

### Como usuario registrado

- **Registrarse en la aplicación**: crear una cuenta nueva proporcionando
  todos los datos requeridos.
- **Iniciar sesión**: autenticarse con username y contraseña.
- **Gestionar cuenta**: consultar y modificar la información de su cuenta
  desde el módulo de cuenta.
- **Eliminar cuenta**: dar de baja su cuenta si no tiene eventos activos como
  organizador.

### Como organizador

- **Crear evento**: registrar un nuevo evento con título, descripción y
  fecha; el sistema genera el enlace de Google Meet.
- **Modificar evento**: actualizar los datos de un evento que él creó.
- **Eliminar evento**: dar de baja un evento que él creó.
- **Invitar asistentes**: agregar otros usuarios como asistentes; el sistema
  envía las invitaciones por correo.
- **Ver detalle de evento propio**: consultar toda la información del evento
  incluyendo el listado de asistentes.
- **Ver listado de asistentes**: revisar quién aceptó, rechazó o no ha
  respondido aún.

### Como asistente

- **Ver mis invitaciones**: listar los eventos a los que fue invitado.
- **Aceptar invitación**: responder afirmativamente a la invitación desde el
  enlace del correo.
- **Rechazar invitación**: responder negativamente a la invitación desde el
  enlace del correo.
- **Ver detalle de evento como asistente**: consultar la información básica
  de un evento al que está invitado (sin listado de asistentes).
- **Unirse al evento**: acceder al enlace de Google Meet en la fecha
  programada.
