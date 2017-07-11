using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountManageController : Controller
    {
        public JsonResult GetAllUsers()
        {
            return Json(new ModelContext().Benutzers.Select(x => new
            {
                BenutzerId = x.BenutzerId,
                PrimaryRole = x.PrimaryRole,
                Email = x.Email
            }), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUser(string Data)
        {
            var DeserializeBenutzer = new JavaScriptSerializer().Deserialize<Benutzer>(Data);
            var context = new ModelContext();

            if (context.Benutzers.FirstOrDefault(x => x.Email == DeserializeBenutzer.Email) != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                context.Benutzers.Add(new Benutzer()
                {
                    AuthKey = DateTime.Now.Ticks,
                    PrimaryRole = DeserializeBenutzer.PrimaryRole,
                    Email = DeserializeBenutzer.Email,
                    Password = Hash.GetMd5Hash(MD5.Create(), DeserializeBenutzer.Password)
                });
                context.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Authentication(string Data)
        {
            var DeserializeBenutzer = new JavaScriptSerializer().Deserialize<Benutzer>(Data);
            var CryptedPassword = Hash.GetMd5Hash(MD5.Create(), DeserializeBenutzer.Password);
            var CurrentBenutzer = new ModelContext().Benutzers.FirstOrDefault(
                x => x.Email == DeserializeBenutzer.Email &&
                x.Password == CryptedPassword);

            if (CurrentBenutzer != null)
            {
                Session["Role"] = CurrentBenutzer.PrimaryRole;
                Session["AuthKey"] = CurrentBenutzer.AuthKey;
                Session["Email"] = CurrentBenutzer.Email;

                return Json(new
                {
                    Role = CurrentBenutzer.PrimaryRole,
                    AuthKey = CurrentBenutzer.AuthKey,
                    Email = CurrentBenutzer.Email
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}