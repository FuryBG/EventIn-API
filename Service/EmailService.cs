using System.Net;
using System.Net.Mail;
using System.Text;

namespace Service
{
    public class EmailService
    {
        public void SendEmail(string message, string to)
        {
            MailMessage mailmessage = new MailMessage("office@eventin.com", to);
            mailmessage.Subject = "EventIn - Account Activation";
            mailmessage.Body = message;
            mailmessage.BodyEncoding = Encoding.UTF8;
            mailmessage.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential basicCredential = new NetworkCredential("denis.belqta111@gmail.com", "hloynsbjhhonlaib");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential;
            client.Send(mailmessage);
        }
    }
}
