namespace RPD.Models.Content
{
    public class SemHours
    {
        public int SumAllSemHours { get; set; } = 0;
        public int SumAllSrs { get; set; } = 0; // Сам раб обучаещогося 
        public int  SumAllAuditWork { get; set; } = 0;
        public int SumAllContactWork { get; set; } = 0;
       
        public int SumLek { get; set; } = 0;
        public int SumPr { get; set; } = 0;
        public int SumLab { get; set; } = 0;
        
       
        
        public int SumSRS { get; set; } = 0; // Проработка учебного материала
        public int SumKP { get; set; } = 0; // Курсовая работа 
        public int SumKR { get; set; } = 0; // курсовой проект

        public int SumChEkz { get; set; } = 0; // промежуточная аттестация

        public List<SingleSemHours> SingleSemHour = new();    


    }
}
