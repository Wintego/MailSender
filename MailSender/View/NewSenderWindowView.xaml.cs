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
using System.Windows.Shapes;
using SpamTools.lib.Data;

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для NewSenderWindowView.xaml
    /// </summary>
    public partial class NewSenderWindowView : Window
    {
        public Sender Sender { get; set; }
        public NewSenderWindowView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Инициализация окна изменения данных отправителя
        /// </summary>
        /// <param name="sender"></param>
        public NewSenderWindowView(Sender sender)
        {
            InitializeComponent();
            Sender = sender;
            SenderButton.Content = "Изменить";
            this.Title = SenderButton.Content + " отправителя";
            this.DataContext = Sender;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Sender newSender = new Sender() {Name = Name.Text, Adress = Adress.Text, Password = Password.Text};
            using (var db = new SpamTools.lib.Data.DataBaseContext())
            {
                db.Senders.Add(newSender);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
