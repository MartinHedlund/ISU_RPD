using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Material
{
    [Table("ListAllEvaluationTools", Schema = "rpd")]
    public class ListAllEvaluationTools
    {
        [Key]
        public int Id { get; set; }
        public string? NameEvaluation { get; set; }
        public string? Abbreviation { get; set; }
        public string? Kharakter { get; set; }
        public string? EvaluationType { get; set; }
    }
}
