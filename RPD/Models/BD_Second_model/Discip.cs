using DocumentFormat.OpenXml.Drawing;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыДисциплины", Schema = "dbo")]
    public class Discip
    {
        [Column("Код")]
        public int Id { get; set; }
        [Column("Дисциплина")]
        public string? NameDiscip { get; set; }
    }
}
