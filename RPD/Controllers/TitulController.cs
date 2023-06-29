using Microsoft.AspNetCore.Mvc;
using RPD.Models.Titul;
using RPD.Service;
using RPD.ViewModel;
using Microsoft.AspNetCore.Session;
using System.Xml;
using Newtonsoft.Json;
using RPD.Models.BD_model;
using RPD.Models.BD_Second_model;
using Microsoft.EntityFrameworkCore;

using XAct;
using TemplateEngine.Docx;
using RPD.Models.RP_2;

using RPD.Models.Content;

using NuGet.Packaging;
using Xceed.Words.NET;
using Xceed.Document.NET;
using RPD.Models;
using NonFactors.Mvc.Grid;
using DocumentFormat.OpenXml.Spreadsheet;
using Table = Xceed.Document.NET.Table;
using Alignment = Xceed.Document.NET.Alignment;
using DocumentFormat.OpenXml.Drawing;
using Path = System.IO.Path;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Paragraph = Xceed.Document.NET.Paragraph;
using DocumentFormat.OpenXml.Office2010.Word.Drawing;

namespace RPD.Controllers
{
    public class TitulController : Controller
    {
        RPDModel rpd;
        List<StrokaMmisModel> AllStroks;
        StrokaMmisModel Stroka;
        UchPlanMmisModel UchPlan;
        List<Competence> Kompetens;
        List<Chapter> Chapters;
        List<PlanHours> planHours;

        DbService db;
        DbSecondService secDb;
        TitulViewModel ViewModel;
        private readonly ILogger<HomeController> _logger;
        public TitulController(ILogger<HomeController> logger, DbService db, DbSecondService dbSecond)
        {
            this.db = db;
            this.secDb = dbSecond;
            _logger = logger;
            ViewModel = new();
        }
        public IActionResult Index()
        {
            try
            {
                int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
    
                RPDModel Rpd = db.RPD.Find(Idrpd);

                ViewModel.strokaMmis = secDb.strokaMmisModels.Find(Rpd.IdStroka);

                ViewModel.Titul.NameKaf = secDb.kafedraMmisModels.Find(ViewModel.strokaMmis.IdKaf).NameKaf;

                List<int> IdStroksBind = db.stroksBindRpds.Where(x => x.IdRpd == Rpd.IdRPD).Select(x => x.IdStroka).ToList();
                List<int> IdUchPlans = secDb.strokaMmisModels.Where(x => IdStroksBind.Contains(x.Id)).Select(x => x.UchPlanMmisModelId).ToList();

                var K = secDb.uchPlanMmisModels.Where(x => IdUchPlans.Contains(x.Id)).Include(x => x.StrokaMmis.Where(x => IdStroksBind.Contains(x.Id))).ToList();

                foreach (int IdUchPlan in IdUchPlans)
                {
                    UchPlan uchPlan = new UchPlan();

                    uchPlan.planProfil = secDb.OOPs
                                    .Include(x => x.PlanProfils.Where(x => x.IdPlan == IdUchPlan)) // Загружаем связанные сущности PlanProfils
                                    .Where(x => x.PlanProfils.Count != 0 && x.PlanProfils.Any(p => p.IdPlan == IdUchPlan)) // Фильтруем по наличию PlanProfils с нужным значением IdPlan
                                    .First().PlanProfils.First();

                    uchPlan.uchMmisPlans = secDb.uchPlanMmisModels.Find(uchPlan.planProfil.IdPlan);
                    switch (uchPlan.uchMmisPlans.FormStudy)
                    {
                        case 1:
                            uchPlan.FormStudy = "Очное";
                            break;
                        case 2:
                            uchPlan.FormStudy = "Заочное";
                            break;
                    }

                    ViewModel.uchPlans.Add(uchPlan);
                    //ViewModel.planProfil = OOp.PlanProfils.First();
                }

                GetDeveloper(Rpd);

                List<PersonAgreementModel> personAgreements = db.personAgreementModels.Where(x => x.IdRpd == Idrpd).ToList();
                if (personAgreements.Count == 0)
                    GetGlavUser(Rpd);
                else
                    GetGlavExistUser(personAgreements);

            }
            catch
            {
                Console.WriteLine("ERORR");
            }

            return View(ViewModel);
        }

        void GetGlavUser(RPDModel Rpd)
        {
            List<PersonsAgreement> Persons = new();
            int IdKafDev = db.kafedras.Where(x => x.IdGosInsp == (int)ViewModel.strokaMmis.IdKaf).Select(x => x.IdKafedra).FirstOrDefault();
            if (IdKafDev != null)
            {
                var Dep = db.departments.Find(IdKafDev);// сокращенная наименование кафедры

                int IdPosDev = db.Employee.Where(x => x.IdDepartment == IdKafDev && x.IdPosition == 2).Select(x => x.IdPerson).FirstOrDefault();
                PersonModel person = db.Persons.Find(IdPosDev);
                Persons.Add(new PersonsAgreement(person, Dep, 1));
               
            }

            Console.WriteLine(Persons.First().FIO);
            List<int?> IdKafVipusk = ViewModel.uchPlans.Select(x => x.uchMmisPlans.IdKaf).ToList();
            List<int> IdKaVipusk = db.kafedras.Where(x => IdKafVipusk.Contains(x.IdGosInsp)).Select(x => x.IdKafedra).ToList();
            if (IdKaVipusk.Count != 0)
            {
               
                var IdPosDev = db.Employee.Where(x => IdKaVipusk.Contains(x.IdDepartment) && x.IdPosition == 2).ToList();

                var Dep = new DepartmentModel();
                var Pers = new  PersonModel();
                foreach (var item in IdPosDev)
                {
                    Dep = db.departments.Find(item.IdDepartment);
                    Pers = db.Persons.Find(item.IdPerson);
                    Persons.Add(new PersonsAgreement(Pers, Dep, 2));
                }
                
                            
            }


            int IdInst = db.kafedras.Find(IdKaVipusk.First()).IdFaculty;
            var Inst = db.departments.Find(IdInst);// сокращенная наименование кафедры
            int IdPosInst = db.Employee.Where(x => x.IdDepartment == IdInst && x.IdPosition ==1148).First().IdPerson;
            PersonModel personInst = db.Persons.Where(x => x.IdPerson==IdPosInst).First();
            Persons.Add(new PersonsAgreement(personInst,Inst,3));
            Persons.Add(new PersonsAgreement(personInst, Inst, 4));


            ViewModel.persons = Persons;

        }
        void GetDeveloper(RPDModel Rpd)
        {
            List<int> IdUsers = db.userDiscipModels.Where(x => x.IdStroka == Rpd.IdStroka).Select(x => x.IdUser).ToList();
            List<int?> IdPersons = db.Users.Where(x => IdUsers.Contains(x.UserId)).Select(x => x.IdPerson).ToList();

            Employee emp = new();
            foreach (int IdPerson in IdPersons)
            {
                List<string> Positions = new List<string>();
                UserDev userDev = new();
                var FIO = db.UserMoodleProfiles.Where(x => x.IdPerson == IdPerson).FirstOrDefault();
                //emp = db.Employee.Where(x => x.IdPerson == IdPerson && x.Stavka > 0).OrderByDescending(x => x.Stavka).FirstOrDefault();
                // установка отоброжаемой должности 


                var valuesToCheck = new[] {
                        (int)AcademicRank.ЗавКаф,
                        (int)AcademicRank.Доцент,
                        (int)AcademicRank.Профессор,
                        (int)AcademicRank.СтПреподаватель,
                        (int)AcademicRank.Преподаватель};

                emp = db.Employee.Where(x => x.IdPerson == IdPerson && x.Stavka > 0 && valuesToCheck.Contains(x.IdPosition)).FirstOrDefault();


                if (emp != null)
                {
                    Positions.Add(db.Positions.FirstOrDefault(x => x.IdPosition == emp.IdPosition).NPosition);
                }
                else
                {
                    Positions.Add(" ");
                }

                if (FIO != null)
                {
                    string fio = FIO.LastName + " " + FIO.FirstName + " " + FIO.ParentName;
                    userDev.Fio = fio;
                    userDev.Position = string.Join(", ", Positions);
                    ViewModel.userDevs.Add(userDev);
                }
            }
        }
        void GetGlavExistUser(List<PersonAgreementModel> Persons)
        {
            List<PersonsAgreement> personsAgreements = new();
            foreach (var Pers in Persons)
            {
                DepartmentModel Dep = db.departments.Find(Pers.IdDepartament);
                PersonModel personModel = db.Persons.Find(Pers.IdPerson);
                PersonsAgreement personsAgreement = new PersonsAgreement(Pers, Dep, personModel);
                personsAgreements.Add(personsAgreement);
            }
            ViewModel.persons = personsAgreements;
        }

        [HttpPost]
        public ActionResult SavePersonAgreement(List<PersonAgreementModel> Persons)
        {
            try
            {
                int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
                Persons.ForEach(x => x.IdRpd = Idrpd);

                List<PersonAgreementModel> personAgreements = db.personAgreementModels.Where(x => x.IdRpd == Idrpd).ToList();
                if (personAgreements.Count == 0)
                {
                    db.personAgreementModels.AddRange(Persons);
                }
                else
                {
                    foreach (var PersonAgree in personAgreements)
                    {
                        var person = Persons.Where(x => x.IdPerson == PersonAgree.IdPerson && x.Type == PersonAgree.Type && x.IdDepartament == PersonAgree.IdDepartament).FirstOrDefault();

                        if (person != null)
                        {
                            PersonAgree.NumberAgree = person.NumberAgree;
                            PersonAgree.DateAgree = person.DateAgree;
                        }
                    }
                }
                db.SaveChanges();
                Console.WriteLine();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }
        public async Task<IActionResult> PrintButt()
        {
            int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
            CreateDocx createDocx = new(Idrpd, db, secDb);

            return  File(await createDocx.GetDocx(), "text/plain", "OutputDocument.docx");
           
        }

    }

}


