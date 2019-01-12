using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTools.lib.Database;

namespace SpamTools.lib.Data
{
    class Email
    {
        public DateTime Time { get; set; }
        public Sender From { get; set; }
        public EmailRecipients To { get; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Email(DateTime time, EmailRecipients to, string subject, string content)
        {
            Time = time;
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
