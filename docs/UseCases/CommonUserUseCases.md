# Common User Use Cases

## Use Case: View Events

| Step | Description |
|------|-------------|
| 1    | Common User logs into the system using valid user credentials. |
| 2    | Common User navigates to the events section. |
| 3    | System displays a list of available events. |

**Prerequisites**: Common User must be logged in with valid user credentials.

**Expected Outcome**: The user sees a list of available events.

## Use Case: Join Event

| Step | Description |
|------|-------------|
| 1    | Common User logs into the system using valid user credentials. |
| 2    | Common User navigates to the events section. |
| 3    | Common User selects an event to join. |
| 4    | Common User clicks on the "Join Event" button. |
| 5    | System validates the user's eligibility and adds the user to the event. |
| 6    | System displays a confirmation message and updates the user's event list. |

**Prerequisites**: Common User must be logged in with valid user credentials and the event must be active and not full.

**Expected Outcome**: The user successfully joins the selected event.

## Use Case: Leave Event

| Step | Description |
|------|-------------|
| 1    | Common User logs into the system using valid user credentials. |
| 2    | Common User navigates to their list of joined events. |
| 3    | Common User selects an event to leave. |
| 4    | Common User clicks on the "Leave Event" button. |
| 5    | System removes the user from the event. |
| 6    | System displays a confirmation message and updates the user's event list. |

**Prerequisites**: Common User must be logged in with valid user credentials and must have previously joined the event.

**Expected Outcome**: The user successfully leaves the selected event.

## Use Case: Provide Feedback

| Step | Description |
|------|-------------|
| 1    | Common User logs into the system using valid user credentials. |
| 2    | Common User navigates to their list of attended events. |
| 3    | Common User selects an event to provide feedback on. |
| 4    | Common User fills in the feedback form. |
| 5    | Common User submits the feedback form. |
| 6    | System validates the input and saves the feedback. |
| 7    | System displays a confirmation message. |

**Prerequisites**: Common User must be logged in with valid user credentials and must have attended the event.

**Expected Outcome**: The user's feedback is successfully submitted and saved.

## Use Case: Create Event (Organizer)

| Step | Description |
|------|-------------|
| 1    | Common User (Organizer) logs into the system using valid user credentials. |
| 2    | Organizer navigates to the event management section. |
| 3    | Organizer clicks on the "Create Event" button. |
| 4    | Organizer fills in the event details (title, description, date, etc.). |
| 5    | Organizer submits the event creation form. |
| 6    | System validates the input and creates the event. |
| 7    | System displays a confirmation message and the new event appears in the event list. |

**Prerequisites**: Organizer must be logged in with valid user credentials.

**Expected Outcome**: A new event is created and listed in the event management section.

## Use Case: Manage Event (Organizer)

| Step | Description |
|------|-------------|
| 1    | Common User (Organizer) logs into the system using valid user credentials. |
| 2    | Organizer navigates to the event management section. |
| 3    | Organizer selects an event to manage. |
| 4    | Organizer updates or deletes the event. |
| 5    | System validates the input and performs the action. |
| 6    | System displays a confirmation message and updates the event list accordingly. |

**Prerequisites**: Organizer must be logged in with valid user credentials and must have created the event.

**Expected Outcome**: The event is updated or deleted as specified by the organizer.

## Use Case: Invite Users (Organizer)

| Step | Description |
|------|-------------|
| 1    | Common User (Organizer) logs into the system using valid user credentials. |
| 2    | Organizer navigates to the event management section. |
| 3    | Organizer selects an event to invite users to. |
| 4    | Organizer sends invitations to selected users. |
| 5    | System sends the invitations to the selected users. |
| 6    | System displays a confirmation message. |

**Prerequisites**: Organizer must be logged in with valid user credentials and must have created the event.

**Expected Outcome**: Invitations are successfully sent to the selected users.

## Use Case: Monitor Participation (Organizer)

| Step | Description |
|------|-------------|
| 1    | Common User (Organizer) logs into the system using valid user credentials. |
| 2    | Organizer navigates to the event management section. |
| 3    | Organizer selects an event to monitor. |
| 4    | System displays the list of participants and their feedback. |
| 5    | Organizer reviews the participation and feedback. |

**Prerequisites**: Organizer must be logged in with valid user credentials and must have created the event.

**Expected Outcome**: The organizer successfully monitors the participation and feedback for their event.