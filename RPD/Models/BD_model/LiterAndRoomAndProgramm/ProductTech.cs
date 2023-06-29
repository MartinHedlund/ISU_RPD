using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm
{
    [Table("ProductTech", Schema = "rpd")]
    public class ProductTech
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Contract { get; set; }
        public string? Licensor { get; set; }
        public string? LicenseType { get; set; }
        public int? LicenseCount { get; set; }
        public DateTime? LicenseExpiration { get; set; }
        public bool? Deleted { get; set; }
        [NotMapped]
        public bool Cheked { get; set; } = false;
    }

}
