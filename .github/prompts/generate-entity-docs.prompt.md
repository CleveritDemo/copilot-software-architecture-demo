---
mode: agent
description: Genera un archivo Markdown de documentación por cada entidad del sistema.
tools: ['editFiles', 'search']
---

Objetivo: para cada entidad definida en el contexto actual del sistema,
crear un archivo Markdown bajo `docs/Entities/` llamado `<EntityName>.md`.

Cada archivo debe contener:

1. Una descripción detallada de la entidad explicando su rol.
2. Una tabla con todos los atributos, su tipo de dato, descripción y las
   reglas de negocio aplicables.
3. Una sección de "Relaciones" con los vínculos hacia otras entidades.

Restricciones:

- No crear archivos para entidades que ya existan.
- Usar la lista de entidades confirmada en el chat hasta ahora. Si dudas,
  referencia `#file:context-prompt-es.md` y el historial del chat.
- No inventar atributos que no estén mencionados en las reglas de negocio.
