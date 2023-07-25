using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Areas.admin.Controllers {

    [Area("admin"), Authorize]
    public class KategoriController : Controller {

        //using BloggerWebSite.Models;
        DatabaseContext db = new DatabaseContext();

        public IActionResult Index() {
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Insert() {

            return View();
        }

        [HttpPost]
        public IActionResult Insert(Categories data,IFormFile Images) {

            if (Images != null) {
                string Uzanti = Path.GetExtension(Images.FileName);
                if (Uzanti == ".jpg" || Uzanti == ".png" ||Uzanti == ".jpeg" ) {

                    string YeniDosyaAdi = new Random().Next(1,999999999) + Uzanti;
                    string YuklenecekAdres = Path.Combine(Directory.GetCurrentDirectory(),$"wwwroot/images",YeniDosyaAdi);
                    using (var stream = new FileStream(YuklenecekAdres,FileMode.CreateNew)) {
                        Images.CopyTo(stream);
                    }
                    data.Images = YeniDosyaAdi;
                    db.Categories.Add(data);
                    db.SaveChanges();
                    ViewBag.Mesaj = "İşlem Başarılı";
                }
                else {
                    ViewBag.Mesaj = "JPG,JPEG veya PNG uzantılı dosya seçiniz.";
                }
            }
            else {
                ViewBag.Mesaj = "Bir Resim Seçiniz.";
            }

            return View();
        }

        [HttpGet]
        [Route("/admin/Kategori/Update/{id}")]
        public IActionResult Update(int id) {
            return View(db.Categories.Find(id));
        }

        [HttpPost]
        [Route("/admin/Kategori/Update/{id}")]
        public IActionResult Update(int id,Categories data, IFormFile Images) {

            if (Images != null) { // Resim seçilmiş ise Resimli güncelleme
                string Uzanti = Path.GetExtension(Images.FileName);
                if (Uzanti == ".jpg" || Uzanti == ".jpeg" || Uzanti == ".png" ) {

                    string YeniDosyaAdi = new Random().Next(1, 999999999) + Uzanti;
                    string YuklenecekAdres = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images", YeniDosyaAdi);
                    using (var stream = new FileStream(YuklenecekAdres, FileMode.CreateNew)) {
                        Images.CopyTo(stream);
                    }
                    var Bulunan = db.Categories.Find(id);
                    Bulunan.CategoryName = data.CategoryName;
                    Bulunan.Images = YeniDosyaAdi;
                    db.SaveChanges();
                    ViewBag.Mesaj = "İşlem Başarılı";
                }
                else {
                    ViewBag.Mesaj = "JPG,JPEG veya PNG uzantılı dosya seçiniz.";
                }
            }
            else { // Resim Seçilmemiş ise Resimsiz Güncelleme olacak.
                var Bulunan = db.Categories.Find(id);
                Bulunan.CategoryName = data.CategoryName;
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }

            return View(db.Categories.Find(id));
        }


        [HttpGet]
        [Route("/admin/Kategori/delete/{id}")]
        public IActionResult Delete(int id) {
            var Bulunan = db.Categories.Find(id);
            db.Categories.Remove(Bulunan);
            db.SaveChanges();
            return Redirect("/admin/kategori");
        }


    }
}
