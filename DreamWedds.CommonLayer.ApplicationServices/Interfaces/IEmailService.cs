using System.Threading.Tasks;
using DreamWedds.CommonLayer.Application.DTO;
using DreamWedds.CommonLayer.Aspects.Utitlities;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.CommonLayer.Application.Interfaces
{
    public interface IEmailService
    {
        Task<int> SubmitContactUs(ContactUsDTO model);
        Task SendEmailAsync(EmailsDto mailRequest);
        Task SendAlreadyRegisteredEmail(UserMasterDto user);
        Task PrepareAndSendEmailAsync(UserMasterDto user, string otherText, AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code);
        Task<EmailTemplateDto> GetEmailTemplateAsync(AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code);
    }
}
