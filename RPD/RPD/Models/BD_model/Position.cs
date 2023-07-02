using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Position", Schema = "dbo")]
    public class Position
    {
        [Key]
        public int IdPosition { get; set; }
        public string NPosition { get; set; }
        public byte IdPositionType { get; set; }
        public short? Sort { get;set; }
    }
}
