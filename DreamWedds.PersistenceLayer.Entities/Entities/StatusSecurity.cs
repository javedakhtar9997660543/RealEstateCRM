using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    [Table("USERSTATUS")]
    public class StatusSecurity
    {
        [Obsolete("For persistence only.")]
        public StatusSecurity()
        {
        }

        public StatusSecurity(string userName, short statusId, short? accessLevel)
        {
            UserName = userName;
            StatusId = statusId;
            AccessLevel = accessLevel;
        }

        [Key]
        [Column("USERID", Order = 0)]
        public string UserName { get; set; }

        [Key]
        [Column("STATUSCODE", Order = 1)]
        public short StatusId { get; set; }

        [Column("SECURITYFLAG")]
        public short? AccessLevel { get; set; }
    }
}
