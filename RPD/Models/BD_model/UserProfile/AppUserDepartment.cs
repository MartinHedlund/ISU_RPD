using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("AppUserDepartment", Schema = "secur")]
    public class AppUserDepartment
    {
        [Key]
        public Int16 IdApplication { get; set; }
        [ForeignKey("IdUser")]
        [Column("IdUser")]
        public int UserId { get; set; } = 0;
        public int IdDepartment { get; set; }
    }
}
