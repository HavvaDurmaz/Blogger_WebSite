using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Controllers
{
    public class iletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
