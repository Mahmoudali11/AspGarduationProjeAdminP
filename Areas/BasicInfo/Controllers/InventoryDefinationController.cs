using Microsoft.AspNetCore.Mvc;

namespace AspGraduateProjAdminPan.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class InventoryDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
