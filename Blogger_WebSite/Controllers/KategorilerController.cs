using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Controllers
{
    public class KategorilerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
