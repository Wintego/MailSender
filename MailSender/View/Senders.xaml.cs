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
    /// Логика взаимодействия для Senders.xaml
    /// </summary>
    public partial class Senders : Window
    {
        public Senders()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SpamTools.lib.Data.DataBaseContext())
            {
                db.Senders.Add(new Sender() {Name = Name.Text, Adress = Email.Text, Password = Password.Text});
            }
            this.Close();
        }
    }
}
