using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Project.Utility
{
    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            ////TODO use google to push 

            //MailMessage mail = new MailMessage();

            //mail.From = new MailAddress("noreply@gmail.com");

            //mail.To.Add(email);

            //mail.Subject = subject;

            //mail.Body = htmlMessage;

            //SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            //smtpServer.Port = 587;

            //smtpServer.Credentials = new NetworkCredential("ogmananga@gmail.com", "KhaaanSolo#330");

            //smtpServer.EnableSsl = true;

            //smtpServer.Send(mail);

            return Task.CompletedTask;
        }
    }
}

