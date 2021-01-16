using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DreamWedds.CommonLayer.Application.Mappings;
using DreamWedds.CommonLayer.Aspects.Security;

namespace AdminProject.PresentationLayer.WebApi.Model
{
    public class LoginRequest : BaseRequest, IMapFrom<LoginRequest>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginRequest, LoginRequest>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => EncryptionEngine.EncryptString(s.Username)))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => EncryptionEngine.EncryptString(s.Password)));
        }
    }

    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
