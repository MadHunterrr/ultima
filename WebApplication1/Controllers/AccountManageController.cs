using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountManageController : Controller
    {
        [HttpPost]
        public JsonResult AddUser(string data)
        {
            JObject o = JObject.Parse(data);

            using (var context = new ModelContext())
            {
                using (var md5Hash = MD5.Create())
                {
                    foreach (var item in context.Benutzers)
                    {
                        if (item.Email.Equals((string)o["Email"]))
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                    }

                    context.Benutzers.Add(new Benutzer
                    {
                        AuthKey = DateTime.Now.Ticks,
                        PrimaryRole = (byte)o["PrimaryRole"],
                        Email = (string)o["Email"],
                        Password = GetMd5Hash(md5Hash, (string)o["Password"])
                    });
                }
                context.SaveChanges();
            }
            return Json("Registration successful!", JsonRequestBehavior.AllowGet);
        }
        //{PrimaryRole: "true", Email: "DimaMorgun97@gmail.com", Password: "qwerty"}

        [HttpPost]
        public JsonResult Authentication(string data)
        {
            JObject o = JObject.Parse(data);

            using (var context = new ModelContext())
            {
                using (var md5Hash = MD5.Create())
                {
                    foreach (var item in context.Benutzers)
                    {
                        if (item.Email.Equals((string)o["Email"]) && item.Password.Equals(GetMd5Hash(md5Hash, (string)o["Password"])))
                        {
                            Session["Role"] = item.PrimaryRole;
                            Session["AuthKey"] = item.AuthKey;
                            return Json("All matches correct!", JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        //{Email: "DimaMorgun97@gmail.com", Password: "qwerty"}

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public JsonResult GetUser()
        {
            return Json(new object[] { Session["Role"], Session["AuthKey"] }, JsonRequestBehavior.AllowGet);
        }
    }
}