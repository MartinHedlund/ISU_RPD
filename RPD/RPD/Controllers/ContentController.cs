using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NuGet.Packaging.Signing;
using RPD.Models.BD_model;
using RPD.Models.BD_Second_model;
using RPD.Models.Content;
using RPD.Models.RP_2;
using RPD.Service;
using RPD.ViewModel;
using XAct;

namespace RPD.Controllers
{
    public class ContentController : Controller
    {

        DbService db;
        private readonly ILogger<ContentController> _logger;
        ContentViewModel ViewModel;
        DbSecondService secDb;

        public ContentController(DbService db, ILogger<ContentController> logger, DbSecondService dbSecond)
        {
            this.db = db;
            _logger = logger;
            ViewModel = new();
            this.secDb = dbSecond;
        }

        public IActionResult Index()
        {
            int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
            //int Idrpd = 9;


            RPDModel RPD = db.RPD.Where(x => x.IdRPD == Idrpd).ToList<RPDModel>().FirstOrDefault();

            ViewModel.CompStrings =  VMKomp(RPD.IdRPD);

            VMLinkChapterAndHours(RPD);

            return View(ViewModel);
        }

        private List<string> VMKomp(int idRPD)
        {
            List<string> CompName = new();
            List<Competence> competences = db.Сompetences.Where(x => x.IdRPD == idRPD).Include(x => x.Indicators).ThenInclude(x => x.LevelFormations).ToList();

            foreach (Competence Comp in competences)
            {
             
                foreach (Indicator indicator in Comp.Indicators)
                {
                    CompName.Add(indicator.CodeIndicator);
                    foreach (LevelFormation level in indicator.LevelFormations)
                    {
                        CompName.Add(level.NameLevelForm);
                    }

                }

            }
            return CompName;

        }

        private void VMLinkChapterAndHours(RPDModel RPD) // Заполнение Разделов
        {
            var CountSem = VMHours(RPD); // заполненние часов + вывод семестров

            foreach (int Sem in CountSem)
            {
                LinkSemChapter linkSemChapter = new LinkSemChapter()
                {
                    Semestr = Sem,
                    chapterModels = db.Chapter.Where(x => x.Semestr == Sem && x.RPDId == RPD.IdRPD).Include(p => p.Themes).ToList()
                };

                linkSemChapter.certificat = GetCertificat(RPD, Sem);

                foreach (Chapter chapter in linkSemChapter.chapterModels)
                {   if(chapter.KompetenString != null)
                        chapter.Kompetenc = chapter.KompetenString.Split(", ").ToList();
                }
                ViewModel.linkSemChapters.Add(linkSemChapter);
            }
        }

        private List<Certificat> GetCertificat (RPDModel Rpd, int Sem)
        {
            List<Certificat> certificat = new();
            certificat = db.certificats.Where(x => x.IdRPD == Rpd.IdRPD && x.Semestr == Sem).ToList();
            
            if(certificat.Count != 0)
                foreach (var cert in certificat)
                    if(cert.KompString != null)
                        cert.KompList = cert.KompString.Split(", ").ToList();
               

            if (certificat.Count == 0)
            {
                Certificat certEkZach = new();

                PlanHours planH = secDb.planHours.Where(x=> x.IdStroka == Rpd.IdStroka &&  x.Semestr == Sem).FirstOrDefault();

                if((bool)planH.Zachet)
                    certEkZach.NameCert = "Зачет";                
                if((bool)planH.ZachetO)
                    certEkZach.NameCert = "Зачет c Оценкой";                
                if((bool)planH.Ekzamen)
                    certEkZach.NameCert = "Экзамен";

                certEkZach.Hoirs = (int)planH.ChEkz;
                certificat.Add(certEkZach);

                if ((bool)planH.KP || (bool)planH.KR)
                {
                    Certificat certKpKr = new(); 
                    if((bool)planH.KP)
                    {
                        certKpKr.NameCert = "Курсовой Проект";
                        certKpKr.Hoirs = 72;
                    }
                    if ((bool)planH.KR)
                    {
                        certKpKr.NameCert = "Курсовая Работа";
                        certKpKr.Hoirs = 36;
                    }
                    certificat.Add(certKpKr);
                }
                    

            }

            return certificat;
        }
        private List<int> VMHours(RPDModel RPD) // вывод семестров и продолжение определения часов
        {
            List<int> vmSem = new List<int>();
            SemHours SemHour = new();

            SemsHours(RPD,ref SemHour, ref vmSem);
            
            ViewModel.SemHoursVM = SemHour;
            return vmSem;

        }

        private void SemsHours(RPDModel RPD,ref SemHours SemHour, ref List<int> vmSem) // Работа с бд заключительный этап
        {
            List<PlanHours> izuchenies = secDb.planHours.Where(x => x.IdStroka == RPD.IdStroka).ToList();

            SingleSemHours SingleSemHour;
            
            foreach (PlanHours item in izuchenies)
            {
                SingleSemHour = new SingleSemHours()
                {
                    Lek = (int)(item.Lek??0),
                    Pr = (int)(item.Pr??0),
                    Lab = (int)(item.Lab??0),

                    ChEkz = (int)item.ChEkz == 0 ? 0:36, //подготовка промежуточной аттестации
                };

                SingleSemHour.Semestr = (int)item.Semestr;
                
                if ((bool)item.KR)
                {
                    SingleSemHour.KR = 36;
                    SingleSemHour.Certification[0] = "КР";
                }

                if ((bool)item.KP)
                {
                    SingleSemHour.KP = 72;
                    SingleSemHour.Certification[0] = "КП";
                }

                if ((bool)item.Zachet)
                    SingleSemHour.Certification[1] = "З";
                if((bool)item.ZachetO)
                    SingleSemHour.Certification[1] = "ЗО";
                if ((bool)item.Ekzamen)
                {
                    SingleSemHour.ContactWork = 9;
                    SingleSemHour.Certification[1] = "Э";
                }
                SingleSemHour.SRS = (int)item.SRS - SingleSemHour.KP - SingleSemHour.KR;// Проработка обучающегося

                SingleSemHour.SumSrs = SingleSemHour.SRS + SingleSemHour.KP + SingleSemHour.KR + SingleSemHour.ChEkz;
                SingleSemHour.SumAuditWork = SingleSemHour.Lek + SingleSemHour.Pr + SingleSemHour.Lab;
                SingleSemHour.SumAll = SingleSemHour.SumAuditWork + SingleSemHour.SumSrs;

                SingleSemHour.ContactWork += (int)(SingleSemHour.SumAuditWork + Math.Ceiling((double)SingleSemHour.KP / 2) + Math.Ceiling((double)SingleSemHour.KR / 2) + Math.Ceiling(SingleSemHour.SRS * 0.1));

                AddHours(ref SemHour, SingleSemHour);
                SemHour.SingleSemHour.Add(SingleSemHour);
            }

            foreach (SingleSemHours sem in SemHour.SingleSemHour)
                vmSem.Add(sem.Semestr);
        }

        private void AddHours(ref SemHours semHours, SingleSemHours OneSem) // Общее кол-во часов по каждому типу
        {

            semHours.SumLek += OneSem.Lek;
            semHours.SumPr += OneSem.Pr;
            semHours.SumLab += OneSem.Lab;
            semHours.SumSRS += OneSem.SRS;
            semHours.SumKR += OneSem.KR;
            semHours.SumKP += OneSem.KP;
            semHours.SumChEkz += OneSem.ChEkz;

            semHours.SumAllSrs += OneSem.SRS+OneSem.KR + OneSem.KP+OneSem.ChEkz; 
            semHours.SumAllSemHours += OneSem.SumAll;
            semHours.SumAllAuditWork += OneSem.SumAuditWork;
            semHours.SumAllContactWork += OneSem.ContactWork;
        }

        [HttpPost]
        public IActionResult SaveContent(ContentViewModel ViewModel)
        {

            int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
            //int Idrpd = 9;


            RPDModel RPD = db.RPD.Where(x => x.IdRPD == Idrpd).ToList<RPDModel>().FirstOrDefault();
            //Определение часов

            UpdateDBChapter(ViewModel, RPD);
            // Изменение БД
            ViewModel.CompStrings = VMKomp(RPD.IdRPD);
            VMLinkChapterAndHours(RPD);
            ViewModel.SemHoursVM = this.ViewModel.SemHoursVM;

            return View("Index", ViewModel);
        }

        private void UpdateDBChapter(ContentViewModel ViewModel, RPDModel RPD)
        {
            foreach (LinkSemChapter linkSem in ViewModel.linkSemChapters)
            {
                List<Certificat> certificat = db.certificats.Where(x=> x.IdRPD == RPD.IdRPD && x.Semestr == linkSem.Semestr).ToList();
                if (certificat.Count != 0)
                {
    
                    for (int i = 0; i < certificat.Count; i++)
                        certificat[i].KompString = linkSem.certificat[i].KompList.Count != 0 ? string.Join(", ", linkSem.certificat[i].KompList) : null;
                    
                }
                else
                {
                    foreach (var newcert in linkSem.certificat)
                    {
                        Certificat NewCert = new Certificat();
                        NewCert = newcert;
                        NewCert.IdRPD = RPD.IdRPD;
                        NewCert.Semestr = linkSem.Semestr;
                        NewCert.KompString = newcert.KompList != null ? string.Join(", ", newcert.KompList) : null;
                        db.certificats.Add(NewCert);
                    }

                }
                    db.SaveChanges();
                    



                List<Chapter> DbChapter = db.Chapter.Where(x => x.RPDId == RPD.IdRPD && x.Semestr == linkSem.Semestr).Include(p => p.Themes).ToList();

                if (DbChapter.Count == linkSem.chapterModels.Count) // Если кол-во =
                {
                    for (int i = 0; i < DbChapter.Count; i++)
                    {
                        DbChapter[i].KompetenString = linkSem.chapterModels[i].Kompetenc != null? string.Join(", ", linkSem.chapterModels[i].Kompetenc): null;
                        DbChapter[i].NameChapter = linkSem.chapterModels[i].NameChapter;
                        DbChapter[i].Lek = linkSem.chapterModels[i].Lek;
                        DbChapter[i].Lab = linkSem.chapterModels[i].Lab;
                        DbChapter[i].Pr = linkSem.chapterModels[i].Pr;
                        DbChapter[i].Srs = linkSem.chapterModels[i].Srs;

                        UpdateTheme(ref DbChapter, i, linkSem.chapterModels[i]);
                    }
                }

                // В дб меньше чем ведено
                if (DbChapter.Count < linkSem.chapterModels.Count)
                {
                    for (int i = 0; i < DbChapter.Count; i++)
                    {
                        DbChapter[i].KompetenString = linkSem.chapterModels[i].Kompetenc != null ? string.Join(", ", linkSem.chapterModels[i].Kompetenc): null;
                        DbChapter[i].NameChapter = linkSem.chapterModels[i].NameChapter;
                        DbChapter[i].Lek = linkSem.chapterModels[i].Lek;
                        DbChapter[i].Lab = linkSem.chapterModels[i].Lab;
                        DbChapter[i].Pr = linkSem.chapterModels[i].Pr;
                        DbChapter[i].Srs = linkSem.chapterModels[i].Srs;

                        UpdateTheme(ref DbChapter, i, linkSem.chapterModels[i]);
                    }
                    for (int j = DbChapter.Count; j < linkSem.chapterModels.Count; j++)
                    {
                        linkSem.chapterModels[j].RPDId = RPD.IdRPD;
                        linkSem.chapterModels[j].Semestr = linkSem.Semestr;
                        linkSem.chapterModels[j].KompetenString = linkSem.chapterModels[j].Kompetenc != null ? string.Join(", ", linkSem.chapterModels[j].Kompetenc): null;

                        db.Chapter.Add(linkSem.chapterModels[j]);
                        db.SaveChanges();
                    }


                }

                // в дб больше чем ведено
                if (DbChapter.Count > linkSem.chapterModels.Count)
                {

                    for (int i = 0; i < linkSem.chapterModels.Count; i++)
                    {
                        DbChapter[i].KompetenString = linkSem.chapterModels[i].Kompetenc != null ? string.Join(", ", linkSem.chapterModels[i].Kompetenc): null;
                        DbChapter[i].NameChapter = linkSem.chapterModels[i].NameChapter;
                        DbChapter[i].Lek = linkSem.chapterModels[i].Lek;
                        DbChapter[i].Lab = linkSem.chapterModels[i].Lab;
                        DbChapter[i].Pr = linkSem.chapterModels[i].Pr;
                        DbChapter[i].Srs = linkSem.chapterModels[i].Srs;

                        UpdateTheme(ref DbChapter, i, linkSem.chapterModels[i]);
                    }
                    for (int j = linkSem.chapterModels.Count; j < DbChapter.Count; j++)
                    {
                        db.Chapter.Remove(DbChapter[j]);
                        db.SaveChanges();
                    }
                }
            }
        }
        private void UpdateTheme(ref List<Chapter> chapter,int i, Chapter VMChapter)
        {
            
            if(chapter[i].Themes.Count == VMChapter.Themes.Count)
            {
                for (int k = 0; k < chapter[i].Themes.Count; k++)
                {
                    if (chapter[i].Themes[k] != VMChapter.Themes[k])
                    {
                        chapter[i].Themes[k].NameTheme = VMChapter.Themes[k].NameTheme;
                        chapter[i].Themes[k].DescTheme = VMChapter.Themes[k].DescTheme;
                    }
                }                
            }

            if(chapter[i].Themes.Count < VMChapter.Themes.Count)
            {
                for (int k = 0; k < chapter[i].Themes.Count; k++)
                {
                    if (chapter[i].Themes[k] != VMChapter.Themes[k])
                    {
                        chapter[i].Themes[k].NameTheme = VMChapter.Themes[k].NameTheme;
                        chapter[i].Themes[k].DescTheme = VMChapter.Themes[k].DescTheme;
                    }
                }
                for (int l = chapter[i].Themes.Count; l < VMChapter.Themes.Count; l++)
                {
                    VMChapter.Themes[l].ChapterId = chapter[i].Id;
                    db.ThemeChapter.Add(VMChapter.Themes[l]);
                }
            }

            if(chapter[i].Themes.Count > VMChapter.Themes.Count)
            {
                for (int k = 0; k < VMChapter.Themes.Count; k++)
                {
                    if (chapter[i].Themes[k] != VMChapter.Themes[k])
                    {
                        chapter[i].Themes[k].NameTheme = VMChapter.Themes[k].NameTheme;
                        chapter[i].Themes[k].DescTheme = VMChapter.Themes[k].DescTheme;
                    }
                }
                for (int l = VMChapter.Themes.Count; l < chapter[i].Themes.Count; l++)
                {
                    db.ThemeChapter.Remove(chapter[i].Themes[l]);
                }

            }
            db.SaveChanges();

        }

        public ActionResult GetComp()
        {
            int Idrpd = (int)HttpContext.Session.GetInt32("IdRPD");
            //int Idrpd = 9;


            RPDModel RPD = db.RPD.Where(x => x.IdRPD == Idrpd).ToList<RPDModel>().FirstOrDefault();

            List<string> CompStrings = VMKomp(RPD.IdRPD);
            return PartialView("SelectComp", CompStrings);
        }
    }
}
