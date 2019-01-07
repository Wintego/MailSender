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
    //public class MainSenderService
    //{
    //    private string _ServerAdress;
    //    private int _Port;
    //    private bool _UseSSL;
    //    private string _FromLogin;
    //    private SecureString _FromPassword;
    //    public string Subject { get; set; }

    //    public MainSenderService(string ServerAdress, int Port, bool UseSSL, string FromLogin, SecureString FromPassword)
    //    {
    //        _ServerAdress = ServerAdress;
    //        _Port = Port;
    //        _UseSSL = UseSSL;
    //        _FromLogin = FromLogin;
    //        _FromPassword = FromPassword;
    //    }

    //    public void Send(string to, string subject, string body)
    //    {
    //        using (var message = new MailMessage(_FromLogin, to))
    //        {
    //            message.Subject = subject;
    //            message.Body = body;

    //            using (var client = new SmtpClient(_ServerAdress, _Port))
    //            {
    //                client.EnableSsl = _UseSSL;
    //                client.Credentials = new NetworkCredential(_FromLogin, _FromPassword);
    //                //client.UseDefaultCredentials = false;
    //                try
    //                {
    //                    client.Send(message);
    //                }
    //                catch (Exception ex)
    //                {
    //                    Trace.TraceError(ex.Message);
    //                    Trace.TraceError(ex.ToString());
    //                }
    //            }
    //        }            
    //    }
    //}
}
