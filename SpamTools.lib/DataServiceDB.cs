using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTools.lib.Database;

namespace SpamTools.lib
{
    public class DataServiceDB: IDataService
    {
        private MailDatabaseDataContext _DataBaseContext;

        public DataServiceDB(MailDatabaseDataContext DataBaseContext)
        {
            _DataBaseContext = DataBaseContext;
        }

        

        public IEnumerable<EmailRecipients> GetEmailRecipients()
        {
            return new ObservableCollection<EmailRecipients>(_DataBaseContext.EmailRecipients);
        }

        public bool UpdateRecipien(EmailRecipients Recipient)
        {
            _DataBaseContext.SubmitChanges();
            return true;
        }
        public bool CreateRecipien(EmailRecipients Recipient)
        {
            _DataBaseContext.EmailRecipients.InsertOnSubmit(Recipient);
            _DataBaseContext.SubmitChanges();
            return Recipient.Id != 0;
        }
    }
}
