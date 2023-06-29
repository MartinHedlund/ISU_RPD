using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыКомпетенции", Schema = "dbo")]
    public class PlanKomp
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }
        
        [Column("КодПлана")]
        public int UchPlanMmisModelId { get; set; }

        [Column("Номер")]
        public int? NumberKomp { get; set; }

        [Column("КодКомпетенции")]
        public int? IdKomp { get; set; }

        [Column("Наименование")]
        public string? NameKomp { get; set; }

        [Column("ШифрКомпетенции")]
        public string? ShifrKomp { get; set; }

        [Column("КодРодителя")]
        public int? ParentId { get; set; }

    }
}
