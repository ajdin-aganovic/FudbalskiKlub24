using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using AutoMapper;

namespace FudbalskiKlub.Subscriber
{
    public class EmailJS
    {
        //private readonly IConfiguration _configuration;
        //public EmailJS(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public class EmailModelToParse
        {
            public string Sender { get; set; }
            public string Recipient { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
        }
        //public async Task SendEmailAsync(Dictionary<string, string> templateParams)
        //public async Task SendEmailAsync(string message)
        public async Task SendEmail(string to, string subject, string body)
        {
            try
            {
                using var httpClient = new HttpClient();

                string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER") ?? "smtp.gmail.com";
                int smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT") ?? "587");
                string fromMail = Environment.GetEnvironmentVariable("SMTP_USERNAME") ?? "aplikacijafudbalskogkluba@gmail.com";
                //string password = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "afk12345678";
                string password = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "leneytiifigvuucr";

                var smtpClient = new SmtpClient()
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    //Port = 465,
                    Credentials = new NetworkCredential(fromMail, password),
                    EnableSsl = true
                };

                MailMessage MailMessageObj = new MailMessage();

                MailMessageObj.From = new MailAddress(fromMail);
                MailMessageObj.Subject = subject;
                MailMessageObj.Body = body;
                MailMessageObj.IsBodyHtml = true;
                MailMessageObj.To.Add(to);

                //smtpClient.Send(MailMessageObj);
                await smtpClient.SendMailAsync(MailMessageObj);

                smtpClient.Dispose();
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP error sending email: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error sending email: {ex.Message}");
            }
        }
    }
}
