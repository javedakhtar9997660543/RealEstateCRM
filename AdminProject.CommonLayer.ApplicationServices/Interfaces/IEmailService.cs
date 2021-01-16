using System.Threading.Tasks;
using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Aspects.Utitlities;

namespace AdminProject.CommonLayer.Application.Interfaces
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
