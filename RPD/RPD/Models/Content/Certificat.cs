using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Content
{
    [Table("Certification", Schema = "rpd")]
    public class Certificat
    {
        [Key]
        public int Id { get; set; }
        public int IdRPD { get; set; }
        public int? Semestr { get; set; }
        public string? NameCert { get; set; }
        public int Hoirs { get; set; } = 0;
        public string? KompString { get; set; }
        [NotMapped]
        public List<string> KompList { get; set; } = new();
    }
}
