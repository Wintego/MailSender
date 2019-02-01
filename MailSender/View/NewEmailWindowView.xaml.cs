using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Xceed.Wpf.Toolkit;

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для NewEmailWindowView.xaml
    /// </summary>
    public partial class NewEmailWindowView : Window
    {
        public NewEmailWindowView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SpamTools.lib.Data.SchedulerTask task = new SpamTools.lib.Data.SchedulerTask()
            {
                DateTime = (DateTime) DateTimePicker.Value,
                Recipients = Recipients.SelectedItems as IList<Recipient>,
                MailServer = Servers.SelectedItem as MailServer,

            };
        }
    }
}
