using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.RP_2
{
    [Table("Indicator", Schema = "rpd")]

    public class Indicator
    {
        public int Id { get; set; }

        public int? IdIndicator { get; set; }
        public string? NameIndicator { get; set; }
        public string? CodeIndicator { get; set; }
        [Column("IdCompetence")]

        public int CompetenceId { get; set; }
        public List<LevelFormation>? LevelFormations { get; set; } = new();

        [NotMapped]
        public List<LevelFormation>? Know { get; set; }
        [NotMapped]
        public List<LevelFormation>? BeAbleTo { get; set; }
        [NotMapped] 
        public List<LevelFormation>? Own { get; set; }


        public Competence? сompetence { get; set; }

    }
}
