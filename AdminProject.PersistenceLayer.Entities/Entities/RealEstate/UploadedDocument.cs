using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class UploadedDocument : BaseEntity, IAggregateRoot
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Document { get; set; }
        [StringLength(1000)]
        public string LocationUrl { get; set; }
        public int FileType { get; set; }= (int)AspectEnums.FileType.Pdf;
        public int DocumentType { get; set; } = (int)AspectEnums.DocumentType.IdProof;
        public int DocumentStatus { get; set; } = (int)AspectEnums.DocumentStatus.NotAvailable;
        public Customer Customer { get; set; }
    }
}
