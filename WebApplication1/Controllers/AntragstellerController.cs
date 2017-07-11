using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AntragstellerController : Controller
    {
        [HttpPost]
        public JsonResult AntragstellerUpdate(string Data)
        {
            var DeserializeAntragsteller = new JavaScriptSerializer().Deserialize<Antragsteller>(Data);
            var context = new ModelContext();
            var OldAntragsteller = context.Antragstellers.FirstOrDefault(x => x.Number == DeserializeAntragsteller.Number);

            if (OldAntragsteller != null)
            {
                context.Antragstellers.Remove(OldAntragsteller);
                context.Antragstellers.Add(DeserializeAntragsteller);
            }
            else
            {
                context.Antragstellers.Add(DeserializeAntragsteller);
            }
            context.SaveChanges();

            return Json(context.Antragstellers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAntragstellers()
        {
            return Json(new ModelContext().Antragstellers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult KinderUpdate(string Data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FinanzielleUpdate(string Data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ImmobilenUpdate(string Data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BankverbindungUpdate(string Data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}