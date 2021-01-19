using System.ComponentModel.DataAnnotations;
using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class AddressMaster : BaseEntity, IAggregateRoot
    {
        [StringLength(250)]
        public string Address1 { get; set; }
        [StringLength(250)]
        public string Address2 { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        [StringLength(6)]
        public string PinCode { get; set; }
        [StringLength(50)]
        public string Landmark { get; set; }
        public int? AddressType { get; set; }
        public int? AddressStatus { get; set; }
        public int? OwnerType { get; set; }
        [StringLength(50)]
        public string Lattitude { get; set; }
        [StringLength(50)]
        public string Longitude { get; set; }
        [StringLength(1500)]
        public string GoogleMpsUrl { get; set; }
    }
}
