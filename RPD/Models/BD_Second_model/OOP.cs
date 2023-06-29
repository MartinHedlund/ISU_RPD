using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ООП", Schema = "dbo")]

    public class OOP
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }
        
        [Column("КодРодительскогоООП")]
        public int? IdParentOOP { get; set; }        
        
        [Column("Шифр")]
        public string? Сode { get; set; }        
        
        [Column("Название")]
        public string? CodeName { get; set; }        
        
        [Column("Префикс")]
        public string? Prefix { get; set; }

        public List<PlanProfil>? PlanProfils { get; set;}
    }
}
