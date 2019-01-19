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
using System.Threading;
using System.Threading.Tasks;
using SpamTools.lib.Database;

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

        public void Send(string to, string subject, string body)
        {
            //string response = default(string);
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
                        //response = $"Письмо успешно отправлено на почту {to}";
                    }
                    catch (Exception ex)
                    {
                        //response = "Ошибка: "+ex.Message;
                    }
                }
            }
            //return response;
        }
        /// <summary>
        /// массовое отправление писем
        /// </summary>
        /// <param name="subject">тема письма</param>
        /// <param name="body">тело письма</param>
        /// <param name="recipients">получатели письма</param>
        public void SendParallel(string subject, string body, IEnumerable<EmailRecipients> recipients)
        {
            foreach (var recipient in recipients)
            {
                var sending_thread = new Thread(() => Send(recipient.EmailAdress, subject, body));
                sending_thread.IsBackground = true;
                sending_thread.Start();
            }
        }
        public void Send(string subject, string body, IEnumerable<EmailRecipients> recipients)
        {
            foreach (var recipient in recipients)
            {
                Task.Factory.StartNew(()=> Send(subject, body, recipient.EmailAdress));
            }
        }
    }
}
