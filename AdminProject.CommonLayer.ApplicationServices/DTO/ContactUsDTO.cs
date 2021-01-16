using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.PersistenceLayer.Entities.Entities;

namespace AdminProject.CommonLayer.Application.DTO
{
    public class ContactUsDTO : IMapFrom<ContactUs>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [StringLength(300, MinimumLength = 10)]
        public string Message { get; set; }
        public int ContactFor { get; set; } = 0;
        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactUs, ContactUsDTO>();
            profile.CreateMap<ContactUsDTO, ContactUs>();
        }
    }
}
