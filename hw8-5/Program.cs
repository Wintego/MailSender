using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw8_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DB())
            {
                var request = from row in db.Task5 group row by row.group_id into o select new {GroupId = o.Key};
                foreach (var a in request)
                {
                    Console.WriteLine(a.GroupId);
                }
            }

            Console.ReadKey();
        }
    }

    class Table
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string descr { get; set; }
    }

    class DB : DbContext
    {
        public DB() : this("name=hw8") { }
        public DB(string connectionString) : base(connectionString) { }
        static DB() => System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, hw8_5.Migrations.Configuration>(true));
        public DbSet<Table> Task5 { get; set; }
    }
}
