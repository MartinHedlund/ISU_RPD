using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using RPD.Models.BD_Second_model;
using RPD.Models.RP_2;
using RPD.Models.Rpd;
using RPD.Service;
using RPD.ViewModel;

namespace RPD.Controllers
{
    public class RP_2Controller : Controller
    {
        DbService db;
        DbSecondService secDb;
        RP_2ViewModel ViewModel;
        private readonly ILogger<HomeController> _logger;
        int IdRpd;
        public RP_2Controller(ILogger<HomeController> logger, DbService db, DbSecondService secDb)
        {
            this.db = db;
            _logger = logger;
            ViewModel = new();
            this.secDb = secDb; 
        }
        public IActionResult Index()
        {
            IdRpd = (int)HttpContext.Session.GetInt32("IdRPD");
            
            int IdStroka = db.RPD.Find(IdRpd).IdStroka;

            List<Competence> competences = db.Сompetences.Where(x => x.IdRPD == IdRpd).Include(x => x.Indicators).ThenInclude(x => x.LevelFormations).ToList();

            if (competences.Count > 0 )
            {
                ViewModel.kompet = competences;
            }
            else
            {
                List<PlanKomp> planKomps = new List<PlanKomp>();    
                List<PlanKompDiscip> k = secDb.planKompDiscips.Where(x => x.StrokaMmisModelId == IdStroka).ToList();
                foreach (PlanKompDiscip item in k)
                {
                    planKomps.Add(secDb.planKomps.Find(item.PlanKompId));
                }

                List<PlanKomp> ParentKomp =  planKomps.DistinctBy(x => x.ParentId).ToList();

                foreach (PlanKomp item in ParentKomp)
                {
                    Competence komp = secDb.planKomps.Where(x=> x.Id == item.ParentId).Select(x => new Competence
                    {
                        CodeKomp = x.ShifrKomp,
                        IdRPD = IdRpd,
                        NameKomp = x.NameKomp,
                        IdKomp = x.IdKomp
                    }).First();
               
                    komp.Indicators = secDb.planKomps.Where(x => x.ParentId == item.ParentId && planKomps.Select(y => y.Id).Contains(x.Id)).
                        Select( x => new Indicator
                        {
                            NameIndicator = x.NameKomp,
                            IdIndicator = x.Id,
                            CodeIndicator = x.ShifrKomp,
                        }).
                        ToList();
                    ViewModel.kompet.Add(komp);
                }
            }
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(RP_2ViewModel viewModel)
        {
            this.IdRpd = (int)HttpContext.Session.GetInt32("IdRPD");

            foreach (Competence Comp in viewModel.kompet)
            {
                Comp.IdRPD = IdRpd;

                foreach (Indicator indicator in Comp.Indicators)
                {
                    indicator.LevelFormations.AddRange(indicator.Know);
                    indicator.LevelFormations.AddRange(indicator.Own);
                    indicator.LevelFormations.AddRange(indicator.BeAbleTo);
                }
            }
            bool exist = db.Сompetences.Any(x => x.IdRPD == IdRpd);
            if (exist)
            {
                foreach (Competence Comp in viewModel.kompet)
                {
                    foreach (Indicator Indicator in Comp.Indicators)
                    {
                        List<LevelFormation> DbLevForm = db.LevelFormations.Where(x => x.IndicatorId == Indicator.Id).ToList();

                        foreach (LevelFormation LevForm in Indicator.LevelFormations)
                        {
                            LevelFormation LevelChek = DbLevForm.Where(x => x.NameLevelForm == LevForm.NameLevelForm).FirstOrDefault();
                            
                            if(LevelChek != null)
                            {
                                LevelChek.Result = LevForm.Result;
                                LevelChek.BelowMiddle = LevForm.BelowMiddle;
                                LevelChek.Average = LevForm.Average;
                                LevelChek.High = LevForm.High;
                                LevelChek.Low = LevForm.Low;
                            }
                            else
                            {
                                LevForm.IndicatorId = Indicator.Id;
                                db.LevelFormations.Add(LevForm);
                            }            

                        }
                        foreach (LevelFormation ChoisLevForm in DbLevForm)
                        {
                            var k = Indicator.LevelFormations.Where(x => x.NameLevelForm == ChoisLevForm.NameLevelForm).FirstOrDefault();
                            if (k == null)
                                db.LevelFormations.Remove(ChoisLevForm);
                        }
                        db.SaveChanges();

                    }

                }


            }
            else
            {
                db.Сompetences.AddRange(viewModel.kompet);
                db.SaveChanges();
            }




            return View(viewModel);
        }
    }
}
