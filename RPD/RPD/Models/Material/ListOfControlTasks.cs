using RPD.Models.Content;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Material
{
    [Table("ListOfControlTasks", Schema = "rpd")]
    public class ListOfControlTasks
	{
        public int Id { get; set; }
		public int? ChapterIDid { get; set; }
		public Chapter? ChapterID { get; set; }
        public string? StrokaHTML { get; set; }	
    }

    public class ContentItem
    {
        public int ChapterId { get; set; }
        public string Content { get; set; }
    }
}
