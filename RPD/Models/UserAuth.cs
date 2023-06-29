using System.ComponentModel.DataAnnotations;

namespace RPD.Models
{
    public class UserAuth
    {
        [Required(ErrorMessage = "Неправильный логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Неправильный пароль")]
        public string Password { get; set; }
    }
}
