using RPD.Models.Rpd;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.RP_2
{
    [Table("Competence", Schema = "rpd")]
    public class Competence
    {
        public int Id { get; set; }
        public int? IdRPD { get; set; }
        public string? CodeKomp { get; set; }
        public string? NameKomp { get; set; }
        public int? IdKomp { get; set; }

        public List<Indicator>? Indicators { get; set; }
    }
}
