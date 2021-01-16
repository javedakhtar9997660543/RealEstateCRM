using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class TableCode
    {
        [Obsolete("For persistence only.")]
        public TableCode()
        {
        }

        public TableCode(int id, short tableTypeId, string name, string userCode = null)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A valid table code description is required.");

            Id = id;
            TableTypeId = tableTypeId;
            Name = name;
            UserCode = userCode;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("TABLECODE")]
        public int Id { get; set; }

        [Column("TABLETYPE")]
        public short TableTypeId { get; set; }

        [Column("DESCRIPTION")]
        public string Name { get; set; }

        [Column("DESCRIPTION_TID")]
        public int? NameTId { get; set; }

        [Column("USERCODE")]
        public string UserCode { get; set; }

        public virtual TableType TableType { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TableType
    {
        [Obsolete("For persistence only...")]
        public TableType()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableType(short id)
        {
            Id = id;
            TableCodes = new Collection<TableCode>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("TABLETYPE")]
        public short Id { get; set; }

        [Column("TABLENAME")]
        public string Name { get; set; }
     
        [Column("DATABASETABLE")]
        public string DatabaseTable { get; set; }

        [Column("TABLENAME_TID")]
        public int? NameTId { get; set; }

        public virtual ICollection<TableCode> TableCodes { get; protected set; }

    }

}
