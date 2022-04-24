using Microsoft.AspNetCore.Mvc;

namespace AspGraduateProjAdminPan.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }

        //i slect method type to prevent showing data in browser,so i only access it using http post method browser 
        //dose not support POST method
        //ajax call////////////////

         [HttpPost]
        public JsonResult getUserData(int x, int y)
        {
             
            return Json(x*y);
        }
    }
}
