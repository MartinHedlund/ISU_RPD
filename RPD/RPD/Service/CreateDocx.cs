using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;
using NuGet.Packaging;
using RPD.Models;
using RPD.Models.BD_model;
using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.BD_Second_model;
using RPD.Models.Content;
using RPD.Models.RP_2;
using RPD.Models.Rpd;
using RPD.Models.Titul;
using RPD.Models.Material;
using RPD.ViewModel;
using TemplateEngine.Docx;
using XAct.Library.Settings;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Paragraph = Xceed.Document.NET.Paragraph;
using Table = Xceed.Document.NET.Table;
using XAct;
using RPD.Controllers;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.CodeAnalysis;

namespace RPD.Service
{

    public class CreateDocx
    {
        DbService db { get; set; }
        DbSecondService secDb { get; set; }

        RPDModel rpd { get; set; }
        List<StrokaMmisModel> AllStroks { get; set; }
        StrokaMmisModel Stroka { get; set; }
        UchPlanMmisModel UchPlan { get; set; }
        List<Competence> Kompetens { get; set; }
        List<Chapter> Chapters { get; set; }
        List<PlanHours> planHours { get; set; }
        List<rpLit> rpLitsOne { get; set; }
        List<rpLit> rpLitsSecond { get; set; }

        // ОМ
        RatingScale? RatingScales { get; set; }
        List<ListAllEvaluationTools> EvaluationToolsOthers { get; set; } = new();


        List<PersonsAgreement> PersonDeveloper = new();

        List<PersonsAgreement> personsAgreements = new();
        int Idrpd;

        public CreateDocx(int IdRPD, DbService db, DbSecondService dbSecond)
        {
            this.Idrpd = IdRPD;
            this.db = db;
            this.secDb = dbSecond;
        }

        private async Task Initcialic(RPDModel rpd)
        {
            List<int> stroksBindRpd = await db.stroksBindRpds.Where(x => x.IdRpd == rpd.IdRPD).Select(x => x.IdStroka).ToListAsync();

            AllStroks = await secDb.strokaMmisModels.Where(x => stroksBindRpd.Contains(x.Id)).ToListAsync();
            Stroka = AllStroks.FirstOrDefault(x => x.Id == rpd.IdStroka);
            UchPlan = await secDb.uchPlanMmisModels.FindAsync(Stroka.UchPlanMmisModelId);
            Kompetens = await db.Сompetences.Where(x => x.IdRPD == rpd.IdRPD).Include(x => x.Indicators).ThenInclude(z => z.LevelFormations.OrderBy(x => x.Level)).ToListAsync();
            planHours = await secDb.planHours.Where(x => x.IdStroka == rpd.IdStroka).ToListAsync();
            Chapters = await db.Chapter.Where(x => x.RPDId == Idrpd).Include(x => x.Themes).ToListAsync();

            List<int> IdUsersDiscip = await db.userDiscipModels.Where(x => x.IdStroka == Stroka.Id).Select(x => x.IdUser).ToListAsync();
            List<int?> IdPersons = await db.Users.Where(x => IdUsersDiscip.Contains(x.UserId)).Select(x => x.IdPerson).ToListAsync();
            var valuesToCheck = new[] {

                        (int)AcademicRankForDevelopers.Доцент,
                        (int)AcademicRankForDevelopers.Профессор,
                        (int)AcademicRankForDevelopers.СтПреподаватель,
                        (int)AcademicRankForDevelopers.Преподаватель};
            foreach (int IdPerson in IdPersons)
            {
                var IdPosDev = db.Employee.Where(x => x.IdPerson == IdPerson && valuesToCheck.Contains(x.IdPosition)).FirstOrDefault();
                var Dep = db.departments.Find(IdPosDev.IdDepartment);
                PersonModel person = db.Persons.Find(IdPosDev.IdPerson);
                PersonDeveloper.Add(new PersonsAgreement(person, Dep, 1));
            }

            List<PersonAgreementModel> personAgreements = await db.personAgreementModels.Where(x => x.IdRpd == Idrpd).ToListAsync();
            GetGlavExistUser(personAgreements);

            var IdLit = await db.literRPDs.Where(x => x.IdRPD == Idrpd).ToListAsync();
            if (IdLit.Count != 0)
            {
                List<int> IdLiters = IdLit.Where(y => y.Type == 1).Select(y => y.IdLit).ToList();
                if (IdLiters.Count != 0)
                    rpLitsOne = await db.rpLit.Where(x => IdLiters.Contains(x.IdLit)).ToListAsync();

                IdLiters = IdLit.Where(y => y.Type == 2).Select(y => y.IdLit).ToList();
                if (rpLitsOne.Count != 0)
                    rpLitsSecond = await db.rpLit.Where(x => IdLiters.Contains(x.IdLit)).ToListAsync();
            }

            RatingScales = await db.RatingScales.Where(x => x.IdRpd == Idrpd).FirstOrDefaultAsync();
        }
        private void GetGlavExistUser(List<PersonAgreementModel> Persons)
        {
            foreach (var Pers in Persons)
            {
                DepartmentModel Dep = db.departments.Find(Pers.IdDepartament);
                PersonModel personModel = db.Persons.Find(Pers.IdPerson);
                PersonsAgreement personsAgreement = new PersonsAgreement(Pers, Dep, personModel);
                personsAgreements.Add(personsAgreement);
            }
        }

        public async Task<string> GetDocx()
        {

            rpd = await db.RPD.FindAsync(Idrpd);

            await Initcialic(rpd);

            string[] paths23 = { "wwwroot", "assets", "Files", "InputTemplate.docx" };
            var InputPath3 = System.IO.Path.Combine(paths23);
            using (DocX document = await Task.Run(() => DocX.Load(InputPath3)))
            {
                Table tableKomp = CompTable(document);
                Table TableHours = HoursTable(document);

                // Вставка таблицы в документ
                string tag = "Шкала оценки результатов обучения по дисциплине:";
                var paragraphs = document.Paragraphs.Where(p => p.Text.Contains(tag)).ToList();
                foreach (var item in paragraphs)
                    item.InsertTableAfterSelf(tableKomp);

                tag = "Для очной формы обучения";
                var paragraphst = document.Paragraphs.FirstOrDefault(p => p.Text.Contains(tag));
                // Замена тега на таблицу
                // paragraph.ReplaceText(tag, string.Empty);
                paragraphst.InsertTableAfterSelf(TableHours);

                tag = "3.3. Содержание дисциплины";
                paragraphst = document.Paragraphs.FirstOrDefault(p => p.Text.Contains(tag));
                GetContentDiscip(ref paragraphst);

                tag = "5.1.1. Основная литература";
                paragraphst = document.Paragraphs.FirstOrDefault(p => p.Text.Contains(tag));
                GetLiter(ref paragraphst, 1);

                tag = "5.1.2.Дополнительная литература";
                paragraphst = document.Paragraphs.FirstOrDefault(p => p.Text.Contains(tag));
                GetLiter(ref paragraphst, 2);


                // Сохранение изменений
                string[] paths233 = { "wwwroot", "assets", "Files", "OutTemplate.docx" };
                var InputPath33 = System.IO.Path.Combine(paths233);
                await Task.Run(() => document.SaveAs(InputPath33));
            }

            #region Template
            // Потом сделать заполнение документа
            string[] paths = { "wwwroot", "assets", "OutputDocument.docx" };
            string[] paths2 = { "wwwroot", "assets", "Files", "OutTemplate.docx" };
            string[] paths3 = { "~/assets", "OutputDocument.docx" };

            var OutPath = System.IO.Path.Combine(paths);
            var InputPath = System.IO.Path.Combine(paths2);
            var OutPathDownload = System.IO.Path.Combine(paths3);

            System.IO.File.Delete(OutPath);
            System.IO.File.Copy(InputPath, OutPath);
            System.IO.File.Delete(InputPath);

            TableContent CompTableMain = new("KompAndIndic");
            if (Kompetens.Count != 0)
            {
                foreach (Competence Comp in Kompetens)
                {
                    string temp = string.Join("\r\n", Comp.Indicators.Select(x => $"{x.CodeIndicator} {x.NameIndicator}"));

                    CompTableMain.AddRow(
                        new FieldContent("CodAndNameKomp", $"{Comp.CodeKomp} {Comp.NameKomp}"),
                        new FieldContent("CodAndNameIndic", $"{temp}")
                    );
                }
            }

            TableContent TableDev = TableDevelopers();
            TableContent TablePersAgree = TablePersonAgreement();

            var val = personsAgreements.Where(x => x.Type == 4).FirstOrDefault();
            string NameInst = "";
            string NameGlavInst = "";
            if (val != null)
            {
                NameInst = val.NameInstKaf;
                NameGlavInst = val.FioSokr;
            }



            List<TableContent> TableChapter = new();
            InitTableChapter(ref TableChapter, Idrpd);
            var valuesToFill = new Content(
                new FieldContent("NameDiscAndShifr", (Stroka.DiscСode + " " + Stroka.NameDiscip).ToString()),
                new FieldContent("CodeAndNaprav", UchPlan.Titul ?? ""),
                new FieldContent("Kvalific", GetKvalific()),
                new FieldContent("Disciplina", Stroka.NameDiscip ?? ""),
                new FieldContent("PurposeDisc", rpd.Purpose ?? ""),
                new FieldContent("TaskDisc", rpd.Tasks ?? ""),
                new FieldContent("PredDiscip", GetPredDiscip(Idrpd)),
                new FieldContent("PostDiscip", GetPostDiscip(Idrpd)),
                new FieldContent("ThemPlanLab", rpd.ThemPlanLab ?? ""),
                new FieldContent("ThemPlanPr", rpd.ThemPlanPr ?? ""),
                new FieldContent("ThemePlanKPKR", rpd.ThemPlanKpKr ?? ""),
                new FieldContent("NameInst", NameInst),
                new FieldContent("NameGlavInst", NameGlavInst),
                new FieldContent("RatingOtl", RatingScales?.Excellent ?? ""),
                new FieldContent("RatingHor", RatingScales?.Good ?? ""),
                new FieldContent("RatingUdov", RatingScales?.Satisfactory ?? ""),
                new FieldContent("RatingNeUdov", RatingScales?.UnSatisfactory ?? ""),
                // сюда таблицы TemglateE можно пихать
                TableDev,
                TablePersAgree,
                CompTableMain,
                GetEvalutionTable()
            );
            valuesToFill.Tables.AddRange(TableChapter);

            using (var outputDocument = new TemplateProcessor(OutPath).SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

            #endregion

            // открыть потом по пути OUTPATH файл и добавить в него через filestream в конец загруженный файл
            FileStreamResult sourceFile = GetFilePKZ();

            using (DocX destinationDocument = DocX.Load(OutPath))
            {
                using (DocX sourceDocument = DocX.Load(sourceFile.FileStream))
                {
                    destinationDocument.InsertDocument(sourceDocument);
                }

                destinationDocument.Save();
            }


            return OutPathDownload;
        }

        private TableContent TablePersonAgreement()
        {
            TableContent TablePersAgree = new("TablePersonsAgreement");
            string Date;
            string Sogl;
            string NameKafOrInst;
            string SoglType;
            string FIOandAlsoForAgreement;
            foreach (var PersAgree in personsAgreements)
            {

                SoglType = "";
                if (PersAgree.Type == 3)
                    SoglType = "Учебно-методический совет ";
                if (PersAgree.Type == 4)
                    SoglType = "Ученый совет ";

                if (PersAgree.Type == 4 || PersAgree.Type == 1)
                    Sogl = "Одобрена";
                else
                    Sogl = "Согласована";
                Date = PersAgree.DateApproval == null ? "" : PersAgree.DateApproval.Value.Date.ToString("d");


                FIOandAlsoForAgreement = PersAgree.UchStepen + ", " + PersAgree.UchZvanie + "\r\n" + PersAgree.FioSokrForDocx;
                TablePersAgree.AddRow(
                    new FieldContent("Soglasovanie", $"{Sogl}"),
                    new FieldContent("NameKafForAgreement", $"{SoglType}{PersAgree.NameInstKafSokr}"),
                    new FieldContent("DateForAgreement", $"{Date}"),
                    new FieldContent("NumberProtokolForAgreement", $"{PersAgree.NumberProtocol ?? ""}"),
                    new FieldContent("FIOandAlsoForAgreement", $"{FIOandAlsoForAgreement}")
                    );
            }

            return TablePersAgree;

        }
        private TableContent TableDevelopers()
        {
            TableContent TableDev = new("TableRazrab");
            foreach (var PersDev in PersonDeveloper)
            {
                TableDev.AddRow(
                new FieldContent("NameKaf", $"{PersDev.NameInstKafSokr}"),
                new FieldContent("Doljnost", $"{PersDev.UchZvanie},\r\n{PersDev.UchStepen}"),
                new FieldContent("Fio", $"{PersDev.FIO}")
                   );
            }
            return TableDev;
        }
        private Table HoursTable(DocX document)
        {
            #region InitRowColumn
            int row = 15;
            int col = 3;
            col += planHours.Count;
            #endregion

            Table table = document.AddTable(row, col);
            table.Design = TableDesign.TableGrid;

            List<float> WidthTable = new();
            float ColProcent = 100 - 10 * (col - 1);
            WidthTable.Add(ColProcent);
            for (int column = 0; column < col - 1; column++)
            {
                WidthTable.Add(10);
            }

            table.SetWidthsPercentage(WidthTable.ToArray());
            #region Header
            table.Rows[0].Cells[0].Paragraphs[0].Append("Вид учебной работы");
            table.MergeCellsInColumn(0, 0, 1);
            table.Rows[0].Cells[1].Paragraphs[0].Append("Всего ЗЕ");
            table.MergeCellsInColumn(1, 0, 1);
            table.Rows[0].Cells[2].Paragraphs[0].Append("Всего часов");
            table.MergeCellsInColumn(2, 0, 1);

            table.Rows[0].Cells[3].Paragraphs[0].Append("Семестр(ы)");

            if (col != 4)
                table.Rows[0].MergeCells(3, col);


            table.Rows[2].Cells[0].Paragraphs[0].Append("ОБЩАЯ ТРУДОЕМКОСТЬ ДИСЦИПЛИНЫ");
            table.Rows[3].Cells[0].Paragraphs[0].Append("КОНТАКТНАЯ РАБОТА");
            table.Rows[4].Cells[0].Paragraphs[0].Append("АУДИТОРНАЯ РАБОТА");
            table.Rows[5].Cells[0].Paragraphs[0].Append("Лекции ");
            table.Rows[6].Cells[0].Paragraphs[0].Append("Практические (семинарские) занятия ");
            table.Rows[7].Cells[0].Paragraphs[0].Append("Лабораторные работы ");
            table.Rows[8].Cells[0].Paragraphs[0].Append("САМОСТОЯТЕЛЬНАЯ РАБОТА ОБУЧАЮЩЕГОСЯ");
            table.Rows[9].Cells[0].Paragraphs[0].Append("Проработка учебного материала");
            table.Rows[10].Cells[0].Paragraphs[0].Append("Курсовой проект");
            table.Rows[11].Cells[0].Paragraphs[0].Append("Курсовая работа");
            table.Rows[12].Cells[0].Paragraphs[0].Append("Подготовка к промежуточной аттестации");
            table.Rows[13].Cells[0].Paragraphs[0].Append("Промежуточная аттестация:");


            #endregion

            #region InitContent
            int AllHours = 0;

            int AllAud = 0;
            int AllLek = 0;
            int AllPr = 0;
            int AllLab = 0;

            int AllSrs = 0;
            int AllProrabotka = 0;
            int AllKP = 0;
            int AllKR = 0;
            int AllPodgotovka = 0;

            int AudSem = 0;
            int SrsSem = 0;
            int KP = 0;
            int KR = 0;

            string HoKpKr = "-";
            string HoEkz = "Э";

            int d = 3;
            foreach (PlanHours planH in planHours)
            {
                AudSem = 0;
                SrsSem = 0;

                AudSem = (int)(planH.Lek + planH.Pr + planH.Lab);
                if ((bool)planH.KP)
                {
                    KP = 72;
                    HoKpKr = "КП";
                }
                if ((bool)planH.KR)
                {
                    KR = 36;
                    HoKpKr = "КР";
                }
                if ((int)planH.ChEkz != 36)
                    HoEkz = "З";


                SrsSem = (int)(planH.SRS + planH.ChEkz);
                //ОБЩАЯ ТРУДОЕМКОСТЬ ДИСЦИПЛИНЫ
                table.Rows[1].Cells[d].Paragraphs[0].Append((planH.Semestr).ToString());
                table.Rows[1].Cells[d].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
                table.Rows[1].Cells[d].Paragraphs[0].LineSpacing = (float)12.0;
                table.Rows[1].Cells[d].VerticalAlignment = VerticalAlignment.Center;
                //table.Rows[1].Cells[d].Paragraphs[0].SpacingAfter(0.000000001);

                table.Rows[2].Cells[d].Paragraphs[0].Append((AudSem + SrsSem).ToString());

                // Аудиторная работа
                table.Rows[4].Cells[d].Paragraphs[0].Append(AudSem.ToString());

                //Лекции
                table.Rows[5].Cells[d].Paragraphs[0].Append(planH.Lek.ToString());

                //Практика
                table.Rows[6].Cells[d].Paragraphs[0].Append(planH.Pr.ToString());

                //Лабораторная
                table.Rows[7].Cells[d].Paragraphs[0].Append(planH.Lek.ToString());

                //Самостоятельные работа
                table.Rows[8].Cells[d].Paragraphs[0].Append(SrsSem.ToString());

                // Проработка учебного материала
                table.Rows[9].Cells[d].Paragraphs[0].Append((planH.SRS - KP - KR).ToString());

                //Курсовой проект
                table.Rows[10].Cells[d].Paragraphs[0].Append(KP.ToString());

                //Курсовая работа
                table.Rows[11].Cells[d].Paragraphs[0].Append(KR.ToString());

                //Подготовка
                table.Rows[12].Cells[d].Paragraphs[0].Append(planH.ChEkz.ToString());

                // промежуточная аттестация
                table.Rows[13].Cells[d].Paragraphs[0].Append(HoKpKr);
                table.Rows[14].Cells[d].Paragraphs[0].Append(HoEkz);

                for (int i = 13; i <= 14; i++)
                {
                    table.Rows[i].Cells[d].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
                    table.Rows[i].Cells[d].Paragraphs[0].LineSpacing = (float)12.0;
                    table.Rows[i].Cells[d].VerticalAlignment = VerticalAlignment.Center;

                }

                AllAud += AudSem;
                AllLek += (int)planH.Lek;
                AllPr += (int)planH.Pr;
                AllLab += (int)planH.Lab;

                AllSrs += SrsSem;
                AllProrabotka += (int)planH.SRS - KP - KR;
                AllKP += KP;
                AllKR += KR;
                AllPodgotovka += (int)planH.ChEkz;
                AllHours += AllAud + AllSrs;
            }

            table.Rows[2].Cells[1].Paragraphs[0].Append((Math.Round(AllHours / 36.0, 2)).ToString());
            table.Rows[2].Cells[2].Paragraphs[0].Append(AllHours.ToString());


            // Аудиторная работа
            table.Rows[4].Cells[1].Paragraphs[0].Append((Math.Round(AllAud / 36.0, 2)).ToString());
            table.Rows[4].Cells[2].Paragraphs[0].Append(AllAud.ToString());

            //Лекции
            table.Rows[5].Cells[1].Paragraphs[0].Append((Math.Round(AllLek / 36.0, 2)).ToString());
            table.Rows[5].Cells[2].Paragraphs[0].Append(AllLek.ToString());

            //Практика
            table.Rows[6].Cells[1].Paragraphs[0].Append((Math.Round(AllPr / 36.0, 2)).ToString());
            table.Rows[6].Cells[2].Paragraphs[0].Append(AllPr.ToString());

            //Лабораторная
            table.Rows[7].Cells[1].Paragraphs[0].Append((Math.Round(AllLab / 36.0, 2)).ToString());
            table.Rows[7].Cells[2].Paragraphs[0].Append(AllLab.ToString());

            //Самостоятельные работа
            table.Rows[8].Cells[1].Paragraphs[0].Append((Math.Round(AllSrs / 36.0, 2)).ToString());
            table.Rows[8].Cells[2].Paragraphs[0].Append(AllSrs.ToString());

            // Проработка учебного материала
            table.Rows[9].Cells[1].Paragraphs[0].Append((Math.Round(AllProrabotka / 36.0, 2)).ToString());
            table.Rows[9].Cells[2].Paragraphs[0].Append(AllProrabotka.ToString());

            //Курсовой проект
            table.Rows[10].Cells[1].Paragraphs[0].Append((Math.Round(AllKP / 36.0, 2)).ToString());
            table.Rows[10].Cells[2].Paragraphs[0].Append(AllKP.ToString());

            //Курсовая работа
            table.Rows[11].Cells[1].Paragraphs[0].Append((Math.Round(AllKR / 36.0, 2)).ToString());
            table.Rows[11].Cells[2].Paragraphs[0].Append(AllKR.ToString());

            //Подготовка
            table.Rows[12].Cells[1].Paragraphs[0].Append((Math.Round(AllPodgotovka / 36.0, 2)).ToString());
            table.Rows[12].Cells[2].Paragraphs[0].Append(AllPodgotovka.ToString());

            // промежуточная аттестация
            table.Rows[13].Cells[0].Paragraphs[0].Append("");
            table.MergeCellsInColumn(0, 13, 14);
            table.MergeCellsInColumn(1, 13, 14);
            table.MergeCellsInColumn(2, 13, 14);

            table.Rows[13].MergeCells(0, 2);
            table.Rows[14].MergeCells(0, 2);

            #endregion

            #region Style

            for (int i = 0; i <= 3; i++)
            {
                table.Rows[0].Cells[i].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
                table.Rows[0].Cells[i].Paragraphs[0].LineSpacing = (float)12.0;
                table.Rows[0].Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
            for (int i = 2; i <= 13; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.left;
                table.Rows[i].Cells[0].Paragraphs[0].LineSpacing = (float)12.0;
                table.Rows[i].Cells[0].VerticalAlignment = VerticalAlignment.Center;


            }

            for (int i = 2; i <= 12; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    table.Rows[i].Cells[j].Paragraphs[0].Font("Times New Roman").FontSize(14).Alignment = Alignment.center;
                    table.Rows[i].Cells[j].Paragraphs[0].LineSpacing = (float)12.0;
                    table.Rows[i].Cells[j].VerticalAlignment = VerticalAlignment.Center;
                }
            }

            #endregion

            return table;
        }
        private Table CompTable(DocX document)
        {

            #region InitRowColumn
            int row = 6;
            int col = 7;
            foreach (var comp in Kompetens)
                foreach (var Incdic in comp.Indicators)
                    row += Incdic.LevelFormations.Count + 3;
            #endregion

            Table table = document.AddTable(row, col);
            table.Design = TableDesign.TableGrid;
            // Заполнение ячеек таблицы
            #region Header
            table.Rows[0].Cells[0].Paragraphs[0].Append("Код компе-тенции");
            table.Rows[0].Cells[0].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            table.Rows[0].Cells[0].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[0].Cells[0].VerticalAlignment = VerticalAlignment.Center;


            table.Rows[0].Cells[1].Paragraphs[0].Append("Код индикатора компетенции");
            table.Rows[0].Cells[1].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[0].Cells[1].VerticalAlignment = VerticalAlignment.Center;


            table.Rows[0].Cells[2].Paragraphs[0].Append("Заплани-рованные результаты обучения по дисциплине");
            table.Rows[0].Cells[2].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            table.Rows[0].Cells[2].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[0].Cells[2].VerticalAlignment = VerticalAlignment.Center;

            table.Rows[0].Cells[3].Paragraphs[0].Append("Уровень сформированности индикатора  компетенции");
            table.Rows[0].Cells[3].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[0].Cells[3].VerticalAlignment = VerticalAlignment.Center;

            table.Rows[0].MergeCells(3, 6);
            table.MergeCellsInColumn(0, 0, 5);
            table.MergeCellsInColumn(1, 0, 5);
            table.MergeCellsInColumn(2, 0, 5);

            table.Rows[1].Cells[3].Paragraphs[0].Append("Высокий");
            table.Rows[1].Cells[4].Paragraphs[0].Append("Средний");
            table.Rows[1].Cells[5].Paragraphs[0].Append("Ниже \r\nсреднего");
            table.Rows[1].Cells[6].Paragraphs[0].Append("Низкий");

            table.Rows[2].Cells[3].Paragraphs[0].Append("от 85 до 100");
            table.Rows[2].Cells[4].Paragraphs[0].Append("от 70 до 84");
            table.Rows[2].Cells[5].Paragraphs[0].Append("от 55 до 69");
            table.Rows[2].Cells[6].Paragraphs[0].Append("от 0  до 54");

            for (int i = 1; i < 3; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    table.Rows[i].Cells[j].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
                    table.Rows[i].Cells[j].Paragraphs[0].LineSpacing = (float)12.0;
                    table.Rows[i].Cells[j].VerticalAlignment = VerticalAlignment.Center;
                }
            }

            table.Rows[3].Cells[3].Paragraphs[0].Append("Шкала оценивания");
            table.Rows[3].Cells[3].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            table.Rows[3].Cells[3].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[3].Cells[3].VerticalAlignment = VerticalAlignment.Center;

            table.Rows[3].MergeCells(3, 6);

            table.Rows[4].Cells[3].Paragraphs[0].Append("отлично ");
            table.Rows[4].Cells[4].Paragraphs[0].Append("хорошо ");
            table.Rows[4].Cells[5].Paragraphs[0].Append("удовлет-ворительно");
            table.Rows[4].Cells[6].Paragraphs[0].Append("неудов-летвори-тельно");
            for (int k = 3; k < 7; k++)
            {
                table.Rows[4].Cells[k].Paragraphs[0].Font("Times New Roman").FontSize(11).Alignment = Alignment.center;
                table.Rows[4].Cells[k].Paragraphs[0].LineSpacing = (float)12.0;
                table.Rows[4].Cells[k].VerticalAlignment = VerticalAlignment.Center;
            }

            table.Rows[5].Cells[3].Paragraphs[0].Append("Зачтено");
            table.Rows[5].Cells[3].Paragraphs[0].Font("Times New Roman").FontSize(11).Alignment = Alignment.center;
            table.Rows[5].Cells[3].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[5].Cells[3].VerticalAlignment = VerticalAlignment.Center;

            table.Rows[5].Cells[6].Paragraphs[0].Append("не зачтено");
            table.Rows[5].Cells[6].Paragraphs[0].Font("Times New Roman").FontSize(11).Alignment = Alignment.center;
            table.Rows[5].Cells[6].Paragraphs[0].LineSpacing = (float)12.0;
            table.Rows[5].Cells[6].VerticalAlignment = VerticalAlignment.Center;

            table.Rows[5].MergeCells(3, 5);





            #endregion

            #region InitContent
            int HoRow = 6;
            int KompRow = 0;
            int IndicRow = 0;
            foreach (var Komp in Kompetens)
            {
                KompRow = HoRow;
                table.Rows[HoRow].Cells[0].Paragraphs[0].Append(Komp.CodeKomp);
                table.Rows[HoRow].Cells[0].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.left;
                table.Rows[HoRow].Cells[0].Paragraphs[0].LineSpacing = (float)12.0;
                table.Rows[HoRow].Cells[0].VerticalAlignment = VerticalAlignment.Center;

                foreach (var Indic in Komp.Indicators)
                {
                    IndicRow = HoRow;

                    table.Rows[HoRow].Cells[1].Paragraphs[0].Append(Indic.CodeIndicator);
                    table.Rows[HoRow].Cells[1].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.left;
                    table.Rows[HoRow].Cells[1].Paragraphs[0].LineSpacing = (float)12.0;
                    table.Rows[HoRow].Cells[1].VerticalAlignment = VerticalAlignment.Center;

                    Dictionary<int, List<LevelFormation>> GroupLevForm = Indic.LevelFormations.OrderBy(x => x.Level).GroupBy(x => x.Level).ToDictionary(g => g.Key, g => g.ToList());
                    foreach ((int key, List<LevelFormation> value) in GroupLevForm)
                    {

                        switch (key)
                        {
                            case 1:
                                table.Rows[HoRow].Cells[2].Paragraphs[0].Append("Знать:");
                                break;
                            case 2:
                                table.Rows[HoRow].Cells[2].Paragraphs[0].Append("Уметь:");
                                break;
                            case 3:
                                table.Rows[HoRow].Cells[2].Paragraphs[0].Append("Владеть:");
                                break;
                        }
                        table.Rows[HoRow].Cells[2].Paragraphs[0].Font("Times New Roman").FontSize(12).Alignment = Alignment.left;
                        table.Rows[HoRow].Cells[2].Paragraphs[0].LineSpacing = (float)12.0;
                        table.Rows[HoRow].Cells[2].VerticalAlignment = VerticalAlignment.Center;
                        table.Rows[HoRow].MergeCells(2, 6);
                        HoRow++;

                        foreach (var levForm in value)
                        {
                            table.Rows[HoRow].Cells[2].Paragraphs[0].Append(levForm.Result);
                            table.Rows[HoRow].Cells[3].Paragraphs[0].Append(levForm.High);
                            table.Rows[HoRow].Cells[4].Paragraphs[0].Append(levForm.Average);
                            table.Rows[HoRow].Cells[5].Paragraphs[0].Append(levForm.BelowMiddle);
                            table.Rows[HoRow].Cells[6].Paragraphs[0].Append(levForm.Low);
                            for (int p = 2; p < 7; p++)
                            {
                                table.Rows[HoRow].Cells[p].Paragraphs[0].Font("Times New Roman").FontSize(11).Alignment = Alignment.center;
                                table.Rows[HoRow].Cells[p].Paragraphs[0].LineSpacing = (float)12.0;
                                table.Rows[HoRow].Cells[p].VerticalAlignment = VerticalAlignment.Center;
                            }

                            HoRow++;
                        }

                        //HoRow++;
                    }
                    table.MergeCellsInColumn(1, IndicRow, HoRow - 1);
                }
                table.MergeCellsInColumn(0, KompRow, HoRow - 1);


            }


            #endregion

            return table;
        }
        private void InitTableChapter(ref List<TableContent> TableChapter, int idrpd)
        {

            Dictionary<int, List<Chapter>> GroupChapters = Chapters.Where(x => x.RPDId == idrpd).GroupBy(x => x.Semestr).ToDictionary(g => g.Key, g => g.ToList());
            if (GroupChapters.Count == 0) return;

            int AllAll = 0;
            int AllSemLek = 0;
            int AllSemLab = 0;
            int AllSemPr = 0;
            int AllSemSrs = 0;
            List<TableRowContent> t = new();
            foreach ((int key, List<Chapter> value) in GroupChapters)
            {
                int SemAll = 0;
                int SemLek = 0;
                int SemLab = 0;
                int SemPr = 0;
                int SemSrs = 0;
                int i = 0;

                foreach (var item in value)
                {
                    int? sumChapter = 0;

                    sumChapter = (item.Lek ?? 0) + (item.Lab ?? 0) + (item.Pr ?? 0) + (item.Srs ?? 0);


                    t.Add(new TableRowContent
                        (
                            new FieldContent("NameChapter", $"Раздел {i + 1}"),
                            new FieldContent("TimeAllChapter", sumChapter.ToString()),
                            new FieldContent("Lek", item.Lek.ToString()),
                            new FieldContent("Lab", item.Lab.ToString()),
                            new FieldContent("Pr", item.Pr.ToString()),
                            new FieldContent("SRS", item.Srs.ToString()),
                            new FieldContent("TK", $"ТК{i + 1}"),
                            new FieldContent("Kompet", item.KompetenString)
                        )
                    );
                    i++;

                    SemAll += sumChapter ?? 0;
                    SemLek += item.Lek ?? 0;
                    SemLab += item.Lab ?? 0;
                    SemPr += item.Pr ?? 0;
                    SemSrs += item.Srs ?? 0;
                }

                List<Certificat> certificats = db.certificats.Where(x => x.IdRPD == idrpd && x.Semestr == key).ToList();
                int j = 0;

                foreach (Certificat certif in certificats)
                {

                    t.Add(new TableRowContent
                        (
                            new FieldContent("NameChapter", certif.NameCert),
                            new FieldContent("TimeAllChapter", certif.Hoirs.ToString()),
                            new FieldContent("Lek", ""),
                            new FieldContent("Lab", ""),
                            new FieldContent("Pr", ""),
                            new FieldContent("SRS", certif.Hoirs.ToString()),
                            new FieldContent("TK", $"ОМ{j + 1}"),
                            new FieldContent("Kompet", certif.KompString ?? "")

                        )
                    );

                }


                t.Add(new TableRowContent(


                   new FieldContent("NameChapter", $"Итого за {key} семестр"),
                   new FieldContent("TimeAllChapter", SemAll.ToString()),
                   new FieldContent("Lek", SemLek.ToString()),
                   new FieldContent("Lab", SemLab.ToString()),
                   new FieldContent("Pr", SemPr.ToString()),
                   new FieldContent("SRS", SemSrs.ToString()),
                   new FieldContent("TK", ""),
                   new FieldContent("Kompet", "")
                   )
                );

                AllAll += SemAll;
                AllSemLek += SemLek;
                AllSemLab += SemLab;
                AllSemPr += SemPr;
                AllSemSrs += SemSrs;

            }


            var TableChapterOne = new TableContent("TableChapter", t);
            TableChapter.Add(TableChapterOne);

            var TableChapterSec = new TableContent("TableChapter");

            TableChapterSec.AddRow(
              new FieldContent("AllAll", AllAll.ToString()),
              new FieldContent("AllLek", AllSemLek.ToString()),
              new FieldContent("AllLab", AllSemLab.ToString()),
              new FieldContent("AllPr", AllSemPr.ToString()),
              new FieldContent("AllSRS", AllSemSrs.ToString())
           );
            TableChapter.Add(TableChapterSec);


        }
        private void GetContentDiscip(ref Paragraph paragraph)
        {
            int i = 0;
            int j = 0;
            Dictionary<int, List<Chapter>> GroupChapters = Chapters.GroupBy(x => x.Semestr).ToDictionary(g => g.Key, g => g.ToList());

            paragraph = paragraph.InsertParagraphAfterSelf("");
            foreach ((int key, List<Chapter> value) in GroupChapters)
            {
                paragraph.Append($"\tСемстр {key} ").Font("Times New Roman").FontSize(14).Bold(true);
                paragraph = paragraph.InsertParagraphAfterSelf("");

                foreach (var Chapter in value)
                {

                    paragraph.Append($"\tРаздел {i + 1}. ").Font("Times New Roman").FontSize(14).Bold(true);
                    paragraph.Append($"{Chapter.NameChapter}").Font("Times New Roman").FontSize(14);
                    // Создание нового параграфа
                    paragraph = paragraph.InsertParagraphAfterSelf("");

                    j = 0;
                    foreach (var Them in Chapter.Themes)
                    {
                        paragraph.Append($"\tТема {i + 1}.{j + 1} {Them.NameTheme}").Font("Times New Roman").FontSize(14);
                        paragraph = paragraph.InsertParagraphAfterSelf("");
                        paragraph.Append($"\t{Them.DescTheme}").Font("Times New Roman").FontSize(14);
                        paragraph = paragraph.InsertParagraphAfterSelf("");
                        j++;
                    }
                    i++;
                }
            }
        }

        private void GetLiter(ref Paragraph paragraph, int index)
        {
            paragraph = paragraph.InsertParagraphAfterSelf("");
            List<rpLit> liters = new();

            if (index == 1)
                liters = rpLitsOne;
            else
                liters = rpLitsSecond;

            if (liters == null) return;

            int i = 1;
            foreach (rpLit lit in liters)
            {
                paragraph.Append($"\t{i}) {lit.LitName}").Font("Times New Roman").FontSize(14);
                if (lit.Adress != null)
                    paragraph.Append($" URL: {lit.Adress}").Font("Times New Roman").FontSize(14);
                paragraph = paragraph.InsertParagraphAfterSelf("");
                i++;
            }
        }

        private string GetKvalific()
        {
            string Vivod = "";

            Vivod = secDb.planProfils.Where(x => Stroka.UchPlanMmisModelId == x.IdPlan).First().Qualification;

            return Vivod;
        }
        private string GetPredDiscip(int Idrpd)
        {
            string Vivod = "";

            string Dicip = rpd.PreviousDisciplines.ToString();
            if (Dicip != null)
                Vivod = Dicip;


            return Vivod;
        }
        private string GetPostDiscip(int Idrpd)
        {
            string Vivod = "";

            string Dicip = rpd.SubsequentDisciplines.ToString();
            if (Dicip != null)
                Vivod = Dicip;

            return Vivod;
        }
        //Оценочные материалы таблица "технологическая карта"


        // перечень оценочных средств
        private TableContent GetEvalutionTable()
        {
            TableContent table = new TableContent("TableEvalution");

            var evaluationTools = db.EvaluationToolsOther
                    .Where(x => x.IdRPD == Idrpd)
                    .Select(p => p.ListAllEvaluationToolsID)
                    .Distinct()
                    .ToList();

            EvaluationToolsOthers.AddRange(evaluationTools);
            foreach (ListAllEvaluationTools item in EvaluationToolsOthers)
            {
                table.AddRow(
                    new FieldContent("NameEvT", item.NameEvaluation),
                    new FieldContent("KharakterEvT", item.Kharakter),
                    new FieldContent("EvaluationTypeEvT", item.EvaluationType)
                    );
            }
            return table;
        }
        // вставка из бд если есть файл
        public FileStreamResult GetFilePKZ()
        {

            // Найти запись в базе данных по идентификатору
            var material = db.MaterialOCWordSegments.FirstOrDefault(m => m.IdRpd == Idrpd);
            if (material == null)
            {
                // Запись не найдена, возвращаем ошибку или другой результат
                return null;
            }

            // Создаем поток для чтения данных файла
            var stream = new MemoryStream(material.WordData);

            // Определяем MIME-тип файла
            string mimeType = "application/octet-stream"; // Предположим, что это бинарный файл

            // Формируем объект FileStreamResult для возврата файла клиенту
            var fileResult = new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "PKZ.docx" // Укажите желаемое имя файла для загрузки
            };

            return fileResult;
        }


    }
}
