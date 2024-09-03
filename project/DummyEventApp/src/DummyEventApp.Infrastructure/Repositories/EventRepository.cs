using DummyEventApp.Core.Entities;
using DummyEventApp.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DummyEventApp.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _dbContext.Events.ToList();
        }

        public Event GetEventById(int eventId)
        {
            return _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
        }

        public void AddEvent(Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(Event updatedEvent)
        {
            _dbContext.Events.Update(updatedEvent);
            _dbContext.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            var eventToDelete = _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}