using Blogger_WebSite.Areas.admin.Data;
using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blogger_WebSite.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class MakaleController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        public IActionResult Index()
        {

            return View(db.Bloggers.ToList());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Kategoriler = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile resim, Bloggers data)
        {
            if (resim != null)
            {
                string YeniAdi = DosyaYukleme.Yukle(resim);
                if (YeniAdi != "0")
                {

                    data.Images = YeniAdi;
                    data.UsersId = Convert.ToInt32(User.Claims.First(x => x.Type == "id").Value.ToString());
                    data.PublishDate = DateTime.Now;
                    db.Bloggers.Add(data);                   
                    db.SaveChanges();
                    ViewBag.Mesaj = "İşlem Başarılı";
                }
                else
                {
                    ViewBag.Mesaj = "PNG,JPG veya JPEG uzantılı Dosya Seçiniz";
                }
            }
            else
            {
                ViewBag.Mesaj = "Resim Seçiniz";
            }
            ViewBag.Kategoriler = db.Categories.ToList();
            return View();
        }

        [HttpGet, Route("/admin/Makale/Update/{id}")]
        public IActionResult Update(int id)
        {
            ViewBag.Kategoriler = db.Categories.ToList();
            return View(db.Bloggers.Find(id));
        }

        [HttpPost, Route("/admin/Makale/Update/{id}")]
        public IActionResult Update(int id, IFormFile resim, Bloggers data)
        {
            var BulunanData = db.Bloggers.FirstOrDefault(x => x.id == id);
            if(resim != null)
            {
                string YeniAdi = DosyaYukleme.Yukle(resim);
                if(YeniAdi != "0")
                {
                    BulunanData.Images = YeniAdi;
                }
                else
                {
                    ViewBag.Mesaj = "PNG,JPG veya JPEG uzantılı Dosya Seçiniz";
                }
            }
            BulunanData.BlogName = data.BlogName;
            BulunanData.Explanation = data.Explanation;
            BulunanData.CategoriesId = data.CategoriesId;
            db.SaveChanges();
            ViewBag.Mesaj = "İşlem Bşaralı";
            ViewBag.Kategoriler = db.Categories.ToList();
            return View(db.Bloggers.Find(id));
        }

        [HttpGet,Route("/admin/Makale/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var BulunanData = db.Bloggers.First(x => x.id == id);
            db.Bloggers.Remove(BulunanData);
            db.SaveChanges();
            return View();
        }
    }
}