using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;
using WebApplication1.Models.DeserializeHelpModel.Antragsteller;

namespace WebApplication1.Controllers
{
    public class AntragstellerController : Controller
    {
        [HttpPost]
        public JsonResult AntragstellerUpdate(string data)
        {
            var DeserializeAntragsteller = new JavaScriptSerializer().Deserialize<AntragstellersRootObject>(data);

            var context = new ModelContext();
            var OldAntragsteller = context.Antragstellers.FirstOrDefault(x => x.Number == DeserializeAntragsteller.antragstellers.Number);
            var NewAntragsteller = new Antragsteller()
            {
                Entry = DeserializeAntragsteller.antragstellers.Entry,
                Number = DeserializeAntragsteller.antragstellers.Number,
                Sex = DeserializeAntragsteller.antragstellers.Sex,
                Vorname = DeserializeAntragsteller.antragstellers.Vorname,
                SecondName = DeserializeAntragsteller.antragstellers.SecondName,
                Code = DeserializeAntragsteller.antragstellers.Code,
                Phone = DeserializeAntragsteller.antragstellers.Phone,
                Email = DeserializeAntragsteller.antragstellers.Email,
                Comment = DeserializeAntragsteller.antragstellers.Comment,
                DateBirthd = DeserializeAntragsteller.antragstellers.DateBirthd,
                Street = DeserializeAntragsteller.antragstellers.Street,
                House = DeserializeAntragsteller.antragstellers.House,
                Plz = DeserializeAntragsteller.antragstellers.Plz,
                Ort = DeserializeAntragsteller.antragstellers.Ort,
                Seit = DeserializeAntragsteller.antragstellers.Seit,
                Famili = DeserializeAntragsteller.antragstellers.Famili,
                Country = DeserializeAntragsteller.antragstellers.Country,
                Art = DeserializeAntragsteller.antragstellers.Art,
                Netto = DeserializeAntragsteller.antragstellers.Netto,
                Arbeitgeber = DeserializeAntragsteller.antragstellers.Arbeitgeber,
                Prof = DeserializeAntragsteller.antragstellers.Prof,
                Dr = DeserializeAntragsteller.antragstellers.Dr
            };

            if (OldAntragsteller != null)
            {
                context.Antragstellers.Remove(OldAntragsteller);
                context.Antragstellers.Add(NewAntragsteller);
            }
            else
            {
                context.Antragstellers.Add(NewAntragsteller);
            }
            context.SaveChanges();

            return Json(context.Antragstellers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAntragstellers()
        {
            return Json(new ModelContext().Antragstellers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult KinderUpdate(string data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FinanzielleUpdate(string data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ImmobilenUpdate(string data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BankverbindungUpdate(string data)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}