using RPD.Models.BD_model.UserProfile;

namespace RPD.Models.Home
{
    public class UsersAccess
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public List<UserRole>? Roles { get; set; }
    }
   
}
