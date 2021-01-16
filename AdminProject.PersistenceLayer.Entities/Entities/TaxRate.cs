using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class TaxRate
    {
        public TaxRate()
        {

        }

        public TaxRate(string id)
        {
            Id = id;
        }

        [Key]
        [Column("TAXCODE")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("DESCRIPTION_TID")]
        public int? DescriptionTId { get; set; }
    }

}
