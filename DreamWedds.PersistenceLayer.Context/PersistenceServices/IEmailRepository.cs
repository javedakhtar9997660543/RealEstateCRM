using System.Threading.Tasks;
using DreamWedds.CommonLayer.Aspects.Utitlities;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.PersistenceLayer.Repository.PersistenceServices
{
    public interface IEmailRepository
    {
        Task<int> SubmitContactUs(ContactUs model);
        Task<EmailTemplate> GetEmailWithFieldsAsync(AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code);
    }
}
