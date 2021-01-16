using DreamWedds.PersistenceLayer.Entities.Common;
namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class UserRoles : BaseEntity, IAggregateRoot
    {
        public int RoleId { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
        public virtual RoleMaster Role { get; set; }
        public virtual UserMaster User { get; set; }
    }
}
