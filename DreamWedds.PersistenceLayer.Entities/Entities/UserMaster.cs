
using DreamWedds.PersistenceLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class UserMaster : BaseEntity, IAggregateRoot
    {
        public UserMaster()
        {
            this.DailyLoginHistory = new HashSet<DailyLoginHistory>();
            this.LoginAttemptHistories = new HashSet<LoginAttemptHistory>();
            this.UserRoles = new HashSet<UserRoles>();
        }
        [Key]
        public override int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string EmpCode { get; set; }
        public string Email { get; set; }
        public int? AccountStatus { get; set; }
        public bool? IsActive { get; set; }
        public int? SeniorEmpId { get; set; }
        public bool? IsEmployee { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int CompanyId { get; set; }
        public CompanyMaster Company { get; set; }
        public virtual ICollection<DailyLoginHistory> DailyLoginHistory { get; set; }
        public virtual ICollection<LoginAttemptHistory> LoginAttemptHistories { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
