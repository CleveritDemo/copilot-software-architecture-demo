# User

## Descripción

La entidad `User` representa una cuenta de usuario dentro del sistema de registro
de eventos. Es la entidad central del modelo de dominio: todo evento pertenece a
un usuario creador y toda participación en un evento se materializa como una
relación entre un usuario y un evento. El sistema reconoce dos roles: **usuario
común**, que puede crear eventos y participar en ellos, y **usuario
administrador**, que tiene control total sobre la aplicación. Solo los usuarios
comunes pueden registrarse desde la aplicación; los administradores están
integrados en el sistema (el administrador por defecto es `admin` con contraseña
`admin123`).

## Atributos

| Atributo             | Tipo de Dato | Descripción                                                                 | Reglas de Negocio                                                                                              |
|----------------------|--------------|-----------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------|
| `userId`             | `String`     | Identificador único del usuario dentro del sistema.                         | Debe ser único y no nulo. Generado por el sistema en el momento del registro.                                  |
| `username`           | `String`     | Nombre de usuario elegido para iniciar sesión y ser identificado.           | Debe ser único, no nulo y no vacío.                                                                            |
| `email`              | `String`     | Correo electrónico asociado a la cuenta. Se usa para invitaciones a eventos.| Debe ser una dirección de correo electrónico válida y única.                                                   |
| `fullName`           | `String`     | Nombre completo del usuario.                                                | Debe ser no nulo y no vacío.                                                                                   |
| `age`                | `Integer`    | Edad del usuario.                                                           | Debe ser un valor entero positivo.                                                                             |
| `countryOfResidence` | `String`     | País de residencia del usuario.                                             | Debe ser no nulo y no vacío. Necesario porque el sistema es accedido desde cualquier parte del mundo.          |
| `phoneNumber`        | `String`     | Número de teléfono de contacto del usuario.                                 | Debe seguir un formato válido de número telefónico.                                                            |
| `password`           | `String`     | Credencial de acceso del usuario.                                           | Debe almacenarse cifrada. No se expone en respuestas de la API.                                                |
| `role`               | `String`     | Rol del usuario dentro del sistema.                                         | Debe ser `común` o `administrador`. Solo los usuarios comunes pueden registrarse desde la aplicación.          |

## Relaciones

- Un `User` puede crear múltiples entidades [`Event`](Event.md) (relación 1:N a
  través del atributo `Event.creatorUserId`).
- Un `User` puede participar en múltiples eventos mediante entradas
  [`UserEvent`](UserEvent.md) (relación M:N entre `User` y `Event`, resuelta a
  través de `UserEvent`).
- Un `User` con rol `común` no puede eliminar su cuenta si es creador de eventos
  cuyo `state` es `activo`; primero deben finalizar todos sus eventos.
- Un `User` con rol `administrador` puede modificar o eliminar cualquier
  [`Event`](Event.md) y cualquier otro `User` del sistema.
