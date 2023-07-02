using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RPD.Models.BD_model;
using RPD.Models.Content;
using RPD.Models.Material;
using RPD.Service;
using RPD.ViewModel;
using System.Runtime.InteropServices;
using TemplateEngine.Docx;

namespace RPD.Controllers
{
    public class MaterialOCController : Controller
    {
        DbService db;
        MaterialViewModel viewModel = new MaterialViewModel();
        int _IdRPDlocal;

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
        //}

        public MaterialOCController(DbService context)
        {
            db = context;

        }

        [HttpPost]
        public ActionResult ParticalOCList(int sem, int razdel, int id)
        {
            try
            {
                var model = db.ListAllEvaluationTools.FirstOrDefault(p => p.Id == id);
                EvaluationToolsOthers temp = new EvaluationToolsOthers { ListAllEvaluationToolsID = model, ListAllEvaluationToolsIDId = id };
                return PartialView(temp);
            }
            catch (Exception ex)
            {
                ListAllEvaluationTools listAllEvaluationTools = new ListAllEvaluationTools();
                Console.WriteLine(ex.Message);
                return PartialView(listAllEvaluationTools);
            }

        }
        [HttpPost]
        public async Task<IActionResult> SaveFormModel(List<Chapter> Razdels, List<int> ListEvaluationToolsId)
        {
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
            viewModel.EvaluationToolsListOthers = db.EvaluationToolsOther.Where(x => x.IdRPD == _IdRPDlocal).ToList();
            viewModel.Razdels = db.Chapter.Include(p => p.EvaluationToolsOthers).ThenInclude(c => c.ListAllEvaluationToolsID).Where<Chapter>(c => c.RPDId == _IdRPDlocal).ToList();
            foreach (Chapter item in Razdels)
            {
                int tempSumDopBall = 0;
                foreach (EvaluationToolsOthers Ev in item.EvaluationToolsOthers)
                {
                    if(Ev.Id != 0)
                    {
                        EvaluationToolsOthers prev  = viewModel.EvaluationToolsListOthers.FirstOrDefault(p => p.Id == Ev.Id)!;
                        tempSumDopBall += Ev.DopBall ?? 0;
                        if (prev.Ball == Ev.Ball && prev.DopBall == Ev.DopBall) continue;
                        prev.Ball = Ev.Ball;
                        prev.DopBall = Ev.DopBall;
                        db.SaveChanges();
                    }
                    else
                    {
                        Ev.ChapterId = item.Id;
                        Ev.IdRPD = _IdRPDlocal;
                        db.EvaluationToolsOther.Add(Ev);
                        db.SaveChanges();
                    }
                    
                }
                if (item.Id != 0)
                {
                    var cont = viewModel.Razdels.First(p => p.Id == item.Id);
                    cont.SumBall = item.SumBall;
                    cont.SumDopBall = tempSumDopBall;
                    db.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }


        public ActionResult Index()
        {
            //db.EvaluationToolsOther.Add(new EvaluationToolsOthers(){ ChapterId = 1, DopBall = 8, Ball = 10, IdRPD = 8});
            //db.SaveChanges();
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
            viewModel.Razdels = db.Chapter.Include(p => p.EvaluationToolsOthers).ThenInclude(c => c.ListAllEvaluationToolsID).Where<Chapter>(c => c.RPDId == _IdRPDlocal).ToList();
            viewModel.ListAllEvaluationTools = db.ListAllEvaluationTools.ToList();
            viewModel.NumSemList = viewModel.Razdels.Select(p => p.Semestr).Distinct().ToList();
            viewModel.ListOfControlTasks = db.ListOfControlTasks.ToList().Where(task => viewModel.Razdels.Any(chapter => chapter.Id == task.ChapterIDid!)).ToList();
            viewModel.EvaluationToolsListOthers = db.EvaluationToolsOther.Where(x => x.IdRPD == _IdRPDlocal).ToList();
            viewModel.Rating = db.RatingScales.FirstOrDefault(x => x.IdRpd == _IdRPDlocal) ?? new RatingScale();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var EvT = await db.EvaluationToolsOther.FindAsync(id);

            if (EvT == null) return RedirectToAction("Index");
            db.EvaluationToolsOther.Remove(EvT);
            await db.SaveChangesAsync();

            //return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult AddRatingScale(RatingScale rating)
        {
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");

            if (rating.Id == 0)
            {
                rating.IdRpd = _IdRPDlocal;
                db.RatingScales.Add(rating);
                db.SaveChanges();
            }
            else
            {
                RatingScale? temp = db.RatingScales.Find(rating.Id);
                if (temp != null)
                {
                    temp.Excellent = rating.Excellent;
                    temp.Good = rating.Good;
                    temp.Satisfactory = rating.Satisfactory;
                    temp.UnSatisfactory = rating.UnSatisfactory;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddListOfConTasks(List<ContentItem> contentList)
        {
            try
            {
                foreach (ContentItem item in contentList)
                {
                    ListOfControlTasks context = db.ListOfControlTasks.FirstOrDefault(x => x.ChapterIDid == item.ChapterId);
                    if (context != null && context.Id != 0)
                    {
                        context.StrokaHTML = item.Content;
                        context.ChapterIDid = item.ChapterId;
                        db.SaveChanges();

                    }
                    else
                    {
                        context = new ListOfControlTasks();
                        context.StrokaHTML = item.Content;
                        context.ChapterIDid = item.ChapterId;
                        db.ListOfControlTasks.Add(context);
                        db.SaveChanges();

                    }
                }
                return Ok(new { result = true });
            }
            catch (Exception ex)
            {

                return BadRequest(new { result = ex.Message });
            }
            
            
        }

        public IActionResult DownLoadTemplate()
        {
            
            string[] paths3 = { @"~/assets", "PKZ_Template.docx" };

            var InputPathTemplate = Path.Combine(paths3);

            try
            {
                var file = File(InputPathTemplate, "text/plain", "Шаблон заполнения.docx");
                return file;
            }
            catch (Exception)
            {
                return BadRequest("Не работает");
            }
      
        }
        [HttpPost]
        public async Task<IActionResult> UploadFilePKZ(IFormFile file)
        {
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
            if (Path.GetExtension(file.FileName).ToLower() != ".docx")
            {
                // Если файл не является XML, выполните соответствующую обработку ошибки
                return BadRequest("Неверный формат файла. Ожидается .docx файл.");
            }
            if (file == null || file.Length == 0)
            {
                return BadRequest("Файл не выбран или пустой");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                Random random = new Random();
                int minValue = int.MinValue; // Минимальное значение для генерации
                int maxValue = int.MaxValue; // Максимальное значение для генерации

                int generatedValue = random.Next(minValue, maxValue);

                var fileEntity = new MaterialOCWordSegment
                {
                    IdRpd = _IdRPDlocal,
                    SerialNumber = generatedValue,
                    WordData = memoryStream.ToArray()
                };
                var context = db.MaterialOCWordSegments.FirstOrDefault(x => x.IdRpd == _IdRPDlocal);
                if(context != null)
                {
                    context.WordData = fileEntity.WordData;
                    db.SaveChanges();
                }
                else
                {
                    db.MaterialOCWordSegments.Add(fileEntity);
                    db.SaveChanges();
                }
                

                // Добавьте код для сохранения сущности в базу данных с использованием Entity Framework

                return Ok("Файл успешно загружен");
            }
        }
        public IActionResult DownloadFile()
        {
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
            // Найти запись в базе данных по идентификатору
            var material = db.MaterialOCWordSegments.FirstOrDefault(m => m.IdRpd == _IdRPDlocal);
            if (material == null)
            {
                // Запись не найдена, возвращаем ошибку или другой результат
                return BadRequest();
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
        [HttpPost]
        public IActionResult DeletePKZFile()
        {
            _IdRPDlocal = (int)HttpContext.Session.GetInt32("IdRPD");
            var context = db.MaterialOCWordSegments.FirstOrDefault(x=>x.IdRpd ==_IdRPDlocal);
            if (context != null) {
                db.MaterialOCWordSegments.Remove(context);
                db.SaveChanges();
                return Ok();
            }else { return BadRequest(); }
        }

    }
}

#region Использовалось можно смотреть для примера
//[HttpPost]
//public async Task<IActionResult> UpdateTechnologicalData(List<Technological_mapOther> item, List<int> ListEvaluationToolsId)
//{

//    for (int i = 0; i < item.Count(); i++)
//        viewModel.Technological_MapsOthers.Where(m => m.Id == item[i].Id).First().Description = item[i].Description;

//    await db.SaveChangesAsync();
//    //return new PartialViewResult { ViewName = "EvaluationTools"};  
//    return RedirectToAction("Index", viewModel);
//}
//public async Task<IActionResult> Technological(int Technological_mapOtheerId, int NumRazdel)
//{

//    //dynamic id = Technological_mapOtheerId;
//    //var selectitem = await db.Technological_maps.FindAsync(id);
//    //if (selectitem == null) return RedirectToAction("Index");
//    //Technological_mapOther toolsOther = new(selectitem){ IdRPD = _IdRPDlocal }; /// id рпод по которой будет происходить выборка
//    //db.Technological_mapOthers.Add(toolsOther);
//    //await db.SaveChangesAsync();
//    return RedirectToAction("Index", viewModel);
//}
//      [HttpPost]
//public async Task<IActionResult> TechnologiMap(List<Technological_mapOther> item)
//{

//	for (int i = 0; i < item.Count(); i++)
//		viewModel.Technological_MapsOthers.Where(m => m.Id == item[i].Id).First().Description = item[i].Description;

//	await db.SaveChangesAsync();
//	return Json(viewModel);
//}
//[HttpPost]
//public async Task<IActionResult> Create(MaterialViewModel et)
//{
//    dynamic id = et.EvaluationToolsId;
//    var selectitem = await db.EvaluationTools.FindAsync(id);
//    if (selectitem == null) return RedirectToAction("Index");
//    await db.SaveChangesAsync();

//    return RedirectToAction("Index");
//}
//[HttpPost]
//public async Task<IActionResult> DeleteTechnological(int id)
//{
//    var person = await db.Technological_mapOthers.FindAsync(id);

//    db.Technological_mapOthers.Remove(person!);
//    await db.SaveChangesAsync();

//    return RedirectToAction("Index");
//}
#endregion