using System.ComponentModel.DataAnnotations;

namespace Project.Utility
{
    public class SmtpSettings
    {

        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string Password { get; set; }
    }

    //public class EmailModel
    //{
    //    [Key]
    //    public int EmailId { get; set; }

    //    public string SenderEmail { get; set; }
    //    public string RecipientEmail { get; set; }
    //    public string Subject { get; set; }
    //    public string Body { get; set; }


    //}
}

