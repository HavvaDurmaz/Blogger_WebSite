using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Blogger_WebSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class loginController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Email, string Sifre)
        {

            var BulunanData = db.Users.Where(x => x.Eposta == Email && x.Sifre == Sifre).FirstOrDefault();
            if (BulunanData != null)
            {

                string YeniKod = new Random().Next(0, 999999).ToString();


                TempData["GirisEmail"] = Email;
                TempData["GirisDogrulama"] = YeniKod;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("noreply@gulerarslan.com", "Doğrulama Kodu");
                mailMessage.Subject = "WebSitesi Giriş Doğrulama Kodu"; // Mail Konusu
                mailMessage.To.Add(Email); // Kullanıcın Email Adresi

                string body = "Doğrulama Kodu : " + YeniKod;
                mailMessage.IsBodyHtml = true; // Mail de HTML Tasaırm Kullanabilirim.
                mailMessage.Body = body;

                SmtpClient smtp = new SmtpClient("mail.gulerarslan.com", 587);
                smtp.Credentials = new NetworkCredential("noreply@gulerarslan.com", "e~4ioV291");
                smtp.EnableSsl = false;
                smtp.Send(mailMessage);

                return Redirect("/admin/Login/Dogrulama");
            }
            else
            {
                ViewBag.Mesaj = "Email Adresi Veya Şifre Hatalı";
            }
            return View();
        }

        public IActionResult Dogrulama()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dogrulama(string Email, string UserDogrulama, string SystemDogrulama)
        {
            var BulunanData = db.Users.Where(x => x.Eposta == Email).FirstOrDefault();
            if (UserDogrulama == SystemDogrulama)
            {
                var claims = new List<Claim> {
                    new Claim("id",BulunanData.id.ToString()),
                    new Claim(ClaimTypes.Role,BulunanData.Roles),
                    new Claim(ClaimTypes.Name,BulunanData.NameSurName),
                };
                var UserIdentity = new ClaimsIdentity(claims, "AdminGirisi");
                var principal = new ClaimsPrincipal(UserIdentity);
                HttpContext.SignInAsync(principal);
                return Redirect("/admin/Kategori");
            }
            else
            {
                return Redirect("/admin/Login");
            }
        }
    }
}
