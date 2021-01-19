using System;
using System.ComponentModel.DataAnnotations.Schema;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class Appointment : BaseEntity, IAggregateRoot
    {
        public string Subject { get; set; }
        public string Location { get; set; }
        public int? DurationMins { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; } = (int)AspectEnums.AppointmentStaus.Scheduled;
        public DateTime NotificationSentTime { get; set; }
        public int NotificationSentBy { get; set; }
        public string MeetingNotes { get; set; }
        [ForeignKey("UserId")]
        public UserMaster User { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
