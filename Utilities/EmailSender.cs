using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Project.Utilities
{
    //public class EmailSender : IEmailSender
    //{
    //    Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        return Task.CompletedTask;
    //    }
    //}

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using var mail = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:From"]),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            using var smtpServer = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true
            };
            await smtpServer.SendMailAsync(mail);
        }
    }
}
