using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;
using SpamTools.lib.Data;
using SpamTools.lib.Database;

namespace MailSender
{
    class EmailSendServiceClass
    {
        #region vars
        private string strLogin;
        private string strPassword;
        private string strSmtp = "smtp.yandex.ru";
        private int iSmtpPort = 25;
        private string strBody;
        private string strSubject;
        #endregion
        public EmailSendServiceClass(string sLogin, string sPassword)
        {
            strLogin = sLogin;
            strPassword = sPassword;
        }
        private void SendMail(string mail, string name)
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = "Hello world!";
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                }
            }
        }//private void SendMail(string mail, string name)
        public void SendMails(ObservableCollection<Sender> emails)
        {
            foreach (Sender email in emails)
            {
                SendMail(email.Adress, email.Name);
            }
        }

    } //private void SendMail(string mail, string name)
}
