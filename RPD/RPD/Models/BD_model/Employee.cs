using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Employee", Schema = "site")]
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public int IdDepartment { get; set; }
        public int IdPerson { get; set; }
        public int IdPosition { get; set; }
        public short? Sort { get; set; }
        public byte IdJobType { get; set; }
        public bool IsInShtat { get; set; }
        public decimal Stavka { get; set; }
    }
 
}
