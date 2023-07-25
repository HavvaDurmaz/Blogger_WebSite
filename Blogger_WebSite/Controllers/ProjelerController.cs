using Microsoft.AspNetCore.Mvc;

namespace Blogger_WebSite.Controllers
{
    public class ProjelerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
