using System;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class OtpMaster : IAggregateRoot
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Otp { get; set; }
        public string Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Attempts { get; set; }
    }
}
