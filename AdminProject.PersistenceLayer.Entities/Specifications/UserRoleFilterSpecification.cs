using Ardalis.Specification;
using AdminProject.PersistenceLayer.Entities.Entities;
using System;

namespace AdminProject.PersistenceLayer.Entities.Specifications
{
    public class UserRoleFilterSpecification : BaseSpecification<UserRoles>
    {
        public UserRoleFilterSpecification(int userID)
                : base(i => i.UserId == Convert.ToInt32(userID))
        {
        }
    }
}
