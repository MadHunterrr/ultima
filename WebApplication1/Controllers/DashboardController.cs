﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        public JsonResult GetAllWerbungs()
        {
            var context = new ModelContext();
            var Werbung = context.Werbungs;

            return Json(Werbung, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllKontakts()
        {
            var context = new ModelContext();
            var Kontakt = context.Kontakts;

            return Json(Kontakt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllBanks()
        {
            var context = new ModelContext();
            var Banken = context.Bankens;

            return Json(Banken, JsonRequestBehavior.AllowGet);
        }
    }
}