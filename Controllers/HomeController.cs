using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ColorCards()
        {
            return View();
        }
    }
}
