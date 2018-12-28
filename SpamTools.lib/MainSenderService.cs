using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpamTools.lib
{
    public class MainSenderService
    {
        private string _ServerAdress;
        private int _Port;
        private bool _UseSSL;
        private string _UserName;
        private SecureString _Password;
        public string Subject { get; set; }

        public MainSenderService(string ServerAdress, int Port, bool UseSSL, string UserName, SecureString Password)
        {
            _ServerAdress = ServerAdress;
            _Port = Port;
            _UseSSL = UseSSL;
            _UserName = UserName;
            _Password = Password;
        }

        public void Send(string Subject, string Email, string Address)
        {
            using (var message = new MailMessage(_UserName, Address))
            {
                message.Subject = Subject;
                message.Body = Email;

                using (var client = new SmtpClient(_ServerAdress, _Port))
                {
                    client.EnableSsl = _UseSSL;
                    client.Credentials = new NetworkCredential(_UserName, _Password);
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.ToString());
                    }
                }
            }            
        }
    }
}
