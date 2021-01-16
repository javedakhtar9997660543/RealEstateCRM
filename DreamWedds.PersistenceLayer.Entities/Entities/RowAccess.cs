using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class RowAccess
    {
        [Obsolete("For persistence only.")]
        public RowAccess()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RowAccess(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Key]
        [Column("ACCESSNAME")]
        public string Name { get; set; }

        [Column("ACCESSDESC")]
        public string Description { get; set; }

    }

    public static class RowAccessType
    {
        public static readonly string Case = "C";
        public static readonly string Name = "N";
    }
}
