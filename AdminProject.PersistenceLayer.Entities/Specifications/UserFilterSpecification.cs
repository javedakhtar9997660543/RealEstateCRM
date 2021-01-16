using Ardalis.Specification;
using AdminProject.PersistenceLayer.Entities.Entities;


namespace AdminProject.PersistenceLayer.Entities.Specifications
{
    public class UserFilterSpecification : BaseSpecification<UserMaster>
    {
        public UserFilterSpecification(string userName, string password)
           : base(i => (i.Email == userName) && (i.Password == password))
        {
        }

        public UserFilterSpecification(string userName)
           : base(i => (i.Email == userName))
        {
        }

        public UserFilterSpecification(int id)
            : base(i => (i.Id == id))
        {
        }
    }
}
