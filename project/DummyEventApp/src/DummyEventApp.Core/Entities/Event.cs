using System;

namespace DummyEventApp.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        // Add any additional properties for the Event entity

        // Add any navigation properties if needed
    }
}