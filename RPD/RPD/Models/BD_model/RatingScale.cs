using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("RatingScale", Schema = "rpd")]
    public class RatingScale
    {
        public int Id { get; set; }
        public int IdRpd { get; set; }
        public string? Excellent { get; set; }
        public string? Good { get; set; }
        public string? Satisfactory { get; set; }
        public string? UnSatisfactory { get; set; }

    }
}
