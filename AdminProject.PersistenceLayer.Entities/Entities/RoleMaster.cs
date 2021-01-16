using AdminProject.PersistenceLayer.Entities.Common;
using System.Collections.Generic;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class RoleMaster : BaseEntity, IAggregateRoot
    {
        public RoleMaster()
        {
            RoleModule = new HashSet<RoleModule>();
            UserRoles = new HashSet<UserRoles>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? Type { get; set; }
        public int Status { get; set; }
        public bool IsAdmin { get; set; }
        public string RoleDescription { get; set; }
        public virtual ICollection<RoleModule> RoleModule { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
