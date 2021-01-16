using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class SystemSettings : BaseEntity, IAggregateRoot
    {
        public int CompanyId { get; set; }
        public int LogoutTime { get; set; }
        public int LoginFailedAttempt { get; set; }
        public int MaxLeaveMarkDays { get; set; }
        public string WeeklyOffDays { get; set; }
        public int IdleSystemDay { get; set; }

        public virtual CompanyMaster Company { get; set; }
    }
}
