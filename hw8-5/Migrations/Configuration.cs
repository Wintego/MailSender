namespace hw8_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<hw8_5.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(hw8_5.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Task5.AddOrUpdate(new Table { id = 1, group_id = 1, descr = "Один" });
            context.Task5.AddOrUpdate(new Table { id = 2, group_id = 2, descr = "Два" });
            context.Task5.AddOrUpdate(new Table { id = 3, group_id = 1, descr = "Три" });
            context.Task5.AddOrUpdate(new Table { id = 4, group_id = 2, descr = "Четыре" });
            context.Task5.AddOrUpdate(new Table { id = 5, group_id = 2, descr = "Пять" });
        }
    }
}
