using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RPD.Models
{
    [Table("Comments", Schema = "rpd")]
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public string? FIO { get; set; }
        public int IdStroka { get; set; }
        public string? CommentText { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
