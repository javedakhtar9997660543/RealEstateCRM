using System;
using System.Collections.Generic;
using AutoMapper;
using DreamWedds.CommonLayer.Application.Mappings;
using DreamWedds.PersistenceLayer.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace DreamWedds.CommonLayer.Application.DTO
{
    public class EmailsDto : IMapFrom<EmailService>
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
        public List<IFormFile> Attachments { get; set; }
        public string Remarks { get; set; }
        public int? TemplateCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmailService, EmailsDto>();
            profile.CreateMap<EmailsDto, EmailService>();
        }
    }
}
