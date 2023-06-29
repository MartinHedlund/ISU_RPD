
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;
using NuGet.Packaging.Core;
using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD;
using RPD.Models.Mtod;
using RPD.Service;
using RPD.ViewModel;
using System.ComponentModel;
using System.Linq.Expressions;
using XAct;

namespace RPD.Controllers
{
    public class MtodController : Controller
    {
        MtodViewModel ViewModel;
        DbService db;
        DbSecondService secDb;
        private readonly ILogger<MtodController> _logger;
        public MtodController(ILogger<MtodController> logger, DbService db, DbSecondService secDb)
        {
            this.ViewModel = new();
            this.db = db;
            this.secDb = secDb;
            _logger = logger;
        }

        // GET: MtodController
        //public IActionResult Liter()
        //{
        //    return View(ViewModel);
        //}
        [HttpGet]
        public async Task<IActionResult> Liter()
        {
            ViewModel.RpLits = db.rpLit.ToList();
            int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
            List<LiterRPD> context = db.literRPDs.Where(i=>i.IdRPD == IdRPD).ToList();
            if(context != null)
                foreach(var item in context)
                    ViewModel.RpLits.FirstOrDefault(p=> p.IdLit == item.IdLit).Chois = true;
            return View(ViewModel);
        }

        public ActionResult AddLiter(int IdLiter)
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                LiterRPD context = db.literRPDs.FirstOrDefault(x => x.IdRPD == IdRPD && x.Id == IdLiter);

                if (context == null)
                {
                    LiterRPD liter = new()
                    {
                        IdLit = IdLiter,
                        IdRPD = IdRPD,
                        Type = 1,
                    };
                    db.literRPDs.Add(liter);
                    db.SaveChanges();
                    return Ok(new { mes = "Добавлено", success = true });
                }
                else
                {
                    return Ok(new { mes = "Уже добавленна", success = false });
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        } 
        public ActionResult DeleteLiter(int IdLiter)
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                LiterRPD DelLiter = db.literRPDs.Where(x => x.IdLit == IdLiter && x.IdRPD == IdRPD).First();
                db.literRPDs.Remove(DelLiter); 
                db.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetLiter()
        {
            try
            {

                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                
                List<LiterRPD> LiterId = db.literRPDs.Where(x => x.IdRPD == IdRPD).ToList();
                if (LiterId.Count == 0)
                { return BadRequest(); }
                List<rpLit> literRPDs = db.rpLit.Where(x => LiterId.Select(x=>x.IdLit).Contains(x.IdLit)).ToList();

                foreach (var item in literRPDs)
                {
                    item.Type = Convert.ToInt32(LiterId.Where(x => x.IdLit == item.IdLit).Select(x => x.Type).FirstOrDefault());
                }
                
                return PartialView("LiterChoisView", literRPDs);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult ChangeTypeLiter(int IdType, int IdLiter)
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
             
                LiterRPD literRPD = db.literRPDs.Where(x => x.IdRPD == IdRPD && x.IdLit == IdLiter).FirstOrDefault();
                literRPD.Type = IdType;
                db.SaveChanges();
                return Ok();
            }
            catch(Exception ex) { return BadRequest(); }
        }

        [HttpGet]
        public async Task<IActionResult> LiterT()
        {
            ViewModel.ProductTeches = db.ProductTeches.ToList();
            int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
            List<ProductTechRPD> context = db.productTechRPDs.Where(i => i.IdRPD == IdRPD).ToList();
            if (context != null)
                foreach (var item in context)
                    ViewModel.ProductTeches.FirstOrDefault(p => p.Id == item.ProductTechId).Cheked = true;
            return View(ViewModel);
        }
        public ActionResult AddProductTech (int idProd)
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                ProductTechRPD context = db.productTechRPDs.FirstOrDefault(x=>x.IdRPD == IdRPD && x.Id == idProd);
                if (context == null) {
                    ProductTechRPD productTech = new()
                    {
                        ProductTechId = idProd,
                        IdRPD = IdRPD,

                    };
                    db.productTechRPDs.Add(productTech);
                    db.SaveChanges();
                    return Ok(new { mes = "Добавлено", success = true });
                }
                else
                {
                    return Ok(new {mes = "Уже добавленна", success = false});
                }
                
                

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        public ActionResult DeleteProductTech(int idProd)
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                ProductTechRPD DelProd = db.productTechRPDs.Where(x => x.ProductTechId == idProd && x.IdRPD == IdRPD).First();
                db.productTechRPDs.Remove(DelProd);
                db.SaveChanges();
                return Ok(new { mes = "Удалено", success = true });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetProduct()
        {
            try
            {
                int index = 1;
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");
                List<int> ProductId = db.productTechRPDs.Where(x => x.IdRPD == IdRPD).Select(x => x.ProductTechId).ToList();
                if (ProductId.Count == 0)
                { return BadRequest(); }
                List<ProductTech> productTeches = db.ProductTeches.Where(x => ProductId.Contains(x.Id)).ToList();
                

                return PartialView("productTechesView", productTeches);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        public ActionResult Index()
        {
            try
            {
                int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");

                List<AuditoriyRPD> MtoRPDs = db.AuditoriyRPDs.Where(x => x.idRpd == IdRPD).ToList();


                //ViewModel.ClassRoom = db.AuditoriyRPDs.Select(x => new ClassRoomModel
                //{
                //    Id = x.Id,
                //    RoomNumber = x.AudNum,
                //    Appointments = x.Desc,
                //    Equipment = x.Equipment,

                //}).OrderBy(p=>p.RoomNumber).ToList();

                //foreach (var item in MtoRPDs)
                //{
                //    var Class = ViewModel.ClassRoom.Where(x => x.Id == item.IdMto).FirstOrDefault();
                //    if(Class != null)
                //    {
                //        Class.Cheked = true;
                //    }
                //}


                //if(MtoRPDs.Count != 0)
                //{
                //    ViewModel.CCRoom = MtoRPDs.Select(x => new ChoisClassRoom
                //    {
                //        IdClassRoom = x.IdMto,
                //        TypeClassRoom = x.Type != null ? x.Type.Split(", ").Select(int.Parse).ToList() : null
                //    }).ToList();
                //}
            }
            catch(Exception ex)
            {
                
            }

            return View(ViewModel);
        }

        // GET: MtodController/Details/5
        [HttpPost]
        public ActionResult Index(MtodViewModel ViewModel)
        {
            int IdRPD = (int)HttpContext.Session.GetInt32("IdRPD");

            List<AuditoriyRPD> MtoRPDs = db.AuditoriyRPDs.Where(x => x.idRpd == IdRPD).ToList();

            List<int> existingIds = MtoRPDs.Select(x => x.Id).ToList();

            //foreach (var item in ViewModel.CCRoom)
            //{
            //    if (!existingIds.Contains(item.IdClassRoom))
            //    {
            //        MtoRPD newMto = new MtoRPD
            //        {
            //            IdRPD = IdRPD,
            //            IdMto = item.IdClassRoom,
            //            Type = item.TypeClassRoom.Count != 0? string.Join(", ", item.TypeClassRoom):null // Установите значение свойства Type на соответствующее
            //    };

            //        db.mtoRPDs.Add(newMto);
            //    }
            //}

            //List<MtoRPD> itemsToRemove = MtoRPDs.Where(x => !ViewModel.CCRoom.Select(c => c.IdClassRoom).Contains(x.IdMto)).ToList();
            //db.mtoRPDs.RemoveRange(itemsToRemove);

            //db.SaveChanges();


            //ViewModel.ClassRoom = db.AuditoriyRPDs.Select(x => new ClassRoomModel
            //{
            //    Id = x.Id,
            //    RoomNumber = x.AudNum,
            //    Appointments = x.Desc,
            //    Equipment = x.Equipment
            //}).OrderBy(p => p.RoomNumber).ToList();

            return View(ViewModel);
        }



    }
}
