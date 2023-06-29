using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.BD_Second_model;
using RPD.Models.Home;

namespace RPD.ViewModel
{
    public class HomeUsersAccessViewModel
    {
        public List<UsersAccess> usersAccesses = new List<UsersAccess>();
        public StrokaMmisModel strokaMmisModel = new();
        public List<int> ChoisUsersAccess = new();
        public string NameUchPlan = string.Empty;
        public DateTime СreationTimeLimits = DateTime.MinValue;

    }
}
