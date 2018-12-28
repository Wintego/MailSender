using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Security;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<string> emails = to.Text.Split(',').ToList();

            //foreach (var email_addr in emails)
            //{
            //    using (var mm = new MailMessage(this.email.Text, email_addr/*to.Text*/, subject.Text, message.Text))
            //    {
            //        using (var sc = new SmtpClient(WpfTestMailSender.smtp_adress, WpfTestMailSender.smtp_port))
            //        {
            //            sc.EnableSsl = true;
            //            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            //            sc.UseDefaultCredentials = false;
            //            sc.Credentials = new NetworkCredential(this.email.Text, psw.Password);
            //            try
            //            {
            //                sc.Send(mm);
            //            }
            //            catch (Exception ex) { new SendEndWindow($"{email_addr}: {ex.Message}").Show(); }//
            //        }
            //    }
            //}
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var server = servers.SelectedItem as SpamTools.lib.Data.MailServer;
            if (server ==  null)
            {
                new SendEndWindow("Сервер не выбран").ShowDialog();
            }

            var user = users.SelectedItem as SpamTools.lib.Data.Sender;
            if (server == null)
            {
                new SendEndWindow("Отправитель не выбран").ShowDialog();
            }
            var password = new SecureString();
            
            foreach (var password_char in PasswordTools.PasswordService.Decode(user.Password))
            {
                password.AppendChar(password_char);
            }

            var send_mail_service = new SpamTools.lib.MainSenderService(server.Adress, server.Port, server.UseSSL, user.Adress, password);
            send_mail_service.Send("Subject", "Email body", "email@server.com");
        }

        private void PlannerClick(object sender, RoutedEventArgs e)
        {
            planner.IsSelected = true;
        }
    }
}
