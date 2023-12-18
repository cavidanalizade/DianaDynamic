using System.Net;
using System.Net.Mail;

namespace DianaDynamic.Helper
{
    public class MailSender
    {
        public static void SendConfirmationEmail(string toEmail, string confirmationLink)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "bd7q9887u@code.edu.az";
            string smtpPassword ="12345678";

            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(smtpUsername);
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Subscribe Email";
                mailMessage.Body = "You are subscribed";
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }
    }
}
