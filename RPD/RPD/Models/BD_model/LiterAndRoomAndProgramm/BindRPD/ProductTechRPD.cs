using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD
{
    [Table("ProductTechRPD", Schema = "rpd")]

    public class ProductTechRPD
    {
        [Key]
        public int Id { get; set; }
        [Column("IdProductTech")]
        [ForeignKey("IdProductTech")]
        public int ProductTechId { get; set; }
        public ProductTech? ProductTech { get; set; }
        [ForeignKey("IdRPD")]
        public int IdRPD { get; set; }
    }
}
