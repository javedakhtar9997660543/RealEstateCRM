using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class EmailTemplate : BaseEntity, IAggregateRoot
    {
        public EmailTemplate()
        {
            EmailMergeFields = new HashSet<EmailMergeFields>();
        }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string HtmlContent { get; set; }
        public string Subject { get; set; }
        public int? Cost { get; set; }
        public string AuthorName { get; set; }
        public string About { get; set; }
        public int? TemplateCode { get; set; }
        public ICollection<EmailMergeFields> EmailMergeFields { get; set; }
    }

    public class EmailMergeFields : BaseEntity, IAggregateRoot
    {
        public string FieldName { get; set; }
        public string SrcField { get; set; }
        public string SrcFieldValue { get; set; }
        public int? Sequence { get; set; }
        public int? TemplateCode { get; set; }

        [ForeignKey("EmailTemplateId")]
        public virtual EmailTemplate EmailTemplate { get; set; }
    }
}
