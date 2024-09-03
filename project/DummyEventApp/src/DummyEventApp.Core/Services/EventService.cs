using System;
using System.Collections.Generic;
using System.Linq;
using DummyEventApp.Core.Entities;
using DummyEventApp.Core.Interfaces;

namespace DummyEventApp.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public Event GetEventById(int eventId)
        {
            return _eventRepository.GetEventById(eventId);
        }

        public void CreateEvent(Event newEvent)
        {
            _eventRepository.CreateEvent(newEvent);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            _eventRepository.UpdateEvent(updatedEvent);
        }

        public void DeleteEvent(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
        }
    }
}