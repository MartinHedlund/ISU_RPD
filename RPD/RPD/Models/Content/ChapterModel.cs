using RPD.Models.Material;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace RPD.Models.Content
{
    [Table("Chapter", Schema = "rpd")]
    public class Chapter
    {
        [Key]
        public int Id { get; set; }
        public int RPDId { get; set; }
        public string? NameChapter { get; set; } = string.Empty;
        public string? KompetenString { get; set;} = string.Empty;
        [NotMapped]
        public List<string>? Kompetenc { get; set; }
        public int? Lek { get; set; } = 0;
        public int? Lab { get; set; } = 0;
        public int? Pr { get; set; } = 0;
        public int? Srs { get; set; } = 0;
        public int Semestr { get; set; } = 0;
        // для меня плоя
        public int? SumBall { get; set; } = 0;
        public int? SumDopBall { get; set; } = 0;
        
        public List<EvaluationToolsOthers> EvaluationToolsOthers { get; set; } = new List<EvaluationToolsOthers>();
        public List<ThemeChapterModel> Themes { get; set; } = new List<ThemeChapterModel>();
    }
}
