using DocumentFormat.OpenXml.Drawing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Kafedra", Schema = "dbo")]
    public class KafedraModel
    {
        [Key]
        public int IdKafedra { get; set; }
        public int IdGosInsp { get; set; }
        public int IdFaculty { get; set; }
    }
}
