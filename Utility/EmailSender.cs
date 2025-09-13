
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

public class EmailSender : IEmailSender
{
    Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //TODO use goggle to push 
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("noreply@gmail.com");
        mail.To.Add(email);
        mail.Subject = subject;
        mail.Body = htmlMessage;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("smartchills3@gmail.com", "6W26r$TaN5DsE7y");
        smtpServer.EnableSsl = true;

        smtpServer.Send(mail);

        return Task.CompletedTask;
    }
}