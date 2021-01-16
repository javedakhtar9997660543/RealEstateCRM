using System;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class LoginAttemptHistory
    {
        public long Id { get; set; }
        public int? FailedAttempt { get; set; }
        public int UserId { get; set; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public virtual UserMaster User { get; set; }
    }
}
