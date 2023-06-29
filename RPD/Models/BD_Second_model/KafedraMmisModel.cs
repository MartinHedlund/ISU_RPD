using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("Кафедры", Schema = "dbo")]
    public class KafedraMmisModel
    {
        [Key]
        [Column("Код")]
        public int IdKaf { get; set; }
        
        [Column("Название")]
        public string? NameKaf { get; set; }

        [Column("Сокращение")]
        public string? DescKaf { get; set;}

        [Column("ЗавКафедрой")]
        public string? NameZavKaf { get; set; }
    }
}
