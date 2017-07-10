using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AntragstellerController : Controller
    {
        [HttpPost]
        public JsonResult AntragstellerUpdate(/*string data*/)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
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