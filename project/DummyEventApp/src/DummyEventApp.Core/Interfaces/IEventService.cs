using System.Collections.Generic;
using System.Threading.Tasks;
using DummyEventApp.Core.Entities;

namespace DummyEventApp.Core.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<Event> CreateEvent(Event event);
        Task<Event> UpdateEvent(Event event);
        Task DeleteEvent(int eventId);
    }
}