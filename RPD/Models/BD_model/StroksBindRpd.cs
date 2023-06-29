using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("StroksBindRpd", Schema = "rpd")]

    public class StroksBindRpd
    {
        [Key]
        public int Id { get; set; }
        public int IdRpd { get; set; }
        public int IdStroka { get; set; }
    }
}
