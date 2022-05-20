using Microsoft.AspNetCore.Mvc;

namespace AspGraduateProjAdminPan.Areas.BasicInfo.Controllers
{


    /// <summary>
    /// 
    /// </summary>
    [Area("BasicInfo")]
    public class BranchDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
