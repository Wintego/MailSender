using SpamTools.lib.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendService.lib
{
    public class SenderService
    {
        private string _ServerAdress;
        private int _Port;
        private bool _UseSSL;
        private string _FromLogin;
        private SecureString _FromPassword;
        public string Subject { get; set; }

        public SenderService(string ServerAdress, int Port, bool UseSSL, string FromLogin, SecureString FromPassword)
        {
            _ServerAdress = ServerAdress;
            _Port = Port;
            _UseSSL = UseSSL;
            _FromLogin = FromLogin;
            _FromPassword = FromPassword;
        }

        public String Send(string to, string subject, string body)
        {
            string response = default(string);
            using (var message = new MailMessage(_FromLogin, to))
            {
                message.Subject = subject;
                message.Body = body;

                using (var client = new SmtpClient(_ServerAdress, _Port))
                {
                    client.EnableSsl = _UseSSL;
                    client.Credentials = new NetworkCredential(_FromLogin, _FromPassword);
                    try
                    {
                        client.Send(message);
                        response = $"Письмо успешно отправлено на почту {to}";
                    }
                    catch (Exception ex)
                    {
                        response = "Ошибка: "+ex.Message;
                    }
                }
            }

            return response;
        }
        public void SendMails(ObservableCollection<Sender> emails)
        {
            foreach (Sender email in emails)
            {
                Send(email.Adress, email.Name, "");
            }
        }
    }
}
