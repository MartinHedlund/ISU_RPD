namespace RPD.Models.Home
{
    public class UchPlanForDiscipModel
    {
        public int IdUchPlan { get; set; }
        public int IdStroka { get; set; }
        //public string? Index {get;set;}  
        public string? NameFile { get;set;}
        public int? FormStudy { get;set;} // Форма обучения
        public string? Qualification { get;set;} // квалификация
        //public string Profile { get;set;} // 
        public string? OP { get;set;} // Реквизиты ОП 
        public int? ToDo { get; set; } = 0; // есть ли сделанные 
        public List<string>? UsersAccess = new List<string>();
    }
}
