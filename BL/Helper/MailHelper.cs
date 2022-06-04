using System;
using System.Net;
using System.Net.Mail;

namespace AspGraduateProjAdminPan.BL.Helper
{
    public class MailHelper
    {


        public   static void Sendmail(string title,string message)
        {

            try
            {
                SmtpClient smtpClient = new SmtpClient { Host = "smtp.gmail.com", Port = 575, EnableSsl = true };
                smtpClient.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                smtpClient.Send("as8338873@gmail.com", "mahmoudsaleam11@gmail.com", title, message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
