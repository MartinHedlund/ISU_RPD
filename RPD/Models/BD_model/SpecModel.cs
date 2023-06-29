using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Spec", Schema = "dbo")]
    [Keyless]
    public class SpecModel
    {
        public int IdSpec { get; set; }
        public string? CodeSpec { get; set; }
        public string? NSpec { get; set; }
        public Byte IdEduLevel { get; set; }
    }
}
