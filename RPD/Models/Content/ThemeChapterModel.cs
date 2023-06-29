using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Content
{
    [Table("ThemeChapter", Schema = "rpd")]
    public class ThemeChapterModel
    {   
        [Key]
        public int Id { get; set; }
        [ForeignKey("ChapterId")]
        public int ChapterId { get; set; }
        public string NameTheme { get; set; } = string.Empty;
        public string DescTheme { get; set; } = string.Empty;

    }
}
