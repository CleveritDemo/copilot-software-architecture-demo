# Casos de Uso — Usuario Común

Este documento describe cada caso de uso del actor **Usuario Común**,
siguiendo el orden y los nombres literales listados en
[../Actors/CommonUser.md](../Actors/CommonUser.md).

---

## 1. Registrarse en la aplicación

**Actor primario:** Usuario Común (no autenticado).

**Prerrequisitos:**
- El usuario no tiene cuenta previa en el sistema.
- El usuario dispone de un correo electrónico válido y único.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre el formulario de registro. | Muestra el formulario. |
| 2 | Ingresa username, email, contraseña, nombre completo, edad, país y teléfono. | Valida el formato de cada campo. |
| 3 | Envía el formulario. | Valida unicidad de username y email. |
| 4 | — | Cifra la contraseña y persiste el `User` con `role = común`. |
| 5 | — | Redirige al login con un mensaje de confirmación. |

**Resultado esperado:** el `User` queda registrado y puede iniciar sesión.

**Flujos alternativos:**
- **A1 — Username o email duplicado:** el sistema muestra un mensaje de error y preserva los datos ingresados sin persistir.
- **A2 — Validación de formato fallida:** el sistema resalta los campos inválidos y no envía el formulario.

---

## 2. Iniciar sesión

**Actor primario:** Usuario Común (no autenticado).

**Prerrequisitos:**
- El usuario tiene una cuenta registrada en el sistema.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre la pantalla de login. | Muestra el formulario. |
| 2 | Ingresa username y contraseña. | Valida credenciales contra el `User` registrado. |
| 3 | Envía. | Crea la sesión y redirige al módulo de contenido. |

**Resultado esperado:** el usuario accede a la aplicación con permisos de rol `común`.

**Flujos alternativos:**
- **A1 — Credenciales inválidas:** el sistema muestra un mensaje de error y no crea sesión.

---

## 3. Gestionar cuenta

**Actor primario:** Usuario Común.

**Prerrequisitos:**
- El usuario tiene sesión iniciada.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede al módulo de cuenta. | Muestra la información actual del `User`. |
| 2 | Modifica los campos deseados (email, nombre, edad, país, teléfono, contraseña). | Valida el formato en tiempo real. |
| 3 | Guarda los cambios. | Valida la unicidad de email/username si cambiaron. |
| 4 | — | Persiste los cambios en el `User` (cifrando la contraseña si fue actualizada). |

**Resultado esperado:** los datos del `User` quedan actualizados.

**Flujos alternativos:**
- **A1 — Nuevo email o username duplicado:** el sistema muestra error y no persiste.

---

## 4. Eliminar cuenta

**Actor primario:** Usuario Común.

**Prerrequisitos:**
- El usuario tiene sesión iniciada.
- No es `creatorUserId` de ningún `Event` con `state = activo` (Regla 13).

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede a "Eliminar cuenta" en el módulo de cuenta. | Verifica si el usuario tiene eventos activos como organizador. |
| 2 | Confirma la eliminación. | Elimina el `User` y todas sus filas `UserEvent` asociadas. |
| 3 | — | Cierra sesión y redirige al login. |

**Resultado esperado:** el `User` deja de existir en el sistema.

**Flujos alternativos:**
- **A1 — Usuario con eventos activos como organizador:** el sistema bloquea la eliminación y muestra la lista de eventos que deben finalizar antes.

---

## 5. Crear evento

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario tiene sesión iniciada.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede a "Crear evento". | Muestra el formulario. |
| 2 | Ingresa título, descripción y fecha. | Valida formato y que la fecha sea futura. |
| 3 | Envía. | Genera automáticamente el `googleMeetLink`. |
| 4 | — | Crea el `Event` con `creatorUserId = usuario actual` y `state = activo`. |
| 5 | — | Redirige al detalle del evento recién creado. |

**Resultado esperado:** un nuevo `Event` queda registrado con el usuario como creador.

**Flujos alternativos:**
- **A1 — Fecha inválida o pasada:** el sistema muestra error y no persiste.

---

## 6. Modificar evento

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario es el `creatorUserId` del `Event`.
- El `Event` existe.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede al detalle del evento propio. | Verifica que el usuario es el creador (Regla 5). |
| 2 | Ingresa las modificaciones (título, descripción, fecha). | Valida el formato de los campos. |
| 3 | Guarda. | Persiste los cambios en el `Event`. |

**Resultado esperado:** el `Event` queda actualizado con los nuevos valores.

**Flujos alternativos:**
- **A1 — Usuario no es el creador:** el sistema deniega el acceso y no aplica cambios.

---

## 7. Eliminar evento

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario es el `creatorUserId` del `Event`.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede al detalle del evento propio. | Verifica que el usuario es el creador (Regla 5). |
| 2 | Selecciona "Eliminar evento" y confirma. | Elimina el `Event` y todas sus filas `UserEvent` asociadas. |

**Resultado esperado:** el `Event` deja de existir. Los asistentes previamente invitados ya no pueden verlo.

**Flujos alternativos:**
- **A1 — Usuario no es el creador:** el sistema deniega el acceso.

---

## 8. Invitar asistentes

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario es el `creatorUserId` del `Event`.
- Los usuarios a invitar existen en el sistema.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede al detalle del evento propio y elige "Invitar asistentes". | Muestra el selector de usuarios registrados. |
| 2 | Selecciona uno o más usuarios y confirma. | Crea una fila `UserEvent` por cada usuario invitado (sin `status` asignado). |
| 3 | — | Envía un correo electrónico a cada invitado con la información del evento y el enlace de respuesta. |

**Resultado esperado:** cada usuario invitado tiene una fila `UserEvent` y recibe el correo con la invitación.

**Flujos alternativos:**
- **A1 — Usuario ya invitado previamente:** el sistema omite el duplicado y notifica al organizador.

---

## 9. Ver detalle de evento propio

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario es el `creatorUserId` del `Event`.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un evento propio en el módulo de contenido. | Verifica que el usuario es el creador. |
| 2 | — | Muestra toda la información del evento incluyendo el listado de asistentes (Regla 11). |

**Resultado esperado:** el organizador ve la información completa del evento y la lista de asistentes con sus respuestas.

**Flujos alternativos:** N/A.

---

## 10. Ver listado de asistentes

**Actor primario:** Usuario Común (rol funcional: organizador).

**Prerrequisitos:**
- El usuario es el `creatorUserId` del `Event`.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede a la pestaña de asistentes en el detalle del evento propio. | Consulta todas las filas `UserEvent` con ese `eventId`. |
| 2 | — | Muestra el listado con el estado (`aceptado`, `rechazado`, sin respuesta) por asistente. |

**Resultado esperado:** el organizador ve la respuesta de cada invitado.

**Flujos alternativos:** N/A.

---

## 11. Ver mis invitaciones

**Actor primario:** Usuario Común (rol funcional: asistente).

**Prerrequisitos:**
- El usuario tiene sesión iniciada.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Accede al módulo de contenido, sección de invitaciones. | Consulta las filas `UserEvent` donde `userId = usuario actual`. |
| 2 | — | Muestra los eventos a los que fue invitado con el estado de respuesta actual. |

**Resultado esperado:** el usuario ve la lista de eventos a los que fue invitado.

**Flujos alternativos:** N/A.

---

## 12. Aceptar invitación

**Actor primario:** Usuario Común (rol funcional: asistente).

**Prerrequisitos:**
- Existe una fila `UserEvent` para el usuario y el evento.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre el enlace de aceptación desde el correo o desde el módulo de contenido. | Verifica que existe la `UserEvent`. |
| 2 | Confirma la aceptación. | Actualiza `UserEvent.status = aceptado`. |
| 3 | — | Muestra la confirmación y agrega el evento a "Mis eventos aceptados". |

**Resultado esperado:** el usuario queda registrado como asistente confirmado del evento.

**Flujos alternativos:**
- **A1 — La invitación no existe (fue eliminada):** el sistema muestra un mensaje de error.

---

## 13. Rechazar invitación

**Actor primario:** Usuario Común (rol funcional: asistente).

**Prerrequisitos:**
- Existe una fila `UserEvent` para el usuario y el evento.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre el enlace de rechazo desde el correo o desde el módulo de contenido. | Verifica que existe la `UserEvent`. |
| 2 | Confirma el rechazo. | Actualiza `UserEvent.status = rechazado`. |
| 3 | — | Muestra la confirmación. |

**Resultado esperado:** el `UserEvent.status` queda en `rechazado` y el organizador puede ver la respuesta.

**Flujos alternativos:**
- **A1 — La invitación no existe:** el sistema muestra un mensaje de error.

---

## 14. Ver detalle de evento como asistente

**Actor primario:** Usuario Común (rol funcional: asistente).

**Prerrequisitos:**
- Existe una fila `UserEvent` con `status = aceptado` para el usuario y el evento.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Selecciona un evento aceptado en el módulo de contenido. | Verifica la fila `UserEvent`. |
| 2 | — | Muestra únicamente la información básica del evento (título, descripción, fecha, enlace de Google Meet). No muestra el listado de asistentes (Regla 12). |

**Resultado esperado:** el asistente ve la información básica del evento sin exposición del listado de asistentes.

**Flujos alternativos:** N/A.

---

## 15. Unirse al evento

**Actor primario:** Usuario Común (rol funcional: asistente).

**Prerrequisitos:**
- Existe una fila `UserEvent` con `status = aceptado`.
- El `Event.state` sigue siendo `activo` en la fecha programada.

**Flujo:**

| Paso | Actor | Sistema |
|------|-------|---------|
| 1 | Abre el detalle del evento en la fecha programada. | Muestra el enlace de Google Meet. |
| 2 | Hace clic en el enlace. | Redirige a la sala externa de Google Meet. |

**Resultado esperado:** el asistente accede a la sala de videoconferencia del evento.

**Flujos alternativos:**
- **A1 — El evento ya finalizó (`state = finalizado`):** el sistema muestra un aviso indicando que el evento ha concluido y el enlace no está disponible.
