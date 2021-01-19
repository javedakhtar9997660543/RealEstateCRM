using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.CommonLayer.Aspects.Security;
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
    public class CustomerDto : BaseEntity, IMapFrom<Customer>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        [Required]
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
        public virtual ICollection<UploadedDocumentDto> UploadedDocuments { get; set; }
        public virtual ICollection<AddressMasterDto> Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => EncryptionEngine.DecryptString(s.Email)))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => EncryptionEngine.DecryptString(s.UserName)))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => EncryptionEngine.DecryptString(s.Password)));
            profile.CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => EncryptionEngine.EncryptString(s.Email)))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => EncryptionEngine.EncryptString(s.UserName)))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => EncryptionEngine.EncryptString(s.Password)));
        }
    }
}
