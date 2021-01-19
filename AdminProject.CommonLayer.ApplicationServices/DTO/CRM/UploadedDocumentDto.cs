using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminProject.CommonLayer.Application.DTO.CRM
{
    public class UploadedDocumentDto : BaseEntity, IMapFrom<UploadedDocument>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Document { get; set; }
        [StringLength(1000)]
        public string LocationUrl { get; set; }
        public int FileType { get; set; } = (int)AspectEnums.FileType.Pdf;
        public int DocumentType { get; set; } = (int)AspectEnums.DocumentType.IdProof;
        public int DocumentStatus { get; set; } = (int)AspectEnums.DocumentStatus.NotAvailable;
        public CustomerDto Customer { get; set; }
    }
}
