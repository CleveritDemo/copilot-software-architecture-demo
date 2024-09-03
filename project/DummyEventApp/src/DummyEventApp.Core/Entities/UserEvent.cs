namespace DummyEventApp.Core.Entities
{
    public class UserEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
        // Add any additional properties or methods here
    }
}