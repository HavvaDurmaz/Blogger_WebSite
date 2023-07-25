using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Areas.admin.Controllers
{
    [Area("admin"), Authorize]

    public class KullanicilarController : Controller
    {

        DatabaseContext db = new DatabaseContext();

        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }


        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Insert(Users data) 
        {
            db.Users.Add(data);
            db.SaveChanges();
            ViewBag.Message = "Kullanıcı Eklemesi Başarılı";
            return View();
        }


        [HttpGet, Route("/admin/Kullanicilar/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.Users.Find(id));
        }

        [HttpPost, Route("/admin/Kullanicilar/Update/{id}")]
        public IActionResult Update(int id, Users data)
        {
            Users Bulunan = db.Users.First(x=> x.id == id);
            Bulunan.Eposta = data.Eposta;
            Bulunan.NameSurName = data.NameSurName;
            Bulunan.Phone = data.Phone;
            Bulunan.Roles = data.Roles;
            db.SaveChanges();
            ViewBag.Message = "Kullanıcı Güncellemesi Başarılı";
            return View(db.Users.Find(id));
        }


        [HttpGet, Route("/admin/Kullanicilar/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Users Bulunan = db.Users.First(x => x.id == id);
            db.Users.Remove(Bulunan);
            db.SaveChanges();   
            return Redirect("/admin/Kullanicilar");
        }
    }
}
