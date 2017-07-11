using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DocumentController : Controller
    {
        public JsonResult GetAllFiles()
        {
            return Json(new ModelContext().Dateis, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteFileById(int Id)
        {
            var context = new ModelContext();
            var CurrentFile = context.Dateis.FirstOrDefault(x => x.DateiId == Id);

            if (CurrentFile != null)
            {
                System.IO.File.Delete(Server.MapPath("~/Files/" + CurrentFile.LocalFileName));

                context.Dateis.Remove(CurrentFile);
                context.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public FileResult DownloadFileByLocalFileName(string Name)
        {
            var CurrentFile = new ModelContext().Dateis.FirstOrDefault(x => x.LocalFileName == Name);

            if (CurrentFile != null)
            {
                var FileName = CurrentFile.FileName;
                var FileType = "application";
                var FilePath = Server.MapPath("~/Files/" + CurrentFile.LocalFileName);

                return File(FilePath, FileType, FileName);
            }
            else
            {
                return File(Server.MapPath("~/Files/Error.txt"), "Error.txt");
            }
        }
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase Upload, int Id)
        {
            if (Upload != null)
            {
                var context = new ModelContext();
                var FileName = System.IO.Path.GetFileName(Upload.FileName);
                var LastFileName = string.Format("{0}{1}", DateTime.Now.Ticks, FileName);

                context.Dateis.Add(new Datei()
                {
                    FileName = FileName,
                    LocalFileName = LastFileName,
                    EntryId = Id,
                    DownloadLink = "http://itls-hh.eu/Document/DownloadFileByLocalFileName?name=" + LastFileName
                });
                context.SaveChanges();

                Upload.SaveAs(Server.MapPath("~/Files/" + LastFileName));

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}