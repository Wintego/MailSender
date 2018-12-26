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
            List<string> emails = to.Text.Split(',').ToList();

            foreach (var email_addr in emails)
            {
                using (var mm = new MailMessage(this.email.Text, email_addr/*to.Text*/, subject.Text, message.Text))
                {
                    using (var sc = new SmtpClient(WpfTestMailSender.smtp_adress, WpfTestMailSender.smtp_port))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential(this.email.Text, psw.Password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex) { new SendEndWindow($"{email_addr}: {ex.Message}").Show(); }
                    }
                }
            }
            
        }
    }
}
