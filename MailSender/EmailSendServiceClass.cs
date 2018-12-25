using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    class EmailSendServiceClass
    {
        MailMessage mm = new MailMessage(@"berlin.22014@yandex.ru", "3841832@gmail.com","тест","етст");
        SmtpClient sc = new SmtpClient(WpfTestMailSender.smtp_adress, WpfTestMailSender.smtp_port);        
    }
}
