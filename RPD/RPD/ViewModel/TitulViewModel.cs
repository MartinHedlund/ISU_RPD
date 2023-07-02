using RPD.Models.BD_model;
using RPD.Models.BD_Second_model;
using RPD.Models.Titul;
using System.Security.Cryptography.X509Certificates;

namespace RPD.ViewModel
{
    public class TitulViewModel
    {
        public RPDModel? RPD { get; set; } = new();
        public TitulModel? Titul { get; set; } = new();
        public StrokaMmisModel? strokaMmis { get; set; } = new();
        public List<UchPlan>? uchPlans { get; set; } = new();
        public List<UserDev> userDevs { get; set; }= new(); 
        public List<PersonsAgreement> persons { get; set; } = new();
       
    }
}
