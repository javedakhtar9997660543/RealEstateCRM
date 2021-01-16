using System;
using System.Collections.Generic;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class CommonSetup : IAggregateRoot
    {
        public int Id { get; set; }
        public string MainType { get; set; }
        public string SubType { get; set; }
        public string DisplayText { get; set; }
        public int DisplayValue { get; set; }
        public int ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
