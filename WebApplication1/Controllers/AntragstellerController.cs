using System.Collections.Generic;
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


        //--------------code----------------//
        [HttpPost]
        public JsonResult BasisangabenUpdate(string Data)
        {
            var DeserializeBasisangaben = new JavaScriptSerializer().Deserialize<Basisangaben>(Data);
            var Context = new ModelContext();
            var OldBasisangaben = Context.Basisangabens.FirstOrDefault(x => x.Entry == DeserializeBasisangaben.Entry);

            if (OldBasisangaben != null)
            {
                Context.Basisangabens.Remove(OldBasisangaben);
                Context.Basisangabens.Add(DeserializeBasisangaben);
            }

            else
                Context.Basisangabens.Add(DeserializeBasisangaben);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult StellplatzeUpdate(string Data)
        {
            var DeserializeStellplatze = new JavaScriptSerializer().Deserialize<List<Stellplatze>>(Data);
            var Context = new ModelContext();
            var CurrentStellplatze = new List<Stellplatze>();

            foreach(var item in Context.Stellplatzes)
            {
                if(item.Entry== DeserializeStellplatze[0].Entry)
                {
                    CurrentStellplatze.Add(item);
                }
            }
            if (CurrentStellplatze.Count != 0)
            {
                foreach (var item in Context.Stellplatzes)
                {
                    Context.Stellplatzes.Remove(item);
                }
            }
            
            foreach(var item in DeserializeStellplatze)
            {
                Context.Stellplatzes.Add(item);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}