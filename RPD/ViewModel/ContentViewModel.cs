using RPD.Models.Content;

namespace RPD.ViewModel
{
    public class ContentViewModel
    {

        //public List<ChapterModel> ContentModels { get; set; } = new();
        public List<LinkSemChapter> linkSemChapters { get; set; } = new();
        public SemHours SemHoursVM { get; set; } = new();
        public bool ClickHours { get; set; } = false;
        public List<string>? CompStrings { get; set; } = new();
    }
}
