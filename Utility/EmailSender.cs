using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Method = RestSharp.Method;

namespace Project.Utilities
{
    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
    //public class EmailSender : IEmailSender
    //{
    //    private readonly IConfiguration _config;

    //    public EmailSender(IConfiguration config)
    //    {
    //        _config = config;
    //    }

    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        try
    //        {
    //            var apiKey = _config["EmailSettingsNondu:ApiKey"];
    //            var domain = _config["EmailSettingsNondu:Domain"];
    //            var from = _config["EmailSettingsNondu:From"];

    //            var options = new RestClientOptions("https://api.mailgun.net")
    //            {
    //                Authenticator = new HttpBasicAuthenticator("api", apiKey)
    //            };

    //            var client = new RestClient(options);
    //            var request = new RestRequest($"/v3/{domain}/messages", Method.Post);
    //            request.AlwaysMultipartFormData = true;

    //            request.AddParameter("from", from);
    //            request.AddParameter("to", email);
    //            request.AddParameter("subject", subject);
    //            request.AddParameter("html", htmlMessage);

    //            var response = await client.ExecuteAsync(request);

    //            if (!response.IsSuccessful)
    //            {
    //                throw new Exception($"Mailgun error: {response.StatusCode} - {response.Content}");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception($"Failed to send email: {ex.Message}");
    //        }
    //    }
    //}
}