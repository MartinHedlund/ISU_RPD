namespace RPD.Models.Rpd
{
  
    public class Komp
    {
        public int Id { get; set; }
        public int? IdKomp { get; set; }
        public string? CodeKomp { get; set; }
        public string? NameKomp { get; set; }
        public List<KompDes>? PodKomp { get; set; }

    }
    public class KompDes
    {
        public int Id { get; set; }
        public int? IdPodKomp { get; set; }
        public string? NamePodKomp { get; set; }
        public string? CodePodKomp { get; set; }
        public string? Know { get; set; } = "";
        public string? BeAbleTo { get; set; } = "";
        public string? Own { get; set; } = "";
        
        public int KompId { get; set; }


    }
}
