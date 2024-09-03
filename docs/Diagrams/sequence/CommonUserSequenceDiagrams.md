# Use Case Diagrams

## Common User Use Cases

### View Events

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the events section
    EventManagementService ->> CommonUser: Displays a list of available events

```

### Join Event

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the events section
    CommonUser ->> EventManagementService: Selects an event to join
    CommonUser ->> EventManagementService: Clicks on "Join Event"
    EventManagementService ->> UserEvent: Validates the user's eligibility and adds the user to the event
    EventManagementService ->> CommonUser: Displays confirmation message
```

### Leave Event

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to their list of joined events
    CommonUser ->> EventManagementService: Selects an event to leave
    CommonUser ->> EventManagementService: Clicks on "Leave Event"
    EventManagementService ->> UserEvent: Removes the user from the event
    EventManagementService ->> CommonUser: Displays confirmation message
```

### Provide Feedback

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to their list of attended events
    CommonUser ->> EventManagementService: Selects an event to provide feedback on
    CommonUser ->> FeedbackManagementService: Fills in the feedback form
    CommonUser ->> FeedbackManagementService: Submits the feedback form
    FeedbackManagementService ->> Feedback: Validates input and saves the feedback
    FeedbackManagementService ->> CommonUser: Displays confirmation message
```

### Create Event

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the event management section
    CommonUser ->> EventManagementService: Clicks on "Create Event"
    CommonUser ->> EventManagementService: Fills in event details
    CommonUser ->> EventManagementService: Submits the event creation form
    EventManagementService ->> Event: Validates input and creates the event
    EventManagementService ->> CommonUser: Displays confirmation message
```

### Manage Event

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the event management section
    CommonUser ->> EventManagementService: Selects an event to manage
    CommonUser ->> EventManagementService: Updates or deletes the event
    EventManagementService ->> Event: Validates input and performs the action
    EventManagementService ->> CommonUser: Displays confirmation message
```

### Invite Users

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the event management section
    CommonUser ->> EventManagementService: Selects an event to invite users to
    CommonUser ->> InvitationManagementService: Sends invitations to selected users
    InvitationManagementService ->> Invitation: Sends the invitations
    InvitationManagementService ->> CommonUser: Displays confirmation message
```

### Monitor Participation

```mermaid
sequenceDiagram
    actor CommonUser
    CommonUser ->> System: Logs into the system
    CommonUser ->> EventManagementService: Navigates to the event management section
    CommonUser ->> EventManagementService: Selects an event to monitor
    EventManagementService ->> UserEvent: Displays the list of participants and their feedback
    UserEvent ->> CommonUser: Reviews the participation and feedback
```