# ReportGenerationService

## Description
The `ReportGenerationService` generates reports on system activity and user participation. It provides various filters and parameters for report customization.

## Entities Involved
- [`Event`](../Entities/Event.md)
- [`User`](../Entities/User.md)
- [`UserEvent`](../Entities/UserEvent.md)

## Operations
- **GenerateActivityReport(filters)**
  - Generates a report on system activity based on the specified filters.
- **GenerateParticipationReport(filters)**
  - Generates a report on user participation based on the specified filters.
- **GenerateEventReport(eventId)**
  - Generates a detailed report for a specific event.