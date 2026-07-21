---
mode: agent
description: Genera documentación de casos de uso por actor del sistema.
tools: ['editFiles', 'search']
---

Objetivo: basándose en las reglas de negocio de la aplicación y en la
documentación de actores bajo `#folder:docs/Actors`, crear los documentos
de casos de uso en Markdown, uno por actor, bajo `docs/UseCases/` con el
nombre `<ActorName>UseCases.md`.

Cada archivo debe contener, para cada caso de uso:

1. Título del caso de uso.
2. Actor primario.
3. Prerrequisitos.
4. Una tabla con el flujo paso a paso (columnas: `Paso`, `Actor`,
   `Sistema`).
5. Resultado esperado.
6. Flujos alternativos (si aplican).

Restricciones:

- No crear archivos que ya existan.
- Usar exactamente los casos de uso listados en los archivos de actor
  bajo `docs/Actors/`.
- No inventar casos de uso que no estén documentados.
- Los nombres de los casos de uso deben coincidir literalmente con los
  de los archivos de actor.
