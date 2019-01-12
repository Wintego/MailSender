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
        public DateTime Time { get; }
        public EmailRecipients To { get; }
        public string Subject { get; }
        public string Content { get; }

        public Email(DateTime time, EmailRecipients to, string subject, string content)
        {
            Time = time;
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
