using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DreamWedds.CommonLayer.Application.Mappings;
using DreamWedds.PersistenceLayer.Entities;
using DreamWedds.PersistenceLayer.Entities.Common;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.CommonLayer.Application.DTO
{
    public class EmailTemplateDto : BaseEntity, IMapFrom<EmailTemplate>
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string HtmlContent { get; set; }
        public string Subject { get; set; }
        public int? Cost { get; set; }
        public string AuthorName { get; set; }
        public string About { get; set; }
        public int? TemplateCode { get; set; }
        public ICollection<EmailMergeFieldsDto> EmailMergeFields { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmailTemplate, EmailTemplateDto>();
            profile.CreateMap<EmailTemplateDto, EmailTemplate>();
        }
    }

    public class EmailMergeFieldsDto : BaseEntity, IMapFrom<EmailMergeFields>
    {
        public string FieldName { get; set; }
        public string SrcField { get; set; }
        public string SrcFieldValue { get; set; }
        public int? Sequence { get; set; }
        public int? TemplateCode { get; set; }
        public virtual EmailTemplate EmailTemplate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmailMergeFields, EmailMergeFieldsDto>();
            profile.CreateMap<EmailMergeFieldsDto, EmailMergeFields>();
        }
    }
}
