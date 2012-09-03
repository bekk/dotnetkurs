using System.Net.Mail;

namespace Bekk.dotnetintro.TDD.Booking
{
    public class EmailService
    {
        public void Send(Email email)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(email.To);
            mailMessage.Subject = email.Subject;
            mailMessage.From = new MailAddress("someone@something.com");
            mailMessage.Body = email.Body;

            var smtpClient = new SmtpClient("someSmtpHost");
            smtpClient.Send(mailMessage);

        }
    }

    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}