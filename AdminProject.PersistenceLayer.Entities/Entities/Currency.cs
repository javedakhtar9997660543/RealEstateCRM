using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class Currency
    {
        public Currency()
        {

        }
        public Currency(string id)
        {
            Id = id;
        }

        [Key]
        [Column("CURRENCY")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("DESCRIPTION_TID")]
        public int? DescriptionTId { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal? SellRate { get; set; }

        [Column("DECIMALPLACES")]
        public byte? DecimalPlaces { get; set; }
    }

}
