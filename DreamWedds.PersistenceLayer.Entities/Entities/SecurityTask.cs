using System.ComponentModel.DataAnnotations.Schema;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    [Table("TASK")]
    public class SecurityTask : BaseEntity, IAggregateRoot
    {
        [Column("TASKNAME")]
        public string Name { get; set; }

        [Column("TASKNAME_TID")]
        public int? TaskNameTId { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("DESCRIPTION_TID")]
        public int? DescriptionTId { get; set; }
    }
}
