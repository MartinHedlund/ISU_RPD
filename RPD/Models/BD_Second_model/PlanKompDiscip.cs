using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыКомпетенцииДисциплины", Schema = "dbo")]

    public class PlanKompDiscip
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }

        [Column("КодСтроки")]
        public int StrokaMmisModelId { get; set; }
        [Column("КодКомпетенции")]
        public int PlanKompId { get; set; }
    }
}
