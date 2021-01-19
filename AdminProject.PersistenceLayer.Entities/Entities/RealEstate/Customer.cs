using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Customer()
        {
            this.UploadedDocuments = new HashSet<UploadedDocument>();
        }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int AccountStatus { get; set; } = (int)AspectEnums.UserAccountStatus.Pending;
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AltMobile { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public int? ReferredByUserId { get; set; }
        public int ReferenceSource { get; set; } = (int)AspectEnums.PropertyReferenceSource.Self;
        public string Remarks { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ICollection<UploadedDocument> UploadedDocuments { get; set; }
        [ForeignKey("CustomerId")]
        [AllowNull]
        public virtual ICollection<AddressMaster> Address { get; set; }
    }
}
