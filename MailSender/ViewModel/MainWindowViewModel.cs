using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using SpamTools.lib;
using SpamTools.lib.Data;
using SpamTools.lib.Database;
using SpamTools.lib.MVVM;
using SpamTools.lib.Service;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private readonly IDataService _DataService;

        private readonly Scheduler _Scheduler = new Scheduler();
        public Scheduler Scheduler => _Scheduler;

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

        private Recipient _CurrentRecipient;
        public Recipient CurrentRecipient
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
            FindRecipientCommand = new RelayCommand(OnFindRecipientCommandExecute,true);
            SendMailCommand = new RelayCommand(OnSendMailCommandExecute, true);
            AddNewEmailCommand = new RelayCommand(OnAddNewEmailCommandExecute, true);
            ExportRecipientCommand = new RelayCommand(OnExportRecipientExecute, true);
            SenderAddCommand = new RelayCommand(OnSenderAddCommandExecute,true);

            Senders = new ObservableCollection<Sender>();
            Recipients = new ObservableCollection<Recipient>();
            using (var db = new SpamTools.lib.Data.DataBaseContext())
            {
                foreach (var sender in db.Senders)
                    Senders.Add(sender);
                foreach (var recipient in db.Recipients)
                    Recipients.Add(recipient);
            }
            
        }

        private void OnUpdateRecipientsCommandExecuted()
        {
            //Recipients.Clear();
            //var db_recipients = _DataService.GetEmailRecipients();
            //foreach (var recipient in db_recipients)
            //{
            //    Recipients.Add(recipient);
            //}
        }
        private bool CanUpdateRecipientsCommandExecute()
        {
            return true;
        }

        public ObservableCollection<Sender> Senders { get; }
        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();
        public ICommand UpdateRecipientsCommand { get; }
        public ICommand CreateNewRecipientCommand { get; }
        public ICommand UpdateRecipientCommand { get; }
        private void OnCreateNewRecipientCommandExecute()
        {
            //var recipient = new EmailRecipients {Name = "3841832", EmailAdress = "3841832@gmail.com" };
            //if (_DataService.CreateRecipien(recipient))
            //{
            //    CurrentRecipient = recipient;
            //    Recipients.Add(recipient);
            //}
        }
        private bool UpdateRecipientCommandExecute(EmailRecipients Recipient)
        {
            return true; //Recipient != null || _CurrentRecipient != null;
        }
        private void OnUpdateRecipientCommandExecuted(EmailRecipients Recipient)
        {
            //var recipient = Recipient ?? _CurrentRecipient;
            //if (recipient is null) return;  
            //_DataService.UpdateRecipien(recipient);
        }
        private string _SearchValue;
        public string SearchValue
        {
            get => _SearchValue;
            set => Set(ref _SearchValue, value);
        }
        public ICommand FindRecipientCommand { get; }
        public void OnFindRecipientCommandExecute()
        {
            //if(SearchValue is null)
            //    return;
            //Recipients.Clear();
            //var db_recipients = _DataService.GetEmailRecipients();
            ////var filter = db_recipients.Where(recipient => recipient.Name.Contains(SearchValue));
            //var filter = from recipient in db_recipients
            //    where recipient.Name.Contains(SearchValue)
            //    select recipient;
            //foreach (var recipient in filter)
            //    Recipients.Add(recipient);
        }
        public MailServer SelectedServer { set; get; }
        public Sender SelectedSender { set; get; }
        public ICommand SendMailCommand { get; }
        private void OnSendMailCommandExecute()
        {

            var password = new SecureString();
            foreach (var password_char in SpamTools.lib.Service.PasswordService.Decode(SelectedSender.Password))
                password.AppendChar(password_char);

            var from = SelectedSender.Adress;
            var to = CurrentRecipient.Adress;
            var senderService = new EmailSendService.lib.SenderService(
                SelectedServer.Adress,
                SelectedServer.Port,
                SelectedServer.UseSSL,
                SelectedSender.Adress,
                password
                );
            var p2 = PasswordService.Decode(SelectedSender.Password);
            senderService.Send(to, "subject", "body");
        }
        public ICommand AddNewEmailCommand { get; set; }
        private void OnAddNewEmailCommandExecute()
        {
            var a = new View.NewEmailWindowView().ShowDialog();
        }
        public ICommand ExportRecipientCommand { get; set; }
        private void OnExportRecipientExecute()
        {
            var doc = new SpamTools.lib.Service.GeneratedClass();
            doc.header = "Список получателей";

            foreach (var recipient in Recipients)
                doc.body.Add($"{recipient.Id}. {recipient.Name} {recipient.Adress}");
            doc.CreatePackage("export.docx");
            Status = "Экспорт выполнен";
        }

        public ICommand SenderAddCommand { get; set; }
        private void OnSenderAddCommandExecute()
        {
            new MailSender.View.Senders().ShowDialog();
        }
    }
}
