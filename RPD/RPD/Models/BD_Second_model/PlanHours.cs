using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыЧасы", Schema = "dbo")]

    public class PlanHours
    {
        [Column("Код")]

        public int Id { get; set; }
        
        [Column("КодСтроки")]
        public int IdStroka { get; set; }
        //public int IdUchPlan { get; set; }

        [Column("Семестр")]
        public Int16? Semestr { get; set; }
        //public int IdDiscip { get; set; }
        
        [Column("Лекций")]
        public float? Lek { get; set; }

        [Column("Лабораторных")]
        public float? Lab { get; set; }
        [Column("Практик")]
        public float? Pr { get; set; }
        [Column("КСР")]
        public float? KSR { get; set; }
        [Column("СамРабота")]
        public float? SRS { get; set; }
        [Column("ЧасовНаЭкзамены")]
        public float? ChEkz { get; set; } = 0;

        [Column("КурсовойПроект")]
        public bool? KP { get; set; }

        [Column("КурсоваяРабота")]
        public bool? KR { get; set; }

        [Column("Экзамен")]
        public bool? Ekzamen { get; set; }

        [Column("Зачет")]
        public bool? Zachet { get; set; }
        
        [Column("ЗачетСОценкой")]
        public bool? ZachetO { get; set; }
    }
}
