using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        public JsonResult GetAllWerbungs()
        {
            return Json(new ModelContext().Werbungs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllKontakts()
        {
            return Json(new ModelContext().Kontakts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllBanks()
        {
            return Json(new ModelContext().Bankens, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAdressens()
        {
            return Json(new ModelContext().Adressens, JsonRequestBehavior.AllowGet);
        }
    }
}