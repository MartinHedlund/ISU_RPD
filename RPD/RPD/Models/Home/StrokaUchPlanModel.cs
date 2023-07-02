namespace RPD.Models.Home
{
    public class StrokaUchPlanModel
    {
        public int IdStroka { get;set;}
        public int? IdDiscip { get;set;}
        public int IdUchPlan { get;set;}
        public string? NameDiscip { get;set;}
        public string? NameUchPlan { get;set;}
        public string? Year { get;set;}
        public int? FormStudy { get; set; }
        public int? Facult { get; set; }
        public int? IdKaf { get; set; }
        public bool? CheckForPlan { get; set; }
        public string Specialnost { get; set; }




    }
}
