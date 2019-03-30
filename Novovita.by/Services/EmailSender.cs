using Novovita.by.Models;
using System.Net;
using System.Net.Mail;

namespace Novovita.by.Services
{
    public static class EmailSender
    {
        public static void Send(EmailMessage emailMessage)
        {
            MailAddress from = new MailAddress(emailMessage.Email, emailMessage.Name+"  "+ emailMessage.Phone);
            MailAddress to = new MailAddress("export@novovita.by");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Вопрос с формы обратной связи";
            m.Body = emailMessage.Message;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("info.Novovita.by@gmail.com", "sgSuybtP9Gn4D9i");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
