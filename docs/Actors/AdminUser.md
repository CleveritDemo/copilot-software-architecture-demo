# Usuario Administrador

## Descripción

El actor **Usuario Administrador** representa a un usuario con privilegios
totales sobre la aplicación. A diferencia del `Usuario Común`, este actor **no
se registra desde la UI pública**: está integrado en el sistema. Existe un
administrador por defecto con username `admin` y contraseña `admin123`,
mantenido así por velocidad de desarrollo. La gestión de múltiples
administradores está explicitamente fuera del alcance de esta aplicación — se
delegará a un módulo futuro.

El `Usuario Administrador` es el único actor con acceso al **módulo de
administración** y opera transversalmente sobre todos los usuarios y todos los
eventos del sistema, sin las restricciones de visibilidad y propiedad que
aplican al `Usuario Común`.

## Responsabilidades

- Autenticarse en la aplicación con las credenciales de administrador
  integradas.
- Ver el listado completo de todos los [`User`](../Entities/User.md)
  registrados en la plataforma, sin restricciones.
- Agregar nuevos usuarios manualmente desde el módulo de administración.
- Modificar la información de cualquier `User`.
- Eliminar cualquier `User` del sistema.
- Ver el listado completo de todos los [`Event`](../Entities/Event.md) de la
  aplicación, independientemente del creador o de si el administrador figura
  como asistente.
- Modificar cualquier `Event`, incluso aquellos que no creó.
- Eliminar cualquier `Event`, incluso aquellos que no creó.

## Restricciones

- Solo existe el usuario administrador integrado por defecto (`admin` /
  `admin123`). La creación, modificación o eliminación de otros
  administradores desde la aplicación **no está soportada** en esta versión.
- Debe autenticarse con las credenciales de administrador integradas antes de
  acceder al módulo de administración.
- Aunque tiene control total, sus operaciones siguen sujetas a la integridad
  del modelo: no puede dejar huérfanos referenciales entre `User`, `Event` y
  `UserEvent`.

## Reglas de negocio aplicables

1. **Regla 5** — Un evento puede ser modificado o eliminado por su
   organizador o por un `Usuario Administrador`.
2. **Regla 8** — Puede ver todos los eventos dentro de la aplicación.
3. **Regla 9** — Tiene control total sobre la aplicación.
4. **Regla 10** — Puede ver el listado completo de todos los usuarios de la
   plataforma.
5. **Regla implícita del módulo de administración** — Existe un administrador
   por defecto (`admin` / `admin123`) integrado en el sistema; la gestión de
   múltiples administradores queda fuera del alcance actual.

## Casos de uso

- **Iniciar sesión como administrador**: autenticarse con las credenciales
  integradas (`admin` / `admin123`).
- **Ver listado de todos los usuarios**: consultar la lista completa de
  `User` registrados en la plataforma desde el módulo de administración.
- **Agregar usuario**: crear manualmente una nueva cuenta de `User` desde el
  módulo de administración.
- **Modificar usuario**: actualizar la información de cualquier `User`
  existente.
- **Eliminar usuario**: dar de baja cualquier `User` del sistema.
- **Ver listado de todos los eventos**: consultar la lista completa de
  `Event` registrados en la aplicación.
- **Modificar cualquier evento**: actualizar la información de cualquier
  `Event`, incluso aquellos que no creó.
- **Eliminar cualquier evento**: dar de baja cualquier `Event`, incluso
  aquellos que no creó.
