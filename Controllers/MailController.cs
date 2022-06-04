using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System;
using AspGraduateProjAdminPan.BL.Helper;

namespace AspGraduateProjAdminPan.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //send mail using SMTP
        //for best Parctice use Model instead of Parmetars
        [HttpPost]
        public IActionResult SendMail(string Title ,string Message)
        {


            ViewBag.er = "rer";
            TempData["ert"] = "from temp";

 
            try
            {
                MailHelper.Sendmail(Title, Message);
                TempData["mes"] = "mail sent successfully";
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                TempData["mes"] = "Something error!";
                TempData["details"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        public IActionResult MailBox()
        {
            return View();


        }

    }
}
