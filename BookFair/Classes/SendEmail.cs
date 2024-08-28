using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookFair.Classes.Email.Model
{
    public class SendEmail
    {

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        private SendEmail() { }

        public SendEmail(string subject, string body, string from, string to)
        {

            From = from ?? throw new ArgumentNullException(nameof(from));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            To = to ?? throw new ArgumentNullException(nameof(to));
        }
       
    }
}