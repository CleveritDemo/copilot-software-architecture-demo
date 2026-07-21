# Casos de Uso — Usuario Administrador

Este documento describe cada caso de uso del actor **Usuario Administrador**,
siguiendo el orden y los nombres literales listados en
[../Actors/AdminUser.md](../Actors/AdminUser.md).

---

## 1. Iniciar sesión como administrador

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- El administrador conoce las credenciales integradas por defecto (`admin` / `admin123`).

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre la pantalla de login. | Muestra el formulario. |
| 2 | Ingresa `admin` como username y la contraseña integrada. | Valida contra las credenciales de administrador. |
| 3 | Envía. | Crea la sesión con `role = administrador` y redirige al módulo de administración. |

**Resultado esperado:** el administrador accede al módulo de administración con permisos totales sobre usuarios y eventos.

**Flujos alternativos:**
- **A1 — Credenciales inválidas:** el sistema muestra un mensaje de error y no crea sesión.

---

## 2. Ver listado de todos los usuarios

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede a la sección "Usuarios" en el módulo de administración. | Consulta todos los `User` del sistema (Regla 10). |
| 2 | — | Muestra el listado completo con username, email, rol y demás campos. |

**Resultado esperado:** el administrador ve la lista completa de usuarios registrados.

**Flujos alternativos:** N/A.

---

## 3. Agregar usuario

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona "Agregar usuario" en el módulo de administración. | Muestra el formulario. |
| 2 | Ingresa los datos del nuevo `User` (username, email, contraseña, nombre completo, edad, país, teléfono). | Valida formato y unicidad. |
| 3 | Envía. | Cifra la contraseña y persiste el `User` con `role = común`. |

**Resultado esperado:** un nuevo `User` queda creado por vía administrativa.

**Flujos alternativos:**
- **A1 — Username o email duplicado:** el sistema muestra error y no persiste.

---

## 4. Modificar usuario

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.
- El `User` objetivo existe.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un `User` en el listado. | Muestra el formulario con los datos actuales. |
| 2 | Modifica los campos deseados. | Valida formato y unicidad si cambian email/username. |
| 3 | Guarda. | Persiste los cambios en el `User`. |

**Resultado esperado:** los datos del `User` quedan actualizados.

**Flujos alternativos:**
- **A1 — Conflicto de unicidad al actualizar email o username:** el sistema muestra error y no persiste.

---

## 5. Eliminar usuario

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.
- El `User` objetivo existe.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un `User` en el listado y elige "Eliminar". | Solicita confirmación. |
| 2 | Confirma. | Elimina el `User` y todas sus filas `UserEvent` asociadas. |

**Resultado esperado:** el `User` deja de existir en el sistema.

**Flujos alternativos:**
- **A1 — El `User` es organizador de eventos activos:** el sistema muestra una advertencia listando los eventos afectados. El administrador puede confirmar la eliminación en cascada o cancelar la operación.

---

## 6. Ver listado de todos los eventos

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede a la sección "Eventos" en el módulo de administración. | Consulta todos los `Event` del sistema (Regla 8), sin filtrar por asistencia ni por creador. |
| 2 | — | Muestra el listado completo con creador, fecha, estado y enlace de Google Meet. |

**Resultado esperado:** el administrador ve la lista completa de eventos del sistema.

**Flujos alternativos:** N/A.

---

## 7. Modificar cualquier evento

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.
- El `Event` objetivo existe.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un `Event` en el listado (independientemente del creador). | Muestra el formulario con los datos actuales. |
| 2 | Ingresa las modificaciones. | Valida el formato de los campos. |
| 3 | Guarda. | Persiste los cambios en el `Event` (Regla 5). |

**Resultado esperado:** el `Event` queda actualizado con los nuevos valores.

**Flujos alternativos:** N/A.

---

## 8. Eliminar cualquier evento

**Actor primario:** Usuario Administrador.

**Prerrequisitos:**
- Sesión iniciada como administrador.
- El `Event` objetivo existe.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un `Event` en el listado y elige "Eliminar". | Solicita confirmación. |
| 2 | Confirma. | Elimina el `Event` y todas sus filas `UserEvent` asociadas (Regla 5). |

**Resultado esperado:** el `Event` deja de existir. Los asistentes previamente invitados ya no pueden verlo.

**Flujos alternativos:** N/A.
