using Microsoft.AspNetCore.Mvc;
using RPD.Models;
using RPD.Service;
using System.Text;
using XAct.Library.Settings;
using XSystem.Security.Cryptography;

namespace RPD.Controllers
{
    public class AutorizController : Controller
    {
        DbService db;

        public AutorizController(ILogger<HomeController> logger, DbService db)
        {
            this.db = db;
        }

        public ActionResult authorization()
        {
            ViewData["HideNavigation"] = true;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(UserAuth user) // Авторизация
        {
            try
            {
                var UserProfile = db.UserMoodleProfiles.Where(x => x.UserName == user.Login.Trim()).FirstOrDefault();
                var hash = "";
                using (var sha1 = new SHA1CryptoServiceProvider())
                {
                    var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                    hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
                //UserProfile.IdUserType == 1
                //TODO 470 943

                if (UserProfile != null && UserProfile.Pass == hash && UserProfile.IdUserType == 1)
                {
                    int _idUser = db.Users.First(x => x.IdPerson == (int)UserProfile.IdPerson).UserId;
                    HttpContext.Session.SetInt32("IdUser", _idUser);
                    HttpContext.Session.SetInt32("IdUserProfile", UserProfile.IdUser);
                    HttpContext.Session.SetInt32("IdPerson", (int)UserProfile.IdPerson);
                    var nameperson = $"{UserProfile.LastName} {UserProfile.FirstName[..1]}. {UserProfile.ParentName[..1]}.";
                    HttpContext.Session.SetString("NamePerson", nameperson);
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Неверный пароль" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { success = false, message = "Неверный логин" });
            }

            //return Ok();
            //return RedirectToAction("authorization");
            // переход на другую страницу
        }
    }
}
