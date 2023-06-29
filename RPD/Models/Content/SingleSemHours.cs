namespace RPD.Models.Content
{
    public class SingleSemHours
    {
        public int Semestr { get; set; } = 0;

        public int SumAll { get; set; } = 0;
        public int ContactWork { get; set; } = 0;
        public int SumAuditWork { get; set; } = 0;
        public int SumSrs { get; set; } = 0; // Сам раб обучаещогося 


        public int Lek { get; set; } = 0;
        public int Pr { get; set; } = 0;
        public int Lab { get; set; } = 0;
        public int SRS { get; set; } = 0; // Проработка учебного материала
        public int ChEkz { get; set; } = 0; // промежуточная аттестация


        public int KP { get; set; } = 0; // Курсовая работа 
        public int KR { get; set; } = 0; // курсовой проект

        public List<string> Certification { get; set; } = new List<string>() { "-", "-" };

    }
}
