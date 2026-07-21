---
mode: agent
description: Genera un diagrama PlantUML de caso de uso a partir de un caso de uso documentado.
tools: ['editFiles', 'search']
---

Objetivo: dado un caso de uso específico referenciado por el usuario,
crear un archivo `.plantuml` bajo `docs/Diagrams/use-cases/<actor>/`
con el nombre `<use-case-name>.plantuml`, representando visualmente
todos los pasos del flujo descrito en ese caso de uso.

Cada archivo debe:

1. Usar los delimitadores `@startuml` / `@enduml`.
2. Definir el actor primario con `actor <Name> as <Alias>`.
3. Representar cada paso del flujo como una interacción entre el actor
   y los casos de uso involucrados usando la sintaxis de use case
   diagram de PlantUML.
4. Ser sintácticamente válido y renderizable con la extensión de
   PlantUML de VS Code.

Restricciones:

- Un archivo = un caso de uso.
- No inventar pasos que no estén en el documento de caso de uso fuente.
- Si el output excede el límite de respuesta del modelo, generar solo
  el archivo solicitado y responder "¿continúo con el siguiente?" para
  que el usuario dispare el próximo.
