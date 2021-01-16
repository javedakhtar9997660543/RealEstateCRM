using System.ComponentModel.DataAnnotations;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class CompanyMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DivisionId { get; set; }
    }
}
