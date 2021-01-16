using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class UserRoleModulePermission : BaseEntity, IAggregateRoot
    {
        public int? RoleModuleId { get; set; }
        public int? UserId { get; set; }
        public int? ModuleId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionValue { get; set; }

        public virtual RoleModule RoleModule { get; set; }
    }
}
