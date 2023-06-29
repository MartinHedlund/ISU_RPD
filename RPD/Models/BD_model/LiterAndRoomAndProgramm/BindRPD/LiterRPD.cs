using DocumentFormat.OpenXml.Drawing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD
{
    [Table("LiterRPD", Schema = "rpd")]
    public class LiterRPD
    {
        [Key]
        public int Id { get; set; }
        public int IdLit { get; set; }
        public int IdRPD { get; set; }
        public int? Type { get; set; }
    }
}
