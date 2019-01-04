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
            timePicker.Value = DateTime.Now;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var start = redaktor.Document.ContentStart;
            var end = redaktor.Document.ContentEnd;
            int difference = start.GetOffsetToPosition(end);
            if (difference <= 4)
            {
                new SendEndWindow("Введите текст письма").ShowDialog();
                editLetter.IsSelected = true;
                return;
            }
                

            var server = servers.SelectedItem as SpamTools.lib.Data.MailServer;
            if (server ==  null)
            {
                new SendEndWindow("Сервер не выбран").ShowDialog();
                return;
            }

            var user = users.SelectedItem as SpamTools.lib.Data.Sender;
            if (user == null)
            {
                new SendEndWindow("Отправитель не выбран").ShowDialog();
                return;
            }
            var password = new SecureString();
            
            foreach (var password_char in SpamTools.lib.Service.PasswordService.Decode(user.Password))
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
