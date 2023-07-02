using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis.CodeFixes;
using RPD.Models;
using RPD.Models.BD_model;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.BD_Second_model;
using RPD.Models.Home;
using RPD.Service;
using RPD.ViewModel;
using XAct;

namespace RPD.Controllers
{
    public class HomeController : Controller
    {

        HomeViewModel ViewModel;
        DbService db;
        DbSecondService secDb;

        List<PlanHours> DbPlanHours;
        List<RPDModel> DbRPD;
        List<UserDiscipModel> DbUserDiscip;
        List<StrokaMmisModel> DbStroka;
        List<CommentModel> DbComment;
        List<User> DbUsers;
        List<PlanKomp> planKomps;
        List<PlanKompDiscip> DbPlanKomp;


        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, DbService db, DbSecondService secDb)
        {
            this.db = db;
            this.secDb = secDb;
            _logger = logger;
            ViewModel = new();
            DbPlanHours = secDb.planHours.ToList();
            DbRPD = db.RPD.ToList();
            DbUserDiscip = db.userDiscipModels.ToList();
            DbComment = db.Comments.ToList();
            DbUsers = db.Users.ToList();

        }

        public ActionResult Index(string Year) // Начальная загрузка страницы
        {
            int IdPerson = (int)HttpContext.Session.GetInt32("IdPerson");
            int IdUser = (int)HttpContext.Session.GetInt32("IdUser");

            ViewData["HideNavigation"] = true;
            List<int> StroksId = new();

            ViewModel.Year = "2023-2024";

            UserMoodleProfile UserProfile = db.UserMoodleProfiles
                .Where(x => x.IdPerson == IdPerson)
                .FirstOrDefault();

            ViewModel.Permision = db.UserRoles.Where(x => x.UserId == IdUser).ToList();

            planKomps = secDb.planKomps.ToList();
            DbPlanKomp = secDb.planKompDiscips.ToList();
            List<Employee> employee = UserProfile != null ? db.Employee.Where(x => x.IdPerson == UserProfile!.IdPerson).ToList() : null;
            bool IsZafKaf = employee != null ? employee.Any(x => x.IdPosition == (int)AcademicRank.ЗавКаф && x.Stavka > 0) : false;

            if (UserProfile.UserName == "luchinkin.vl")
            {
                employee.ForEach(x => { x.IdDepartment = 20; x.IdPosition = 2; });
                employee = employee.ToList();
                IsZafKaf = true;
            }
            if (UserProfile.UserName == "emdikhanov.ra")
            {
                employee.ForEach(x => { x.IdDepartment = 20; x.IdPosition = 2; });
                employee = employee.ToList();
                IsZafKaf = true;
            }
            if (IsZafKaf)
            {
                var _idkaf = employee.FirstOrDefault(x => x.IdPosition == (int)AcademicRank.ЗавКаф).IdDepartment;
                KafedraModel Kaf = db.kafedras.FirstOrDefault(x => x.IdKafedra == _idkaf);
                KafedraMmisModel kafedraMmis = secDb.kafedraMmisModels.Where(x => x.IdKaf == Kaf.IdGosInsp).FirstOrDefault();
                StroksId = secDb.strokaMmisModels.Where(x => x.IdKaf == kafedraMmis.IdKaf && x.CheckForPlan == true).Select(x => x.Id).ToList();
                ViewModel.IsZafKaf = true;

            }
            else
            {
                ViewModel.IsZafKaf = false;
                List<int> IdStroks = DbUserDiscip.Where(x => x.IdUser == IdUser).Select(x => x.IdStroka).ToList();
                StroksId.AddRange(IdStroks);
                foreach (int Strokid in IdStroks)
                {
                    var idDisc = secDb.strokaMmisModels.Find(Strokid);
                    var YearForUchplan = secDb.uchPlanMmisModels.Find(idDisc.UchPlanMmisModelId);


                    List<StrokaUchPlanModel> StrokaUchPlanModels = secDb.uchPlanMmisModels.Join(
                       secDb.strokaMmisModels,
                       x => x.Id,
                       y => y.UchPlanMmisModelId,
                       (x, y) => new StrokaUchPlanModel
                       {
                           IdStroka = y.Id,
                           IdDiscip = y.IdDiscip,
                           NameDiscip = y.NameDiscip,
                           IdUchPlan = x.Id,
                           NameUchPlan = x.NameFile,
                           Year = x.Year,
                           FormStudy = x.FormStudy,
                           Facult = x.Facult,
                           IdKaf = y.IdKaf,
                           CheckForPlan = y.CheckForPlan,
                           Specialnost = x.Specialnost

                       }
                   ).Where(x => x.IdDiscip == idDisc.IdDiscip && x.Year == YearForUchplan.Year && (x.FormStudy == 1 || x.FormStudy == 3) && x.IdKaf == idDisc.IdKaf && x.CheckForPlan == true).ToList();

                    var thisPlan = DbPlanHours.Where(x => x.IdStroka == Strokid).ToList();
                    if (thisPlan.Count != 0 && thisPlan != null)
                        foreach (var item in StrokaUchPlanModels)
                        {
                            var AnotherPlan = DbPlanHours.Where(x => x.IdStroka == item.IdStroka).ToList();

                            if (Cheking(thisPlan, AnotherPlan) && (YearForUchplan.Facult == item.Facult) && (YearForUchplan.Specialnost.Equals(item.Specialnost)))
                            {
                                StroksId.Add(item.IdStroka);
                            }
                        }
                }



            }
            DbStroka = secDb.strokaMmisModels.Where(x => StroksId.Contains(x.Id)).ToList();

            ShowMainTablePlan(StroksId, ViewModel.Year);
            ViewModel.UserModel = UserProfile;

            ViewModel.mainTableUchPlans = ViewModel.mainTableUchPlans.OrderBy(x => x.NameDiscip).ToList();
            return View(ViewModel);
        }

        private void ShowMainTablePlan(List<int> StroksId, string Year)
        {
            List<UchPlanMmisModel> DbUchPlan = secDb.uchPlanMmisModels.Where(x => x.Year == Year && (x.FormStudy == 1 || x.FormStudy == 3)).ToList();
            List<StrokaUchPlanModel> StrokaUchPlanModels = DbUchPlan.Join(
                DbStroka,
                x => x.Id,
                y => y.UchPlanMmisModelId,
                (x, y) => new StrokaUchPlanModel
                {
                    IdStroka = y.Id,
                    IdDiscip = y.IdDiscip,
                    NameDiscip = y.NameDiscip,
                    IdUchPlan = x.Id,
                    NameUchPlan = x.NameFile,
                    Year = x.Year,
                    Facult = x.Facult,
                    Specialnost = x.Specialnost
                }
            ).Where(x => StroksId.Contains(x.IdStroka) && x.Year == Year).ToList();


            foreach (StrokaUchPlanModel StrUch in StrokaUchPlanModels)
            {

                bool flag = true;
                List<MainTableUchPlan> ChoisMains = ViewModel.mainTableUchPlans.Where(x => x.IdDiscip == StrUch.IdDiscip).ToList(); // находим элемент с листа который постпенно заполяется 
                if (ChoisMains.Count != 0)
                {
                    List<PlanHours> NewStroka = DbPlanHours.Where(x => x.IdStroka == StrUch.IdStroka).ToList();// находим планы у нового
                    foreach (var ChoisMain in ChoisMains)
                    {
                        var FacultInMainTable = DbUchPlan.Find(x => x.Id == ChoisMain.IdUchPlan);
                        var ChoisStroka = DbPlanHours.Where(x => x.IdStroka == ChoisMain.IdStroka).ToList(); // находим планы у старого
                        if (ChoisStroka.Count != 0)
                            if (Cheking(ChoisStroka, NewStroka) && (StrUch.Facult == FacultInMainTable.Facult) && (StrUch.Specialnost.Equals(FacultInMainTable.Specialnost)))// проверка на схожесть
                            {
                                flag = false;
                                var VM = ViewModel.mainTableUchPlans.Where(x => x.IdStroka == ChoisMain.IdStroka).First();
                                VM.NameUchPlan.Add(StrUch.NameUchPlan);
                                if (VM.UsersAccess.Count == 0)
                                {
                                    VM.UsersAccess = GetUserAccess(StrUch.IdStroka);
                                    if (VM.UsersAccess.Count > 0)
                                    {
                                        VM.IdStroka = StrUch.IdStroka;
                                        RPDModel rpd = DbRPD.Where(x => x.IdStroka == StrUch.IdStroka).FirstOrDefault();
                                        if (rpd == null)
                                        {
                                            VM.Status = "Не создано";
                                            VM.ChekRPD = false;
                                        }
                                        else
                                        {
                                            VM.ChekRPD = true;
                                            VM.Status = "Создано";
                                            VM.IdRpd = rpd.IdRPD;
                                        }
                                        var exist = DbUserDiscip.Where(x => x.IdStroka == VM.IdStroka).ToList();
                                        if (exist.Count != 0)
                                            VM.DateTimeCreater = exist.FirstOrDefault().СreationTimeLimits;
                                        else
                                            VM.DateTimeCreater = null;

                                    }

                                }

                            }
                    }
                    if (flag)
                        Inicial(StrUch);
                }
                else
                {
                    Inicial(StrUch);
                }
            }
        }

        private void Inicial(StrokaUchPlanModel StrUch)
        {
            MainTableUchPlan mainTable = new()
            {
                IdUchPlan = StrUch.IdUchPlan,

                IdDiscip = StrUch.IdDiscip,
                NameDiscip = StrUch.NameDiscip,
                IdStroka = StrUch.IdStroka

            };
            mainTable.NameUchPlan.Add(StrUch.NameUchPlan);

            mainTable.UsersAccess = GetUserAccess(mainTable.IdStroka); // Получаение ФИО преп. у которых есть доступ к строке


            RPDModel rpd = DbRPD.Where(x => x.IdStroka == StrUch.IdStroka).FirstOrDefault();
            if (rpd == null)
            {
                mainTable.Status = "Не создано";
                mainTable.ChekRPD = false;
            }
            else
            {
                mainTable.ChekRPD = true;
                mainTable.Status = "Создано";
                mainTable.IdRpd = rpd.IdRPD;
            }
            var exist = DbUserDiscip.Where(x => x.IdStroka == mainTable.IdStroka).ToList();
            if (exist.Count != 0)
                mainTable.DateTimeCreater = exist.FirstOrDefault().СreationTimeLimits;
            else
                mainTable.DateTimeCreater = null;
            mainTable.Comment = DbComment.Where(x => x.IdStroka == mainTable.IdStroka).OrderBy(p => p.CreatedAt).ToList();


            ViewModel.mainTableUchPlans.Add(mainTable);
        }
        private bool Cheking(List<PlanHours> ChoisStroka, List<PlanHours> NewStroka)
        {



            if (DbStroka == null)
                DbStroka = secDb.strokaMmisModels.ToList();
            var choisstr = DbStroka.Find(x => x.Id == ChoisStroka.First().IdStroka);
            var Newstr = DbStroka.Find(x => x.Id == NewStroka.First().IdStroka);
            if (choisstr != null && Newstr != null)
                if (choisstr.Komp != Newstr.Komp)
                    return false;



            if (ChoisStroka.Count != NewStroka.Count) return false;

            for (int i = 0; i < ChoisStroka.Count; i++)
            {
                if (ChoisStroka[i].Lab != NewStroka[i].Lab
                    || ChoisStroka[i].Semestr != NewStroka[i].Semestr
                    || ChoisStroka[i].Lek != NewStroka[i].Lek
                    || ChoisStroka[i].Pr != NewStroka[i].Pr
                    || ChoisStroka[i].KSR != NewStroka[i].KSR
                    || ChoisStroka[i].SRS != NewStroka[i].SRS
                    || ChoisStroka[i].ChEkz != NewStroka[i].ChEkz
                    || ChoisStroka[i].KP != NewStroka[i].KP
                    || ChoisStroka[i].KR != NewStroka[i].KR
                    || ChoisStroka[i].Ekzamen != NewStroka[i].Ekzamen
                    || ChoisStroka[i].Zachet != NewStroka[i].Zachet
                    || ChoisStroka[i].ZachetO != NewStroka[i].ZachetO
                    )
                    return false;
            }

            List<int> PlaKompChoisStroka = DbPlanKomp.Where(x => x.StrokaMmisModelId == choisstr.Id).Select(x => x.PlanKompId).ToList();
            List<int> PlanKompNewStroka = DbPlanKomp.Where(x => x.StrokaMmisModelId == Newstr.Id).Select(x => x.PlanKompId).ToList();
            List<int> AllKomp = new();
            AllKomp.AddRange(PlanKompNewStroka);
            AllKomp.AddRange(PlaKompChoisStroka);



            for (int i = 0; i < PlaKompChoisStroka.Count; i++)
            {
                PlanKomp ChoisKomp = planKomps.Find(x => x.Id == PlaKompChoisStroka[i]);
                PlanKomp NewKomp = planKomps.Find(x => x.Id == PlanKompNewStroka[i]);

                if (ChoisKomp != null && NewKomp != null)
                    if (!ChoisKomp.NameKomp.Equals(NewKomp.NameKomp))
                        return false;
            }

            return true;
        }
        private List<string> GetUserAccess(int IdStroka)
        {
            List<string> UsersFIO = new();
            List<int> IdUsers = DbUserDiscip.Where(x => x.IdStroka == IdStroka).Select(x => x.IdUser).ToList();
            foreach (int IdUser in IdUsers)
            {
                var FIO = DbUsers.Find(x => x.UserId == IdUser);
                string fio = FIO.LastName + " " + FIO.FirstName + " " + FIO.ParentName;
                UsersFIO.Add(fio);
            }
            return UsersFIO;
        }

        public ActionResult AccessUchPlan(int IdStroka) //Част.пред. Вывод модального окна для предоставления доступа
        {
            try
            {
                HomeUsersAccessViewModel homeUsersAccess = new();
                if (IdStroka == null)
                    return PartialView();

                homeUsersAccess.strokaMmisModel = secDb.strokaMmisModels.Find(IdStroka);

                homeUsersAccess.NameUchPlan = secDb.uchPlanMmisModels.Where(x => x.Id == homeUsersAccess.strokaMmisModel.UchPlanMmisModelId).Select(x => x.NameFile).First().ToString();

                List<User> Users = DbUsers.ToList();

                foreach (User user in Users)
                {
                    homeUsersAccess.usersAccesses.Add(new UsersAccess { Id = user.UserId, Name = user.LastName + " " + user.FirstName + " " + user.ParentName });
                }

                bool Exist = DbUserDiscip.Where(x => x.IdStroka == IdStroka).Any();
                if (Exist)
                {
                    homeUsersAccess.ChoisUsersAccess = DbUserDiscip.Where(x => x.IdStroka == IdStroka).Select(x => x.IdUser).ToList();

                    DateTime? СreationTimeLimits = DbUserDiscip.Where(x => x.IdStroka == IdStroka).FirstOrDefault().СreationTimeLimits;
                    if (СreationTimeLimits == null)
                        homeUsersAccess.СreationTimeLimits = DateTime.Now;
                    else
                        homeUsersAccess.СreationTimeLimits = (DateTime)СreationTimeLimits;
                }
                else
                    homeUsersAccess.СreationTimeLimits = DateTime.Now;



                return PartialView("AccessUchPlan", homeUsersAccess);
            }
            catch
            {
                return Ok();
            }
        }

        public ActionResult SaveChoisAccessUchPlan(int IdStroka, int[] UsersId, DateTime TimeLimits) // Част.пред. Сохранение прав доступа для выбранных Преподователей 
        {
            try
            {
                List<UserDiscipModel> userDiscipModels = new();
                foreach (var item in UsersId)
                {
                    userDiscipModels.Add(new UserDiscipModel
                    {
                        CreatedAt = DateTime.Now,
                        IdStroka = IdStroka,
                        IdUser = item,
                        IdDiscip = secDb.strokaMmisModels.Find(IdStroka).IdDiscip,
                        IdUchPlan = secDb.strokaMmisModels.Find(IdStroka).UchPlanMmisModelId,
                        СreationTimeLimits = TimeLimits
                    });
                }

                var allUserDiscip = DbUserDiscip.Where(x => x.IdStroka == IdStroka).ToList();
                foreach (var userDiscip in userDiscipModels)
                {
                    UserDiscipModel UsersChek = allUserDiscip.Where(x => x.IdUser == userDiscip.IdUser).FirstOrDefault();

                    if (UsersChek != null)
                    {
                        // Обновление существующего объекта модели данных
                        UsersChek.CreatedAt = userDiscip.CreatedAt; // Обновляем поле CreatedAt
                        UsersChek.IdDiscip = userDiscip.IdDiscip; // Обновляем поле IdDiscip
                        UsersChek.IdUchPlan = userDiscip.IdUchPlan; // Обновляем поле IdUchPlan
                        UsersChek.СreationTimeLimits = userDiscip.СreationTimeLimits;

                    }
                    else
                    {
                        db.userDiscipModels.Add(userDiscip);
                    }
                }

                // Удаление объектов модели данных, отсутствующих во входной модели
                foreach (var ChoisUser in allUserDiscip)
                {
                    var k = userDiscipModels.Where(x => x.IdUser == ChoisUser.IdUser).FirstOrDefault();
                    if (k == null)
                        db.userDiscipModels.Remove(ChoisUser);
                }


                // Сохранение изменений в базе данных
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return Ok();
        }


        [HttpPost]
        public ActionResult CreateRPD(int Id) // Создание РПД
        {
            StrokaMmisModel StrokaMmis = secDb.strokaMmisModels.Find(Id);
            RPDModel NewRpd = new()
            {
                IdDiscip = StrokaMmis.IdDiscip,
                IdUchPlan = StrokaMmis.UchPlanMmisModelId,
                IdStroka = StrokaMmis.Id,
                DateCreate = DateTime.Now
            };
            db.RPD.Add(NewRpd);
            db.SaveChanges();


            List<StroksBindRpd> StroksBind = new();
            var idDisc = secDb.strokaMmisModels.Find(Id);
            var uchPlanMmis = secDb.uchPlanMmisModels.Find(idDisc.UchPlanMmisModelId);

            List<StrokaUchPlanModel> StrokaUchPlanModels = secDb.uchPlanMmisModels.Join(
               secDb.strokaMmisModels,
               x => x.Id,
               y => y.UchPlanMmisModelId,
               (x, y) => new StrokaUchPlanModel
               {
                   IdStroka = y.Id,
                   IdDiscip = y.IdDiscip,
                   NameDiscip = y.NameDiscip,
                   IdUchPlan = x.Id,
                   NameUchPlan = x.NameFile,
                   Year = x.Year,
                   FormStudy = x.FormStudy,
                   Facult = x.Facult,
                   IdKaf = y.IdKaf,
                   CheckForPlan = y.CheckForPlan,
                   Specialnost = x.Specialnost

               }
           ).Where(x => x.IdDiscip == idDisc.IdDiscip && x.Year == uchPlanMmis.Year && (x.FormStudy == 1 || x.FormStudy == 3) && x.IdKaf == StrokaMmis.IdKaf && x.CheckForPlan == true).ToList();

            var thisPlan = secDb.planHours.Where(x => x.IdStroka == Id).ToList();

            planKomps = secDb.planKomps.ToList();
            DbPlanKomp = secDb.planKompDiscips.ToList();

            foreach (var item in StrokaUchPlanModels)
            {
                var AnotherPlan = secDb.planHours.Where(x => x.IdStroka == item.IdStroka).ToList();

                if (Cheking(thisPlan, AnotherPlan) && (uchPlanMmis.Facult == item.Facult) && (uchPlanMmis.Specialnost.Equals(item.Specialnost)))
                {
                    StroksBindRpd newBinds = new()
                    {
                        IdStroka = item.IdStroka,
                        IdRpd = NewRpd.IdRPD
                    };
                    StroksBind.Add(newBinds);
                }
            }
            db.stroksBindRpds.AddRange(StroksBind);

            db.SaveChanges();
            HttpContext.Session.SetInt32("IdRPD", NewRpd.IdRPD);


            return Redirect($"/Titul/Index");
        }
        [HttpPost]
        public ActionResult OpenRPD(int Id) // Открытие РПД
        {
            int IdRpd = DbRPD.Where(x => x.IdStroka == Id).First().IdRPD;

            HttpContext.Session.SetInt32("IdRPD", IdRpd);
            var name = HttpContext.Session.GetInt32("IdRPD").ToString();


            return Redirect($"/Titul/Index");
        }
        [HttpPost]
        public ActionResult DelRPD(int IdRpd)
        {
            try
            {
                RPDModel RPD = db.RPD.Find(IdRpd);
                db.RPD.Remove(RPD);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

    }
}
