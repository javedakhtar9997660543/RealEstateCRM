using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;
using JetBrains.Annotations;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class SalesInquiry : BaseEntity, IAggregateRoot
    {
        public SalesInquiry()
        {
            this.Flats = new HashSet<PropertyFlat>();
            this.Appointments = new HashSet<Appointment>();
        }
        [StringLength(100)]
        public string InquirySource { get; set; }
        public int? InquirySourceId { get; set; }
        public string Remarks { get; set; }
        public DateTime InquiryDate { get; set; }
        [ForeignKey("UserId")]
        public UserMaster User { get; set; }
        [ForeignKey("CustomerId")]
        [CanBeNull]
        public Customer Customer { get; set; }
        public int SaleStatus { get; set; } = (int)AspectEnums.SalesStaus.Warm;
        [ForeignKey("PropertyId")]
        public PropertyMaster Property { get; set; }
        [ForeignKey("AppointmentId")]
        [CanBeNull]
        public virtual ICollection<PropertyFlat> Flats { get; set; }
        [ForeignKey("AppointmentId")]
        [CanBeNull]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
