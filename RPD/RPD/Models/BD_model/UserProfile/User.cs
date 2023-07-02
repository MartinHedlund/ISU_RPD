using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        [Column("IdUser")]
        public int UserId { get; set; }
        
        [Column("UserName")]
        public string? UserName { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("FirstName")]
        public string? FirstName { get; set; }
        
        [Column("ParentName")]
        public string? ParentName { get; set; }        
        [Column("Position")]
        public string? Position { get; set; }

        public int? IdPerson { get; set; }
        public UserRole? UserRole { get; set; } = new();
        public AppUserDepartment? AppUserDepartment { get; set; } = new();
    }
}
