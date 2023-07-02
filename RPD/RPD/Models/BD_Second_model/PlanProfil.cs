using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыПрофили", Schema = "dbo")]
    public class PlanProfil
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }

         [Column("КодПлана")]
        public int? IdPlan { get; set; }

        [ForeignKey("КодООП")]
        [Column("КодООП")]
        public int? OOPId { get; set; }

         [Column("КодПодразделения")]
        public int? IdPodrazdelenie { get; set; }

         [Column("Квалификация")]
        public string? Qualification { get; set; }

        public OOP? OOP { get; set; }

    }
}
