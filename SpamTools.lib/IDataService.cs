using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTools.lib.Data;

namespace SpamTools.lib
{
    public interface IDataService
    {
        //IEnumerable<EmailRecipients> GetEmailRecipients();
        IEnumerable<Recipient> GetEmailRecipients();

        bool UpdateRecipien(Recipient Recipient);
        bool CreateRecipien(Recipient Recipient);
    }
}
