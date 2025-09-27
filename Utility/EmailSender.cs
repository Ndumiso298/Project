using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _config;

    public EmailSender(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        
        var fromEmail = _config["EmailSettings:FromEmail"];
        var Username = _config["EmailSettings:Username"];
        var Password = _config["EmailSettings:Password"]; 
        var SmtpHost = _config["EmailSettings:SmtpHost"];
        var SmtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);

       
        var message = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        message.To.Add(to);

        using (var smtp = new SmtpClient(SmtpHost, SmtpPort))
        {
            smtp.Credentials = new NetworkCredential(Username, Password);
            smtp.EnableSsl = true;  
            await smtp.SendMailAsync(message);
        }
    }
}
