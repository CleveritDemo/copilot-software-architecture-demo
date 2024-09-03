# Event

## Description
The `Event` entity represents an event within the system. It includes details such as the event's title, description, date, creator, and state. Events can be active or finished and may include a Google Meet link for virtual meetings.

## Attributes

| Attribute       | Data Type | Description                                                                 | Business Rules                                                                 |
|-----------------|-----------|-----------------------------------------------------------------------------|-------------------------------------------------------------------------------|
| `eventId`       | `String`  | Unique identifier for the event.                                            | Must be unique and non-null.                                                  |
| `title`         | `String`  | Title of the event.                                                         | Must be non-null and non-empty.                                               |
| `description`   | `String`  | Detailed description of the event.                                          | Optional.                                                                     |
| `date`          | `Date`    | Date and time when the event is scheduled to occur.                         | Must be a valid date in the future.                                           |
| `creatorUserId` | `String`  | Identifier of the user who created the event.                               | Must be a valid user ID.                                                      |
| `state`         | `String`  | Current state of the event (active, finished).                              | Must be either 'active' or 'finished'.                                        |
| `googleMeetLink`| `String`  | Link to the Google Meet for the event.                                       | Optional. Must be a valid URL if provided.                                    |

## Relationships
- An `Event` is created by a `User`.
- An `Event` can have multiple `UserEvent` entries associated with it, representing users' participation status.