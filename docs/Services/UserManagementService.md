# UserManagementService

## Description
The `UserManagementService` manages user accounts, including creating, updating, and deleting users. It handles user authentication and authorization and manages user roles (e.g., Admin, Common User).

## Entities Involved
- [`User`](../Entities/User.md)

## Operations
- **CreateUser(userDetails)**
  - Creates a new user with the specified details.
- **UpdateUser(userId, updatedDetails)**
  - Updates the details of an existing user.
- **DeleteUser(userId)**
  - Deletes an existing user.
- **GetUser(userId)**
  - Retrieves the details of a specific user.
- **ListUsers()**
  - Lists all users.
- **AuthenticateUser(email, password)**
  - Authenticates a user with the provided email and password.
- **AssignRoleToUser(userId, role)**
  - Assigns a specific role to a user.