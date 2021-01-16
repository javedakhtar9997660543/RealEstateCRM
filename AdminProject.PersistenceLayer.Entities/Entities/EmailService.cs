using System;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class EmailService
    {
        public long Id { get; set; }
        public int TemplateId { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string CcEmail { get; set; }
        public string BccEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public bool IsHtml { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public bool IsAttachment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AttachmentFileName { get; set; }
        public string Remarks { get; set; }
        public int? TemplateCode { get; set; }
    }
}
