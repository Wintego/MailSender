namespace ConsoleApp13.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp13.task3>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConsoleApp13.task3 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(new Users {Id = 1, Name = "Артём"});
            context.Users.AddOrUpdate(new Users {Id = 2, Name = "Дмитрий" });
            context.Users.AddOrUpdate(new Users {Id = 6, Name = "Дмитрий" });
            context.Users.AddOrUpdate(new Users {Id = 3, Name = "Аркадий" });
            context.Users.AddOrUpdate(new Users {Id = 4, Name = "Аркадий" });
            context.Users.AddOrUpdate(new Users {Id = 5, Name = "аркадий" });
        }
    }
}
