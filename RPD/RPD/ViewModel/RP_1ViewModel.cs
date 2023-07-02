using RPD.Models.BD_model;
using RPD.Models.BD_Second_model;
using RPD.Models.RP_1;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.ViewModel
{
    public class RP_1ViewModel
    {
        public RPDModel? RPD { get; set; } = new();
        //public List<Discip>? Discip { get; set; } = new();
        public List<string>? SubsequentDisciplines { get; set; } = new();
        public List<string>? PreviousDisciplines { get; set; } = new();
        public List<string>? Discips { get; set; } = new();

        public string? Purpose { get; set; } = string.Empty; // Цели освоения дисциплины (Модуля)
        public string? Tasks { get; set; } = string.Empty; // Задачи освоения дисциплины (Модуля)
        public string? Requirements { get; set; } = string.Empty; // Требования к предварительной подготовке обучающегося

        public string? ThemPlanLab { get; set; } = string.Empty;
        public bool PlanLab { get; set; } = true;

        public string? ThemPlanPr { get; set; } = string.Empty;
        public bool PlanPr { get; set; } = true;

        public string? ThemPlanKpKr { get; set; } = string.Empty;
        public bool PlanKpKr { get; set; } = true;

    }

}
