using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("UserDiscip", Schema = "rpd")]
    
    public class UserDiscipModel
    {
        [Key]
        public int Id { get; set; }    
        public int IdUchPlan { get; set; }
        public int? IdDiscip { get; set; }
        public int IdUser { get; set; }
        public int IdStroka { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? СreationTimeLimits { get; set; }

    }
}
