using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD
{
    [Table("AuditoriyRPD", Schema = "rpd")]

    public class AuditoriyRPD
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idRpd")]
        public int idRpd { get; set; }
        [Column("Descriptions")]
        public string? Desc { get; set; }
        [Column("ListAudits")]
        public string? ListAudits { get; set; }
        [Column("TypeAudId")]
        [ForeignKey("TypeAudId")]
        public int AuditoriyId { get; set; }
        public Auditoriy Auditoriy { get; set; }
    }
}
