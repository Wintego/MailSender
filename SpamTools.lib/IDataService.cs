using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib
{
    public interface IDataService
    {
        IEnumerable<EmailRecipients> GetEmailRecipients();

        bool UpdateRecipien(EmailRecipients Recipient);
        bool CreateRecipien(EmailRecipients Recipient);
    }
}
