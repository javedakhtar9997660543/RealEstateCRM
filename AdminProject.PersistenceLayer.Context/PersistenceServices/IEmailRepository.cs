using System.Threading.Tasks;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Entities;

namespace AdminProject.PersistenceLayer.Repository.PersistenceServices
{
    public interface IEmailRepository
    {
        Task<int> SubmitContactUs(ContactUs model);
        Task<EmailTemplate> GetEmailWithFieldsAsync(AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code);
    }
}
