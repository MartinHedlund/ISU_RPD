using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using RPD.Models;
using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.Home;
using RPD.Service;
using System.Collections.Generic;
using System.Xml;
using XAct;
using XAct.Users;

namespace RPD.Controllers
{
    public class FunctionPanelController : Controller
    {
        DbService db;
        public FunctionPanelController(DbService db)
        {
            this.db = db;
        }
        // GET: FunctionPanelController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetUserAdmin()
        {
            List<UsersAccess> Model = db.Users
                .GroupJoin(db.UserRoles, ua => ua.UserId, ur => ur.UserId, (ua, roles) => new { UsersAccess = ua, Roles = roles })
                .Select(joined => new UsersAccess
                {
                    Id = joined.UsersAccess.UserId,
                    Name = $"{joined.UsersAccess.LastName} {joined.UsersAccess.FirstName} {joined.UsersAccess.ParentName}",
                    Roles = joined.Roles.ToList()
                })
                .ToList();
            return PartialView("_adminPartic", Model);
        }
        [HttpPost]
        public ActionResult GetUserRole(int UserId)
        {
            List<UserRole> model = db.UserRoles.Where(p=>p.UserId == UserId).ToList();
                
            return PartialView("rolePartic", model);
        }
        [HttpPost]
        public ActionResult ChangeRole(int UserId, int roleId)
        {
            UserRole model = db.UserRoles.FirstOrDefault(p => p.UserId == UserId && p.IdRole == roleId);
            if (model == null)
            {
                db.UserRoles.Add(new UserRole { IdRole = roleId, UserId = UserId });
            }else
            {
                db.UserRoles.Where(p => p.UserId == model.UserId && p.IdRole == model.IdRole).ExecuteDelete();
            }
            db.SaveChanges();

            return Ok();
        }

        // GET: FunctionPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FunctionPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddComment(string CommentText, int IdStroka)
        {
            //OrUpdateCommentAsync
            CommentModel comment = new();
            try
            {
                string NamePerson = HttpContext.Session.GetString("NamePerson");

                if (comment.Id == 0)
                {
                    // Добавление нового комментария
                    comment.IdStroka = IdStroka;
                    comment.CommentText = CommentText;
                    comment.FIO = NamePerson;
                    comment.CreatedAt = DateTime.Now;
                    db.Comments.Add(comment);
                }
                else
                {
                    // Обновление существующего комментария
                    var existingComment = db.Comments.Find(comment.Id);
                    if (existingComment != null)
                    {
                        existingComment.CommentText += comment.CommentText;
                        existingComment.UpdateAt = DateTime.UtcNow;
                    }
                }
                db.SaveChanges();
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: FunctionPanelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FunctionPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FunctionPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FunctionPanelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool IsValidXml(string xmlContent)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }
        /// <summary>
        ///     Возвращает массив int Id которые нужно пометить как удаленными
        /// </summary>
        /// <param name="newRpLit"></param>
        /// <returns>List<int></returns>
        private List<int?> IsDelitedList(List<rpLit> newRpLit) {
            List<int?> newDataLit = newRpLit.Select(x => x.LibId).ToList();
            List<int?> oldDataLit = db.rpLit.Select(x => x.LibId).ToList();
            var result = oldDataLit.Except(newDataLit).ToList();
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Проверка расширения файла
                if (Path.GetExtension(file.FileName).ToLower() != ".xml")
                {
                    // Если файл не является XML, выполните соответствующую обработку ошибки
                    return BadRequest("Неверный формат файла. Ожидается XML файл.");
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                {

                    string xmlContent = await reader.ReadToEndAsync();
                    if (!IsValidXml(xmlContent))
                    {
                        // Если XML не является допустимым, выполните соответствующую обработку ошибки
                        return BadRequest("Недопустимый XML файл.");
                    }
                    List<Record> records = Record.XmlToList(xmlContent);// получаем список записей 

                    List<Dictionary<string, List<string>>> recordsGroup = new();
                    foreach (var record in records)
                    {
                        Dictionary<string, List<string>> groupedFields = new Dictionary<string, List<string>>();

                        foreach (var field in record.Fields)
                        {
                            if (!groupedFields.ContainsKey(field.Tag))
                            {
                                groupedFields[field.Tag] = new List<string>();
                            }

                            if (field.Text != null)
                                groupedFields[field.Tag].Add(field.Text);
                            else
                            {
                                foreach (var item in field.SubFields)
                                {
                                    groupedFields[field.Tag].Add(item.Text);
                                }
                            }

                        }
                        recordsGroup.Add(groupedFields);
                    }


                    List <rpLit> rpLits = new List<rpLit>();

                    foreach (var record in recordsGroup)
                    {
                        rpLit rpLit = new rpLit();
                        // логика для записыания в поля по тегам
                        var propertyMap = new Dictionary<string, Action<string>>()
                            {
                                { "1", value => rpLit.LibId = int.Parse(value) },
                                { "2", value => rpLit.LitName = value },
                                { "610", value => rpLit.KeyWords = value},
                                { "951", value => rpLit.Adress = value },
                                { "701", value => rpLit.Authors = value },
                                { "702", value => rpLit.Authors += value },
                                { "331", value => rpLit.NameProlong = value },
                                { "910", value => rpLit.Volume = value },
                            };

                        foreach (var field in record)
                        {
                            if (propertyMap.TryGetValue(field.Key, out var action))
                            {
                                action(string.Join(", ", field.Value).Replace("\n", string.Empty));
                            }
                        }

                        rpLits.Add(rpLit);
                    }

                    List<int?> PointDelited = IsDelitedList(rpLits);


                    for (int i = 0; i < PointDelited.Count; i++)
                    {
                        int? point = PointDelited[i];
                        if (point != null)
                        {
                            var lit = await db.rpLit.FirstOrDefaultAsync(p => p.LibId == point.Value);
                            if (lit != null)
                            {
                                lit.Deleted = true;
                                db.SaveChanges();
                            }
                        }
                    }
                    var existingLibIds = rpLits.Select(item => item.LibId).ToList();
                    var existingItems = db.rpLit.Where(item => existingLibIds.Contains(item.LibId)).ToList();

                    foreach (var item in rpLits)
                    {
                        var existingItem = existingItems.FirstOrDefault(e => e.LibId == item.LibId);

                        if (existingItem != null)
                        {
                            if (!string.Equals(existingItem.LitName, item.LitName) ||
                                !string.Equals(existingItem.KeyWords, item.KeyWords) ||
                                !string.Equals(existingItem.Adress, item.Adress) ||
                                !string.Equals(existingItem.Authors, item.Authors) ||
                                !string.Equals(existingItem.Volume, item.Volume) ||
                                !string.Equals(existingItem.NameProlong, item.NameProlong))
                            {
                                existingItem.LitName = item.LitName;
                                existingItem.KeyWords = item.KeyWords;
                                existingItem.Adress = item.Adress;
                                existingItem.Volume = item.Volume;
                                existingItem.Authors = item.Authors;
                                existingItem.NameProlong = item.NameProlong;
                            }
                        }
                        else
                        {
                            db.rpLit.Add(item);
                        }
                    }

                    db.SaveChanges();

                }
            } else return BadRequest("Файл не выбран.");
            return RedirectToAction("Index", "Home");
        }
    }
}
