---
mode: agent
description: Genera un archivo Markdown de documentación por cada actor del sistema.
tools: ['editFiles', 'search']
---

Objetivo: para cada actor confirmado en el contexto del chat, crear un
archivo Markdown bajo `docs/Actors/` llamado `<ActorName>.md`.

Cada archivo debe contener:

1. Una descripción detallada del actor.
2. Sus responsabilidades.
3. Sus restricciones.
4. Todas las reglas de negocio aplicables.
5. Todos sus casos de uso.

Restricciones:

- Usar exactamente los nombres de actor confirmados en el chat:
  **Usuario Común** y **Usuario Administrador** (salvo que el chat diga
  lo contrario).
- Si la lista de actores incluye algo más, deténte y pide confirmación
  al usuario antes de generar archivos.
