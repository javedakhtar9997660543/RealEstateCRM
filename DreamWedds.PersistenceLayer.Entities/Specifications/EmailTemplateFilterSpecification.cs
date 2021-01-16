using Ardalis.Specification;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.PersistenceLayer.Entities.Specifications
{
    public class EmailTemplateFilterSpecification: BaseSpecification<EmailTemplate>
    {
        public EmailTemplateFilterSpecification(int type, int code)
            : base(i => (i.Type == type) && (i.TemplateCode == code))
        {
        }

        public EmailTemplateFilterSpecification(int type)
            : base(i => (i.Type == type))
        {
        }

        public EmailTemplateFilterSpecification(string name)
            : base(i => (i.Name == name))
        {
        }
    }
}
