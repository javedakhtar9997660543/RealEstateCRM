using DreamWedds.PersistenceLayer.Entities.Common;
using System;
using System.Collections.Generic;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class RoleModule : BaseEntity, IAggregateRoot
    {
        public RoleModule()
        {
            UserRoleModulePermission = new HashSet<UserRoleModulePermission>();
        }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int Sequence { get; set; }
        public bool IsMandatory { get; set; }
        public virtual ICollection<UserRoleModulePermission> UserRoleModulePermission { get; set; }
    }
}
