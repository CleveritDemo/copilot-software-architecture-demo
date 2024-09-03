# DummyEventApp

This is a .NET Web App project that serves as a website for the DummyEvent application. It follows the Clean Architecture principles and is built using .NET 8.

## Project Structure

The project has the following files and directories:

- `.gitignore`: Specifies the files and directories that should be ignored by Git version control.

- `DummyEventApp.sln`: Solution file that organizes multiple projects and their dependencies.

- `src/DummyEventApp.Web/Controllers/HomeController.cs`: Contains the `HomeController` class, which handles requests and responses for the home page.

- `src/DummyEventApp.Web/Models/ErrorViewModel.cs`: Contains the `ErrorViewModel` class, which represents the data for displaying error messages.

- `src/DummyEventApp.Web/Views/Home/Index.cshtml`: Razor view for the home page.

- `src/DummyEventApp.Web/Views/Shared/_Layout.cshtml`: Razor view for the shared layout, used by multiple views.

- `src/DummyEventApp.Web/wwwroot/css/site.css`: CSS styles for the website.

- `src/DummyEventApp.Web/wwwroot/js/site.js`: JavaScript code for the website.

- `src/DummyEventApp.Web/appsettings.json`: Configuration settings for the web application.

- `src/DummyEventApp.Web/Program.cs`: Entry point of the web application.

- `src/DummyEventApp.Web/Startup.cs`: Configuration for the web application's services and middleware.

- `src/DummyEventApp.Web/DummyEventApp.Web.csproj`: Project file for the web application.

- `src/DummyEventApp.Core/Entities/Event.cs`: Contains the `Event` entity class.

- `src/DummyEventApp.Core/Entities/User.cs`: Contains the `User` entity class.

- `src/DummyEventApp.Core/Entities/UserEvent.cs`: Contains the `UserEvent` entity class.

- `src/DummyEventApp.Core/Interfaces/IEventService.cs`: Defines the contract for event-related services.

- `src/DummyEventApp.Core/Services/EventService.cs`: Implements the event-related services.

- `src/DummyEventApp.Core/UseCases/CreateEventUseCase.cs`: Represents the use case for creating an event.

- `src/DummyEventApp.Core/UseCases/CreateUserUseCase.cs`: Represents the use case for creating a user.

- `src/DummyEventApp.Core/UseCases/RegisterUserEventUseCase.cs`: Represents the use case for registering a user for an event.

- `src/DummyEventApp.Core/DummyEventApp.Core.csproj`: Project file for the core library.

- `src/DummyEventApp.Infrastructure/Data/ApplicationDbContext.cs`: Contains the `ApplicationDbContext` class, which represents the database context for the application.

- `src/DummyEventApp.Infrastructure/Repositories/EventRepository.cs`: Implements the repository for events.

- `src/DummyEventApp.Infrastructure/DummyEventApp.Infrastructure.csproj`: Project file for the infrastructure library.

## Getting Started

To run the DummyEventApp project, follow these steps:

1. Clone the repository.

2. Open the `DummyEventApp.sln` solution file in Visual Studio or your preferred IDE.

3. Build the solution to restore NuGet packages and compile the project.

4. Set the `DummyEventApp.Web` project as the startup project.

5. Run the project.

## License

This project is licensed under the [MIT License](LICENSE).
```

Please note that the content provided is a template and may need to be customized based on your specific project requirements.