using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System;
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

                SmtpClient smtpClient = new SmtpClient { Host = "smtp.gmail.com", Port = 575, EnableSsl = true };
                smtpClient.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                smtpClient.Send("as8338873@gmail.com", "mahmoudsaleam11@gmail.com", Title, Message);
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
