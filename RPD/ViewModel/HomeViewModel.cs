using RPD.Models;
using RPD.Models.BD_model;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.BD_Second_model;
using RPD.Models.Home;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.ViewModel
{
    public class HomeViewModel
    {
        public List<MainTableUchPlan>? mainTableUchPlans { get; set; } = new();
        public bool IsZafKaf {get; set;}
        public List<UserRole>? Permision { get; set; }
        public int SelectYear { get; set; }
        public int SelectDiscipID { get; set; }
        public int SelectDepartamentID { get; set; }
        public int SelectUcPlanID { get; set; }
        public List<DiscipModel>? discipModel { get; set; }
        public KafedraMmisModel KafedraMmisModel { get; set; }
        public List<DepartmentModel>? departmentModels { get; set; }
        public List<UchPlanSelectedModel>? uchPlanSelectedModels { get; set; }
        public UserMoodleProfile UserModel { get; set; }
        public List<string> Yaers { get; set; }
        public string Year { get;set; }
        public List<DiscipKafModel>? discipKafModels { get; set;}
    }
}
