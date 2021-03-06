﻿using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib.Data
{
    public class SchedulerTask
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public IList<Recipient> Recipients { get; set; }
        public MailServer MailServer { get; set; }
        public Sender Sender { get; set; }
        public Mail Mail { get; set; }
        public string Title { get; set; }
    }
}
