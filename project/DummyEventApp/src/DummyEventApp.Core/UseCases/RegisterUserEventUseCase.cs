using System;

namespace DummyEventApp.Core.UseCases
{
    public class RegisterUserEventUseCase
    {
        private readonly IEventService _eventService;

        public RegisterUserEventUseCase(IEventService eventService)
        {
            _eventService = eventService;
        }

        public void Execute(User user, Event @event)
        {
            // Check if the user is already registered for the event
            if (user.IsRegisteredForEvent(@event))
            {
                throw new InvalidOperationException("User is already registered for the event.");
            }

            // Register the user for the event
            user.RegisterForEvent(@event);

            // Update the event's registration count
            @event.IncrementRegistrationCount();

            // Save the changes
            _eventService.UpdateEvent(@event);
        }
    }
}