using System.Collections.Generic;
using SpamTools.lib.Data;
using SpamTools.lib.Service;

namespace SpamTools.lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpamTools.lib.Data.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SpamTools.lib.Data.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<Sender> Senders = new List<Sender>
            {
                new Sender {Name = "Ivanov", Adress = "ivanov@mail.ru" , Id=1},
                new Sender {Name = "Petrov", Adress = "petrov@mail.ru", Id=2},
                new Sender {Name = "Sidorov", Adress = "sidorov@mail.ru", Id=3},
                new Sender {Name = "Ya", Adress = "berlin.22014@yandex.ru", Password = PasswordService.Encode("password"), Id=4}
            };
            context.Senders.AddRange(Senders);

            List<Recipient> Recipient = new List<Recipient>
            {
                new Recipient {Id = 1, Name="Recipient 1", Adress="recipient1@mail.ru"},
                new Recipient {Id = 2, Name="Recipient 2", Adress="recipient2@mail.ru"},
                new Recipient {Id = 3, Name="Recipient 3", Adress="recipient3@mail.ru"}
            };
            context.Recipients.AddRange(Recipient);

            List<MailServer> Servers = new List<MailServer>
            {
                new MailServer {Id = 1, Adress = "smtp.yandex.ru", Port = 465, UseSSL = true}
            };
            context.Servers.AddRange(Servers);

            SchedulerTask task = new SchedulerTask()
            {
                DateTime = DateTime.Now,
                Mail = new Mail("testsubject", "test body"),
                MailServer = new MailServer("mail.server.com"),
                Title = "title",
                Sender = new Sender() {Id = 555, Adress = "test@sender.com", Name = "Test Sender"},
                Recipients = new[]
                {
                    new Recipient() {Name = "test recipient", Adress = "test@recipient.com"}
                }
            };
        }
    }
}
