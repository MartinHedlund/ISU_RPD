using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Stroka", Schema = "UP")]
    [Keyless]
    public class StrokaModel
    {
        public int IdUchPlan { get; set; }
        public int IdDiscip { get; set; }
        public int IdKafedra { get; set; }
        public string? Index { get; set; }
    }
}
