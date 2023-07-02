using RPD.Models.Content;
using RPD.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.Material
{
   [Table("EvaluationToolsOther", Schema = "rpd")]
    public class EvaluationToolsOthers
    {
        [Key]
        public int Id { get; set; }
        [Column("ChapterId")]
        [ForeignKey("ChapterId")]
        public int? ChapterId { get; set; } 
        [Column("ListAllEvaluationToolsIDId")]
        [ForeignKey("ListAllEvaluationToolsIDId")]
        public int? ListAllEvaluationToolsIDId { get; set; }
        public int? Ball { get; set; } = 0;
        public int? DopBall { get; set; } = 0;
        public int? IdRPD { get; set; }
        public Chapter? Chapter { get; set; }
        public ListAllEvaluationTools? ListAllEvaluationToolsID { get; set; }

    }
}
