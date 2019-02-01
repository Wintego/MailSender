using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EmailSendService.lib;
using System.Windows.Threading;
using SpamTools.lib.Data;
using SpamTools.lib.Database;

namespace MailSender
{
    public class Scheduler
    {
        private readonly ObservableCollection<SchedulerTask> _Tasks;
        public ObservableCollection<SchedulerTask> Tasks => _Tasks;

        public ObservableCollection<string> strs { get; set; } = 
            new ObservableCollection<string>();

        public Scheduler()
        {
            strs.Add("111");
            strs.Add("222");
            _Tasks = new ObservableCollection<SchedulerTask>
            {
                new SchedulerTask
                {
                    Title = "Письма друзьям",
                    DateTime = DateTime.Now.Add(TimeSpan.FromMinutes(20)),
                    Recipients = new[]
                    {
                        new Recipient
                        {
                            Id = 1, Name = "Recipient 1", Adress = "recipient1@mail.ru",
                        },
                    },
                    MailServer = new MailServer {Adress = "mail.google.com", Port = 35, UseSSL = true},
                    Sender = new Sender
                    {
                        Adress = "sender@mail.ru",
                        Name = "Sender1",
                        Password = "pas"
                    },
                    Mail = new Mail("subject1", "body1"),
                },
                new SchedulerTask
                {
                    Title = "План на месяц",
                    DateTime = DateTime.Now.Add(TimeSpan.FromMinutes(40)),
                    Recipients = new[]
                    {
                        new Recipient
                        {
                            Id = 1, Name = "Recipient 1", Adress = "recipient1@mail.ru",
                        },
                        new Recipient
                        {
                            Id = 2, Name = "Recipient 2", Adress = "recipient2@mail.ru",
                        }
                    },
                    MailServer = new MailServer {Adress = "mail.yandex.ru", Port = 2, UseSSL = true},
                    Sender = new Sender
                    {
                        Adress = "sender@mail.ru",
                        Name = "Sender2",
                        Password = "pas"
                    },
                    Mail = new Mail("subject2", "body2"),
                }
            };
        }

        public Scheduler(IEnumerable<SchedulerTask> tasks)
        {
            _Tasks = new ObservableCollection<SchedulerTask>(tasks);
        }

        public void Start() { }

        public void AddTask(SchedulerTask task)
        {
            if (_Tasks.Contains(task)) return;
            _Tasks.Add(task);
        }

        public bool RemoveTask(SchedulerTask task)
        {
            return _Tasks.Remove(task);
        }

    }
}
