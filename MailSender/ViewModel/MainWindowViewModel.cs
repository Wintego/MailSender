using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using SpamTools.lib;
using SpamTools.lib.Database;
using SpamTools.lib.MVVM;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private readonly IDataService _DataService;
        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private EmailRecipients _CurrentRecipient;
        public EmailRecipients CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        //public IEnumerable<EmailRecipients> Recipients => _DataService.GetEmailRecipients();
        public MainWindowViewModel(IDataService DataService)
        {
            _DataService = DataService;
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);
            CreateNewRecipientCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(OnCreateNewRecipientCommandExecute);
            UpdateRecipientCommand = new GalaSoft.MvvmLight.Command.RelayCommand<EmailRecipients>(OnUpdateRecipientCommandExecuted, UpdateRecipientCommandExecute);
        }

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            var db_recipients = _DataService.GetEmailRecipients();
            foreach (var recipient in db_recipients)
            {
                Recipients.Add(recipient);
            }
        }
        private bool CanUpdateRecipientsCommandExecute()
        {
            return true;
        }

        public ObservableCollection<EmailRecipients> Recipients { get; } = new ObservableCollection<EmailRecipients>();
        public ICommand UpdateRecipientsCommand { get; }

        public ICommand CreateNewRecipientCommand { get; }
        public ICommand UpdateRecipientCommand { get; }

        private void OnCreateNewRecipientCommandExecute()
        {
            var recipient = new EmailRecipients {Name = "Получатель", EmailAdress = "user@com"};
            if (_DataService.CreateRecipien(recipient))
            {
                CurrentRecipient = recipient;
                Recipients.Add(recipient);
            }
        }

        private bool UpdateRecipientCommandExecute(EmailRecipients Recipient)
        {
            return true; //Recipient != null || _CurrentRecipient != null;
        }

        private void OnUpdateRecipientCommandExecuted(EmailRecipients Recipient)
        {
            var recipient = Recipient ?? _CurrentRecipient;
            if (recipient is null) return;  
            _DataService.UpdateRecipien(recipient);
        }
    }
}
