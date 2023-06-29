using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("AppRole", Schema = "secur")]
    public class AppRole
    {
        [Key]
        public int IdRole { get; set; }
        public int IdApplication { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}
