# User

## Description
The `User` entity represents a user within the system. It includes details such as the user's unique identifier, name, email, and role. Users can create events and participate in events.

## Attributes

| Attribute       | Data Type | Description                                                                 | Business Rules                                                                 |
|-----------------|-----------|-----------------------------------------------------------------------------|-------------------------------------------------------------------------------|
| `userId`        | `String`  | Unique identifier for the user.                                             | Must be unique and non-null.                                                  |
| `name`          | `String`  | Full name of the user.                                                      | Must be non-null and non-empty.                                               |
| `email`         | `String`  | Email address of the user.                                                  | Must be a valid email address and unique.                                     |
| `role`          | `String`  | Role of the user within the system (e.g., admin, participant).              | Must be either 'admin' or 'participant'.                                      |

## Relationships
- A `User` can create multiple `Event` entities.
- A `User` can have multiple `UserEvent` entries, representing participation in multiple events.