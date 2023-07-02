namespace RPD.Models.Content
{
    public class LinkSemChapter
    {
        public int Semestr { get; set; }
        public List<Chapter> chapterModels { get; set; }=new List<Chapter>();
        public List<Certificat> certificat { get; set; } = new(); 
    }
}
