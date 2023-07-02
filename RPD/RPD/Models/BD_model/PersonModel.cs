using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Person", Schema = "site")]
    public class PersonModel
    {
        [Key]
        public int IdPerson { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? PName { get; set; }
        public string? UchStepen { get; set; }
        public string? UchZvanie { get; set; }
 

    }
}
