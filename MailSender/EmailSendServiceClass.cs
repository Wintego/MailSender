using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
    static class EmailSendServiceClass
    {        
        //public static void Send(MainWindow mw)
        //{
        //    var start = mw.redaktor.Document.ContentStart;
        //    var end = mw.redaktor.Document.ContentEnd;
        //    int difference = start.GetOffsetToPosition(end);
        //    if (difference <= 4)
        //    {
        //        new SendEndWindow("Введите текст письма").ShowDialog();
        //        mw.editLetter.IsSelected = true;
        //        return;
        //    }


        //    var server = mw.servers.SelectedItem as SpamTools.lib.Data.MailServer;
        //    if (server == null)
        //    {
        //        new SendEndWindow("Сервер не выбран").ShowDialog();
        //        return;
        //    }

        //    var user = mw.users.SelectedItem as SpamTools.lib.Data.Sender;
        //    if (user == null)
        //    {
        //        new SendEndWindow("Отправитель не выбран").ShowDialog();
        //        return;
        //    }
        //    var password = new SecureString();

        //    foreach (var password_char in SpamTools.lib.Service.PasswordService.Decode(user.Password))
        //    {
        //        password.AppendChar(password_char);
        //    }

        //    var send_mail_service = new SpamTools.lib.MainSenderService(server.Adress, server.Port, server.UseSSL, user.Adress, password);
        //    send_mail_service.Send("Subject", "Email body", "email@server.com");
        //}
    }
}
