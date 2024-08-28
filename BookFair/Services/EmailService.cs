using BookFair.Interfaces;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using BookFair.Classes.Email.Model;
using System.Web.Mail;
using BookFair.Controllers;
namespace BookFair.Services
{
    public class EmailService : IEmail
    {

        private static EmailService _instance;

        private EmailService() { }

        public static EmailService getInstance()
        {
            if (_instance == null)
            {
                _instance = new EmailService();
            }
            return _instance;

        }

        public async Task SendEmail(SendEmail email, string BodyType = null)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect("smtp.gmail.com", 465, true);

                    client.Authenticate("arcodiet@gmail.com", "kvjmwrlzzpxmcfqp");
                    var bodyBuilder = new BodyBuilder
                    {
                        HtmlBody = BodyType == "html" ? email.Body : null,
                        TextBody = BodyType != "html" ? email.Body : null,

                    };


                    var message = new MimeMessage { Body = bodyBuilder.ToMessageBody() };
                    message.From.Add(new MailboxAddress("Book Fair Team", email.From));
                    message.To.Add(new MailboxAddress("User", email.To));
                    message.Subject = email.Subject;

                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}