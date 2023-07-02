using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.LiterAndRoomAndProgramm
{
    [Table("Lit", Schema = "rpd")]
    public class rpLit
    {
        [Key]
        public int IdLit { get; set; }
        public int? ExternalLitId { get; set; }
        public string? LibNumber { get; set; }
        public string? Isbn { get; set; }
        public string? LitName { get; set; }
        public string? NameProlong { get; set; }
        public string? Authors { get; set; }
        public string? Publishing { get; set; }
        public string? ImprintDate { get; set; }
        public string? Edition { get; set; }
        public int? CopiesInLib { get; set; }
        public string? Volume { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? Adress { get; set; }
        public string? Library { get; set; }
        public string? Editors { get; set; }
        public string? KeyWords { get; set; }
        public string? Rubric { get; set; }
        public bool? Deleted { get; set; }
        public bool? IsPeriodic { get; set; }
        public int? LibId { get; set; }
        public int? FileId { get; set; }
        [NotMapped]
        public bool Chois { get; set; } = false;
        [NotMapped]
        public int? Type { get; set; }
    } 
}

