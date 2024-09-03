# Event registration App

**Requirement**

A web application needs to be created with the purpose of enabling the creation of online events. An event is defined as a record where there is an online video conference room, a date indicating when the event will occur, a list of attendees, and a user who is the creator or organizer of the event. This application does not need to create a video conferencing system from scratch; simply, during the event registration, an automatic URL link to a Google Meet video chat room will be generated, so creating video conference rooms is not within the scope of this project. This application also needs to send email invitations for the event to each of the attendees. These emails will contain the event information and a web link to the application URL where they can accept or decline the invitation.

**Business rules or restrictions**

- A user account must be created to use the application.
Registered users can create events and can be invited to events within the application.
- A user can be the organizer of multiple events and a user can be an attendee of multiple events.
- Users can only view events to which they have been invited.
An event can only be modified or deleted by the user who created it or by a system administrator.
- An event can have two states: active and finished. The active state indicates that the event has not yet occurred, and the finished state indicates that the event has already occurred and thus has ended.
- The system must be accessible from anywhere in the world.
- The administrator user can see all events within the application.
- The administrator user has complete control of the application.
- The administrator user can see a list of all users on the platform.
- The organizer user can see a list of all attendees of the event.
- The attendee user can only see the basic information of the event and cannot see the list of attendees.
- A user cannot delete their account if they are the organizer of active events. To delete the account, all events in which the user is an organizer must have already ended.

**Web application modules**

- Content module: Allows listing the events that the user has organized and the events that the user has accepted to attend.
- Event module: Shows the event details. In the case of an organizer user, it will show all the event information and the list of attendees. In the case of an attendee user, it will only show the basic information of the event.
- Account module: Allows the user to manage their account information such as the associated email, username, full name, age, country of residence, phone number, and an option to delete the account.
- Administration module: Accessible only to application administrators. Allows viewing the total list of users, adding users, deleting users, modifying users, and deleting and modifying any event. There is a default administrator user named “admin” with the default password “admin123”. This user will be maintained for development speed; later, a module to manage administrator users will be added, but that is outside the scope of this application.

**Open quiestion prompt for GitHub Copilot**

Now that you have the complete context, do not give me results yet. First, process all the information I have given you, because I will provide you with several subsequent prompts that will indicate the diagrams I need to generate and the documentation I need you to construct using markdown files.

