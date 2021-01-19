using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminProject.CommonLayer.Application.DTO.CRM
{
    public class SalesInquiryDto : BaseEntity, IMapFrom<SalesInquiry>
    {
        [StringLength(100)]
        public string InquirySource { get; set; }
        public int? InquirySourceId { get; set; }
        public string Remarks { get; set; }
        public DateTime InquiryDate { get; set; }
        public UserMasterDto User { get; set; }
        public Customer Customer { get; set; }
        public int SaleStatus { get; set; } = (int)AspectEnums.SalesStaus.Warm;
        public PropertyMaster Property { get; set; }
        public virtual ICollection<PropertyFlat> Flats { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SalesInquiryDto, SalesInquiry>();
            profile.CreateMap<SalesInquiry, SalesInquiryDto>();
        }
    }
}
