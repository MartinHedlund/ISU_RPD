using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using RPD.Models.Home;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("UserRole", Schema = "secur")]
    public class UserRole
    {
        
        [Column("IdUser", Order = 0)]
        public int UserId { get; set; } = 0;

        
        [Column("IdRole", Order = 1)]
        public int IdRole { get; set; } = 0;
    }
}
