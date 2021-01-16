using AdminProject.PersistenceLayer.Entities.Common;
using System.Collections.Generic;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class ModuleMaster : BaseEntity, IAggregateRoot
    {
        public ModuleMaster()
        {
            RoleModule = new HashSet<RoleModule>();
        }

        public string Name { get; set; }
        public int? ParentModuleId { get; set; }
        public int? ModuleCode { get; set; }
        public int Sequence { get; set; }
        public int Status { get; set; }
        public string Icon { get; set; }
        public bool? IsStoreWise { get; set; }
        public int ModuleType { get; set; }
        public string ModuleDescription { get; set; }
        public virtual ICollection<RoleModule> RoleModule { get; set; }
    }
}
