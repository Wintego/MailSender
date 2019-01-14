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
        public ObservableCollection<SchedulerTask> Tasks => Tasks;

        public Scheduler()
        {
            _Tasks = new ObservableCollection<SchedulerTask>
            {
                new SchedulerTask
                {
                    DateTime = DateTime.Now.Add(TimeSpan.FromMinutes(20)),
                    Recipients = new[]
                    {
                        new EmailRecipients
                        {
                            Id = 1, Name = "Recipient 1", EmailAdress = "recipient1@mail.ru",
                        },
                        new EmailRecipients
                        {
                            Id = 2, Name = "Recipient 2", EmailAdress = "recipient2@mail.ru",
                        },
                        new EmailRecipients
                        {
                            Id = 3, Name = "Recipient 3", EmailAdress = "recipient3@mail.ru",
                        }
                    },
                    MailServer = new MailServer {Adress = "", Port = 2, UseSSL = true},
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
                    DateTime = DateTime.Now.Add(TimeSpan.FromMinutes(40)),
                    Recipients = new[]
                    {
                        new EmailRecipients
                        {
                            Id = 1, Name = "Recipient 1", EmailAdress = "recipient1@mail.ru",
                        },
                        new EmailRecipients
                        {
                            Id = 2, Name = "Recipient 2", EmailAdress = "recipient2@mail.ru",
                        },
                        new EmailRecipients
                        {
                            Id = 3, Name = "Recipient 3", EmailAdress = "recipient3@mail.ru",
                        }
                    },
                    MailServer = new MailServer {Adress = "", Port = 2, UseSSL = true},
                    Sender = new Sender
                    {
                        Adress = "sender@mail.ru",
                        Name = "Sender1",
                        Password = "pas"
                    },
                    Mail = new Mail("subject1", "body1"),
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
