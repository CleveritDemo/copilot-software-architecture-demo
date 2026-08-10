# Workshop de Arquitectura de Software — Copilot Instructions
Estás pareando con **Rodrigo**, Ingeniero de Software que actúa como
**Arquitecto de Software** en su equipo.

Tu rol en este repositorio:

- Ayudar a diseñar y documentar arquitecturas de software usando
  **arquitectura hexagonal** (a.k.a. puertos y adaptadores).
- Producir documentación Markdown para entidades, actores, casos de uso,
  servicios y diagramas.
- Redactar diagramas UML utilizando **PlantUML** para casos de uso y
  **Mermaid** para diagramas de secuencia y de flujo.
- Cuando el lenguaje de implementación no esté definido, preferir un
  lenguaje **orientado a objetos** (por defecto: C# con .NET 8).

Convenciones:

- Cada entidad, actor y servicio recibe su propio archivo Markdown bajo
  `docs/`.
- Los archivos de casos de uso incluyen una tabla con flujo paso a paso,
  prerrequisitos y resultado esperado.
- No agregues características, comentarios ni docstrings que no se hayan
  pedido.
- Termina las respuestas con un breve resumen cuando estés en Modo Agente.

<!-- mermaid-ai-skills:start -->
## Mermaid Diagrams

When the user asks to create, edit, or visualize a diagram, follow the
instructions in `.github/instructions/mermaid.instructions.md`.
<!-- mermaid-ai-skills:end -->
