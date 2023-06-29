using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm
{
    [Table("Auditoriy", Schema = "rpd")]
    public class Auditoriy
    {
        [Key]
        public int Id { get; set; }
        public int TypeAudiId { get; set; }
        public string? TypeAudit { get; set; }
    }
}
