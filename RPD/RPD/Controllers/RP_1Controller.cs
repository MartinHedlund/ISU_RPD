   using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPD.Models.BD_model;
using RPD.Models.BD_Second_model;
using RPD.Models.Content;
using RPD.Models.RP_1;
using RPD.Models.Rpd;
using RPD.Service;
using RPD.ViewModel;
using System.Linq;

namespace RPD.Controllers
{
    public class RP_1 : Controller
    {
        DbService db;
        DbSecondService secDb;
        RP_1ViewModel ViewModel;
        private readonly ILogger<HomeController> _logger;
        public RP_1(ILogger<HomeController> logger, DbService db, DbSecondService dbSecondService)
        {
            this.db = db; 
            _logger = logger;
            ViewModel = new();
            secDb = dbSecondService;
        }
        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("IdRPD", 50);
            int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
            RPDModel rpd = db.RPD.Find(Idrpd);

            int Pr = 0;
            int Lab = 0;
            int KpKr = 0;
            List<PlanHours> planH = secDb.planHours.Where(x=>x.IdStroka == rpd.IdStroka).ToList();
            foreach (PlanHours item in planH)
            {
                Pr += (int)(item.Pr??0);
                Lab += (int)(item.Lab??0);
                KpKr += (item.KR == true ? 1 : 0) + (item.KR == true ? 1 : 0);
            }

            ViewModel.Purpose = rpd.Purpose;
            ViewModel.Tasks = rpd.Tasks;
            ViewModel.Requirements = rpd.Requirements;

            ViewModel.ThemPlanLab = rpd.ThemPlanLab;
            ViewModel.ThemPlanPr = rpd.ThemPlanPr;
            ViewModel.ThemPlanKpKr = rpd.ThemPlanKpKr;

            if (Pr == 0)
            {
                ViewModel.PlanPr = false;
                ViewModel.ThemPlanPr = "Данный вид работы не предусмотрен учебным планом.";

            }
            if (Lab == 0)
            {
                ViewModel.PlanLab = false;
                ViewModel.ThemPlanLab = "Данный вид работы не предусмотрен учебным планом.";
            }
            if (KpKr == 0)
            {
                ViewModel.PlanKpKr = false;
                ViewModel.ThemPlanKpKr = "Данный вид работы не предусмотрен учебным планом.";
            }

            ViewModel.RPD = rpd;

            //ViewModel.Discip = secDb.discips.ToList();

            ViewModel.SubsequentDisciplines = rpd.SubsequentDisciplines != "" ? rpd.SubsequentDisciplines.Split("; ").ToList() : null;
            ViewModel.PreviousDisciplines = rpd.PreviousDisciplines != "" ? rpd.PreviousDisciplines.Split("; ").ToList() : null;


            List<int> Stroks = db.stroksBindRpds.Where(x => x.IdRpd == rpd.IdRPD).Select(x=>x.IdStroka).ToList();
            List<int> UchplanId = secDb.strokaMmisModels.Where(x=> Stroks.Contains(x.Id)).Select(x=>x.UchPlanMmisModelId).Distinct().ToList();
            ViewModel.Discips = secDb.uchPlanMmisModels
                .Where(x => UchplanId.Contains(x.Id))
                .Include(x => x.StrokaMmis)
                .SelectMany(x => x.StrokaMmis.Select(s => s.NameDiscip)).Distinct()
                .ToList();


                return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Save(RP_1ViewModel ViewModel)
        {
       
            try
            {
                int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");

                RPDModel rpd = db.RPD.Find(Idrpd);
                rpd.Purpose = ViewModel.Purpose;
                rpd.Tasks = ViewModel.Tasks;
                rpd.ThemPlanLab = ViewModel.ThemPlanLab;
                rpd.ThemPlanPr = ViewModel.ThemPlanPr;
                rpd.ThemPlanKpKr = ViewModel.ThemPlanKpKr;

                if (ViewModel.PreviousDisciplines.Count != 0)
                    rpd.PreviousDisciplines = string.Join("; ", ViewModel.PreviousDisciplines);

                if (ViewModel.SubsequentDisciplines.Count != 0)
                    rpd.SubsequentDisciplines = string.Join("; ", ViewModel.SubsequentDisciplines);

                db.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
