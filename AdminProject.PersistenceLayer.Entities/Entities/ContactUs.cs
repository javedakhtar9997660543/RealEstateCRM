using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class ContactUs : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public int ContactFor { get; set; } = 0;
    }
}
