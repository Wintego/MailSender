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

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для RecipientsEditorView.xaml
    /// </summary>
    public partial class RecipientsEditorView : UserControl
    {
        public RecipientsEditorView()
        {
            InitializeComponent();
        }

        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            var event_sender = (Control) sender;
            if (e.Action == ValidationErrorEventAction.Added)
            {
                event_sender.ToolTip = e.Error.ErrorContent.ToString();
            }
            else event_sender.ToolTip = "";
        }
    }
}
