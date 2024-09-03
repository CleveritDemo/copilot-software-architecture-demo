# Common User

## Description
The `Common User` actor represents a regular user within the system who can participate in events. This actor can have the roles of `Attendant` and `Organizer`.

## Responsibilities
### As an Attendant
- View available events.
- Join and participate in events.
- Provide feedback on events.

### As an Organizer
- Create and manage events.
- Invite users to events.
- Monitor event participation and feedback.

## Restrictions
- Common Users must have a valid user account.
- Common Users can only join events that are active and not full.
- Organizers can only manage events they have created.

## Business Rules
### As an Attendant
- Attendants must authenticate using a valid user account.
- Attendants can only join events they are eligible for.
- Attendants must adhere to event rules and guidelines.

### As an Organizer
- Organizers must authenticate using a valid user account.
- Organizers can only manage their own events.
- Organizers must ensure events comply with system policies.

## Use Cases
### As an Attendant
- **View Events**: Attendant views a list of available events.
- **Join Event**: Attendant joins an event they are interested in.
- **Leave Event**: Attendant leaves an event they no longer wish to participate in.
- **Provide Feedback**: Attendant provides feedback on an event they attended.

### As an Organizer
- **Create Event**: Organizer creates a new event with specified details.
- **Manage Event**: Organizer updates or deletes an event they created.
- **Invite Users**: Organizer invites users to join their event.
- **Monitor Participation**: Organizer monitors user participation and feedback for their events.