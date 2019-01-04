using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SpamTools.lib;
using SpamTools.lib.Database;

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

        //public IEnumerable<EmailRecipients> Recipients => _DataService.GetEmailRecipients();
        public MainWindowViewModel(IDataService DataService)
        {
            _DataService = DataService;
        }

        public IEnumerable<EmailRecipients> Recipients { get; } = new ObservableCollection<EmailRecipients>();
    }
}
