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
            var context = new ModelContext();
            var Files = context.Dateis;

            return Json(Files, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetFilesById(int id)
        {
            var context = new ModelContext();
            var Files = from x in context.Dateis
                        where x.FamilyUnionId == id
                        select x;

            return Json(Files, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteFileById(int id)
        {
            var context = new ModelContext();
            var File = context.Dateis.FirstOrDefault(x => x.DateiId == id);

            if (File != null)
            {
                System.IO.File.Delete(Server.MapPath("~/Files/" + File.LocalFileName));

                context.Dateis.Remove(File);
                context.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }   
        }
        [HttpPost]
        public FileResult DownloadFileById(int id)
        {
            var context = new ModelContext();
            var FileObject = context.Dateis.FirstOrDefault(x => x.DateiId == id);

            if (FileObject != null)
            {
                var FileName = FileObject.FileName;
                string FileType = "application";
                var FilePath = Server.MapPath("~/Files/" + FileObject.LocalFileName);

                return File(FilePath, FileType, FileName);
            }
            else
            {
                return File(Server.MapPath("~/Files/Error.txt"), "Error.txt");
            }
        }
        [HttpGet]
        public FileResult DownloadFileByLocalFileName(string name)
        {
            var context = new ModelContext();
            var FileObject = context.Dateis.FirstOrDefault(x => x.LocalFileName == name);

            if (FileObject != null)
            {
                var FileName = FileObject.FileName;
                string FileType = "application";
                var FilePath = Server.MapPath("~/Files/" + FileObject.LocalFileName);

                return File(FilePath, FileType, FileName);
            }
            else
            {
                return File(Server.MapPath("~/Files/Error.txt"), "Error.txt");
            }
        }
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase upload, int id)
        {
            if (upload != null)
            {
                var context = new ModelContext();
                var fileName = System.IO.Path.GetFileName(upload.FileName);
                var LastFileName = string.Format("{0}{1}", DateTime.Now.Ticks, fileName);

                context.Dateis.Add(new Datei() {
                    FileName = fileName,
                    LocalFileName = LastFileName,
                    FamilyUnionId = id,
                    //DownloadLink = "http://itls-hh.eu/Document/DownloadFileByLocalFileName?name=" + LastFileName
                    DownloadLink = "http://localhost:28151/Document/DownloadFileByLocalFileName?name=" + LastFileName
                });
                context.SaveChanges();

                upload.SaveAs(Server.MapPath("~/Files/" + LastFileName));

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}