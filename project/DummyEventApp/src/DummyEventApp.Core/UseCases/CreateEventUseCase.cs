using System;
using System.Threading.Tasks;
using DummyEventApp.Core.Entities;
using DummyEventApp.Core.Interfaces;

namespace DummyEventApp.Core.UseCases
{
    public class CreateEventUseCase
    {
        private readonly IEventService _eventService;

        public CreateEventUseCase(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<Event> Execute(string eventName, DateTime eventDate, string location)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentException("Event name is required.", nameof(eventName));
            }

            if (eventDate == default)
            {
                throw new ArgumentException("Event date is required.", nameof(eventDate));
            }

            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("Event location is required.", nameof(location));
            }

            // Create the event
            var newEvent = new Event
            {
                EventName = eventName,
                EventDate = eventDate,
                Location = location
            };

            // Save the event
            await _eventService.CreateEvent(newEvent);

            return newEvent;
        }
    }
}