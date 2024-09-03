# InvitationManagementService

## Description
The `InvitationManagementService` handles sending invitations to users for events. It manages user responses to invitations.

## Entities Involved
- [`Event`](../Entities/Event.md)
- [`User`](../Entities/User.md)

## Operations
- **SendInvitationToUser(userId, eventId)**
  - Sends an invitation to a user for a specific event.
- **SendInvitationToUserWithAttachment(userId, eventId, attachment)**
  - Sends an invitation to a user for a specific event with an attachment.
- **SendInvitationToExternalUser(email, eventId)**
  - Sends an invitation to an external user via email for a specific event.
- **RemoveInvitation(invitationId)**
  - Removes an existing invitation.
- **GetInvitationStatus(invitationId)**
  - Retrieves the status of a specific invitation.