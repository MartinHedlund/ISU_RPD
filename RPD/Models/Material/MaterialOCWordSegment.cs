using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Material
{
    [Table("MaterialOCWordSegment", Schema = "rpd")]
    public class MaterialOCWordSegment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int? SerialNumber { get; set; }
        public byte[] WordData { get; set; }
        public int IdRpd { get; set; }
        
    }
}
