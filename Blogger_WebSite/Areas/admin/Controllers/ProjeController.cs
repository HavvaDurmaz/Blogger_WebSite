
using Blogger_WebSite.Areas.admin.Data;
using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggerWebSite.Areas.admin.Controllers
{

    [Area("admin"), Authorize]
    public class ProjeController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Projects data, IFormFile resim)
        {
            if (resim != null)
            {
                string DosyaAdi = DosyaYukleme.Yukle(resim);
                if (DosyaAdi != "0")
                {
                    data.Images = DosyaAdi;
                    data.UseId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id").Value.ToString());
                    db.Projects.Add(data);
                    db.SaveChanges();
                    ViewBag.Message = "Proje Eklemesi Başarılı";
                }
                else
                {
                    ViewBag.Message = "JPG,JPEG veya PNG uzantılı dosya seçiniz.";
                }
            }
            else
            {
                ViewBag.Message = "Bir Resim Seçiniz.";
            }
            return View();
        }

        [HttpGet, Route("/admin/Proje/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.Projects.Find(id));
        }

        [HttpPost, Route("/admin/Proje/Update/{id}")]
        public IActionResult Update(int id, Projects data, IFormFile resim)
        {

            var Bulunan = db.Projects.First(x => x.id == id);
            if (resim != null)
            {
                string DosyaAdi = DosyaYukleme.Yukle(resim);
                Bulunan.Images = DosyaAdi;
            }
            Bulunan.ProjectName = data.ProjectName;
            Bulunan.ProjectURL = data.ProjectURL;
            db.SaveChanges();

            return View(db.Projects.Find(id));
        }


        [HttpGet, Route("/admin/Proje/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Bulunan = db.Projects.First(x => x.id == id);
            db.Projects.Remove(Bulunan);
            return Redirect("/admin/Proje");
        }

    }
}