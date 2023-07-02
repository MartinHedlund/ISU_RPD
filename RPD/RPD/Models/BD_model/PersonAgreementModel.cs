using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("PersonAgreement", Schema = "rpd")]

    public class PersonAgreementModel
    {
        [Key]
        public int Id { get; set; }
        public int IdRpd { get; set; }
        public int IdPerson { get; set; }
        public int IdDepartament { get; set; }
        public int Type { get; set; }
        public string? NumberAgree { get; set; }
        public DateTime? DateAgree { get; set; }
    }
}
