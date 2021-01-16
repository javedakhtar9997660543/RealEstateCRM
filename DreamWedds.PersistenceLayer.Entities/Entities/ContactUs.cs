using System;
using System.Collections.Generic;
using System.Text;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
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
