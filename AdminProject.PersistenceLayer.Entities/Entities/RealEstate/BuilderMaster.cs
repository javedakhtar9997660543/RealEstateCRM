using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class BuilderMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime EstablishmentYear { get; set; }
        public int CompletedProjectsCount { get; set; } = 1;
        public string Image { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<AddressMaster> Address { get; set; }
    }
}
