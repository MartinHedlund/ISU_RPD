using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("RPD", Schema = "rpd")]

    public class RPDModel
    {
        [Key]
        public int IdRPD { get; set; }
        public int IdUchPlan { get; set; }
        public int? IdDiscip { get; set; }
        public int IdStroka { get; set; }
        public DateTime DateCreate { get; set; }
        //RP-1
        public string? Purpose { get; set; } = string.Empty; // Цели освоения дисциплины (Модуля)
        public string? Tasks { get; set; } = string.Empty; // Задачи освоения дисциплины (Модуля)
        public string? Requirements { get; set; } = string.Empty; // Требования к предварительной подготовке обучающегося

        public string? SubsequentDisciplines { get; set; } = string.Empty;
        public string? PreviousDisciplines { get; set; } = string.Empty;
        public string? ThemPlanLab { get; set; } = string.Empty;
        public string? ThemPlanPr { get; set; } = string.Empty;
        public string? ThemPlanKpKr { get; set; } = string.Empty;

    }
}