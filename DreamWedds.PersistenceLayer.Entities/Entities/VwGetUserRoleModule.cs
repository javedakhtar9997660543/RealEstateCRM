using System;
using System.Collections.Generic;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public  class VwGetUserRoleModule
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int? ParentModuleId { get; set; }
        public int? UserId { get; set; }
        public DateTime? MaxModifiedDate { get; set; }
        public bool? IsMandatory { get; set; }
        public int? ModuleCode { get; set; }
        public string Icon { get; set; }
        public bool? IsStoreWise { get; set; }
        public int Sequence { get; set; }
        public string PageUrl { get; set; }
        public int ModuleType { get; set; }
        public bool IsMobile { get; set; }
        public bool IsDeleted { get; set; }
    }
}
