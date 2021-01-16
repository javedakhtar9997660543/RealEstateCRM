using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class Permissions : BaseEntity, IAggregateRoot
    {
        [Obsolete("For persistence only.")]
        public Permissions()
        {
        }

        public Permissions(string objectTable, byte grantPermission, byte denyPermission)
        {
            ObjectTable = objectTable;
            GrantPermission = grantPermission;
            DenyPermission = denyPermission;
        }

        [Key]
        [Column(Order = 1)]
        public override int Id { get; set; }

        [Column("OBJECTTABLE")]
        public string ObjectTable { get; set; }

        [Column("OBJECTINTEGERKEY")]
        public int? ObjectIntegerKey { get; set; }

        [Column("OBJECTSTRINGKEY")]
        public string ObjectStringKey { get; set; }

        [Column("LEVELTABLE")]
        public string LevelTable { get; set; }

        [Column("LEVELKEY")]
        public int? LevelKey { get; set; }

        [Column("GRANTPERMISSION")]
        public byte GrantPermission { get; set; }

        [Column("DENYPERMISSION")]
        public byte DenyPermission { get; set; }
    }
}
