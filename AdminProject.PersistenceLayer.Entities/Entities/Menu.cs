using AdminProject.PersistenceLayer.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class Menu : BaseEntity, IAggregateRoot
    {
        public Menu()
        {
            this.SubMenu = new HashSet<SubMenu>();
        }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Alignment { get; set; }
        [Required]
        [StringLength(750)]
        public string Path { get; set; }
        public bool Root { get; set; }
        public int Sequence { get; set; }
        public int? Title_TId { get; set; }
        [StringLength(100)]
        public string Title_TName { get; set; }
        public int? ModuleId { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        [ForeignKey("ParentId")]
        [AllowNull]
        public virtual ICollection<SubMenu> SubMenu { get; set; }
    }

    public class SubMenu : BaseEntity, IAggregateRoot
    {
        [Required]
        [StringLength(100)]
        public string SubTitle { get; set; }
        [Required]
        [StringLength(500)]
        public string Path { get; set; }
        [StringLength(50)]
        public string Permission { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        public int? SubTitle_TId { get; set; }
        [StringLength(100)]
        public string SubTitle_TName { get; set; }
    }
}
