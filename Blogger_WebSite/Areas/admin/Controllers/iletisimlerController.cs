using Blogger_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class iletisimlerController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }
    }
}
