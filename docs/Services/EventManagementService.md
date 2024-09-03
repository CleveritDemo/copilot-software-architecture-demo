# EventManagementService

## Description
The `EventManagementService` is responsible for creating, updating, and deleting events. It manages event details such as title, description, date, and state. It also handles user participation in events.

## Entities Involved
- [`Event`](../Entities/Event.md)
- [`UserEvent`](../Entities/UserEvent.md)

## Operations
- **CreateEvent(eventDetails)**
  - Creates a new event with the specified details.
- **UpdateEvent(eventId, updatedDetails)**
  - Updates the details of an existing event.
- **DeleteEvent(eventId)**
  - Deletes an existing event.
- **GetEvent(eventId)**
  - Retrieves the details of a specific event.
- **ListEvents()**
  - Lists all available events.
- **AddUserToEvent(userId, eventId)**
  - Adds a user to an event.
- **RemoveUserFromEvent(userId, eventId)**
  - Removes a user from an event.