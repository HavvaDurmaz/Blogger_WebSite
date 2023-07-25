using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogger_WebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            DatabaseContext db = new DatabaseContext();

            var BulunanDatalar = db.Bloggers.Include("Categories").ToList();
            // db.Bleggers.Include("Categories").ToList()=> Blogları getirirken, onun kategotrinde yanında getir. (Inner Join )
            return View(db.Bloggers.Include("Categories").ToList());
        }
        [Route("/Blog/Detay/{id}")]

        [Route("/Blog/Detay/{id}")]

        public IActionResult Detay(int id)
        {
            DatabaseContext db = new DatabaseContext();
            return View(db.Bloggers.Where(x => x.id == id).Include("Categories").First());
        }
    }
}
