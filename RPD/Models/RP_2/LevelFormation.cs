using Microsoft.AspNetCore.SignalR.Protocol;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.RP_2
{
    [Table("LevelFormation", Schema = "rpd")]

    public class LevelFormation
    {
        public int Id { get; set; }
        public string? NameLevelForm { get; set; } = string.Empty;
        public string? Result { get; set; } = string.Empty;
        public string? High { get; set; } = string.Empty; // Высокий
        public string? Average { get; set; } = string.Empty; // Сдедний
        public string? BelowMiddle { get; set; } = string.Empty; // Ниже среднего
        public string? Low { get; set; } = string.Empty; // Низкий
        [Column("LevelForm")]

        public int Level { get; set; }
        [Column("IdIndicator")]

        public int IndicatorId { get; set; }

        public Indicator? indicator { get; set; }
    }
}
