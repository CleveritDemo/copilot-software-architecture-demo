# FeedbackManagementService

## Description
The `FeedbackManagementService` collects and manages user feedback on events. It provides mechanisms for users to submit feedback.

## Entities Involved
- [`Event`](../Entities/Event.md)
- [`User`](../Entities/User.md)

## Operations
- **SubmitFeedback(userId, eventId, feedback)**
  - Submits feedback for a specific event by a user.
- **GetFeedback(eventId)**
  - Retrieves all feedback for a specific event.
- **ListFeedback()**
  - Lists all feedback submitted by users.