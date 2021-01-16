using Ardalis.Specification;
using DreamWedds.PersistenceLayer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamWedds.PersistenceLayer.Entities.Specifications
{
    public class UserRoleFilterSpecification : BaseSpecification<UserRoles>
    {
        public UserRoleFilterSpecification(int userID)
                : base(i => i.UserId == Convert.ToInt32(userID))
        {
        }
    }
}
