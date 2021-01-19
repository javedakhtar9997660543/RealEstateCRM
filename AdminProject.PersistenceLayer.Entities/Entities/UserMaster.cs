
using AdminProject.PersistenceLayer.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using JetBrains.Annotations;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class UserMaster : BaseEntity, IAggregateRoot
    {
        public UserMaster()
        {
            this.DailyLoginHistory = new HashSet<DailyLoginHistory>();
            this.LoginAttemptHistories = new HashSet<LoginAttemptHistory>();
            this.UserRoles = new HashSet<UserRoles>();
            this.Appointments = new HashSet<Appointment>();
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
        public int? UserType { get; set; } = (int)AspectEnums.UserType.Employee;
        public string Phone { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("CompanyId")]
        [CanBeNull]
        public CompanyMaster Company { get; set; }
        [ForeignKey("UserId")]
        [AllowNull]
        public virtual ICollection<AddressMaster> Address { get; set; }
        public virtual ICollection<DailyLoginHistory> DailyLoginHistory { get; set; }
        public virtual ICollection<LoginAttemptHistory> LoginAttemptHistories { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
