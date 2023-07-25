using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Controllers
{
    public class MakalelerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
