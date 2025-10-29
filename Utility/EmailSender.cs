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
        try
        {
            // Use the exact keys from your appsettings.json
            var fromEmail = _config["SmtpSettings:SenderEmail"];
            var password = _config["SmtpSettings:Password"];
            var smtpHost = _config["SmtpSettings:Host"];
            var smtpPortStr = _config["SmtpSettings:Port"]?.ToString();

            // Validate configuration values
            if (string.IsNullOrEmpty(fromEmail))
                throw new ArgumentNullException(nameof(fromEmail), "SenderEmail is not configured");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "Password is not configured");
            if (string.IsNullOrEmpty(smtpHost))
                throw new ArgumentNullException(nameof(smtpHost), "Host is not configured");
            if (string.IsNullOrEmpty(smtpPortStr))
                throw new ArgumentNullException(nameof(smtpPortStr), "Port is not configured");

            // Parse port with validation
            if (!int.TryParse(smtpPortStr, out int smtpPort))
            {
                throw new FormatException($"Invalid SMTP port: {smtpPortStr}");
            }

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(to);

            using (var smtp = new SmtpClient(smtpHost, smtpPort))
            {
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
            // Log the error or handle it appropriately
            throw new InvalidOperationException($"Failed to send email: {ex.Message}", ex);
        }
    }
}