using Microsoft.AspNetCore.Mvc;

namespace ASP_ZALUUPA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
