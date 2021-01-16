using System;
using System.Collections.Generic;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class AddressMaster : BaseEntity, IAggregateRoot
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string PinCode { get; set; }
        public int? AddressType { get; set; }
        public int? AddressStatus { get; set; }
        public int? UserId { get; set; }
        public int? OwnerType { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
    }
}
