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
        }
    }
}
