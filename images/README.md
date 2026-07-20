# Workshop images

Static assets used by the [`README.md`](../README.md) and [`README-ESP.md`](../README-ESP.md)
of the **GitHub Copilot — Software Architecture Workshop**.

## Ready-to-use assets

| File | Role | Notes |
| ---- | ---- | ----- |
| [`header-en.svg`](./header-en.svg) | English README banner | Rendered by GitHub Markdown. |
| [`header-es.svg`](./header-es.svg) | Spanish README banner | Rendered by GitHub Markdown. |
| [`workshop-flow.svg`](./workshop-flow.svg) | End-to-end flow of the 8 steps | Referenced from both READMEs. |

## Screenshot placeholders (replace as you run the workshop)

Each SVG below acts as a labelled slot that renders as an image in Markdown.
When you (or a participant) reach that step during the workshop, capture a
real screenshot and drop it in this folder with the corresponding `.png`
name (see the label inside each placeholder).

| File | Suggested capture |
| ---- | ----------------- |
| [`step-01-copilot-instructions.svg`](./step-01-copilot-instructions.svg) | `.github/copilot-instructions.md` (or `AGENTS.md`) applied to a Copilot Chat session. |
| [`step-02-agent-mode.svg`](./step-02-agent-mode.svg) | Copilot Chat mode picker with **Agent** selected. |
| [`step-03-prompt-file.svg`](./step-03-prompt-file.svg) | A `.github/prompts/*.prompt.md` file being invoked from chat. |
| [`step-04-context-refs.svg`](./step-04-context-refs.svg) | Chat input using `#codebase`, `#file:context-prompt.md`, `#folder:docs`. |
| [`step-05-agent-generating.svg`](./step-05-agent-generating.svg) | Agent Mode iterating over entities and writing files under `docs/`. |
| [`step-06-plantuml.svg`](./step-06-plantuml.svg) | Rendered PlantUML use case diagram. |
| [`step-07-mermaid.svg`](./step-07-mermaid.svg) | Rendered Mermaid sequence diagram. |
| [`step-08-agent-scaffold.svg`](./step-08-agent-scaffold.svg) | Agent Mode running `dotnet new` and its checkpoint / tool-call list. |

## Naming convention for new screenshots

```
step-<NN>-<slug>.png     # main capture for a step
step-<NN>-<slug>-<n>.png # additional captures for the same step
```

Use `NN` = zero-padded step number. Keep captures under **2 MB** each; use
PNG for UI screenshots and SVG for diagrams you author.
