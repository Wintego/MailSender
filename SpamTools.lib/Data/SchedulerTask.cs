using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib.Data
{
    public class SchedulerTask
    {
        public DateTime DateTime { get; set; }
        public IEnumerable<EmailRecipients> Recipients { get; set; }
        public MailServer MailServer { get; set; }
        public Sender Sender { get; set; }
        public Mail Mail { get; set; }
    }
}
