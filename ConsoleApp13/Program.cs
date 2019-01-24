using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3. Есть таблица Users. Столбцы в ней - Id, Name.
//Написать SQL-запрос, который выведет имена пользователей, начинающиеся на 'A', и которые встречаются в таблице более одного раза, и их количество.
namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new task3())
            {
                var users = 
                    from p in db.Users
                    group p by p.Name into g
                    select new { Name = g.Key, Count = g.Count() };

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} - {user.Count}");
            }
            Console.ReadKey();
        }
    }

    class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class task3 : DbContext
    {
        public task3() : this("name=hw8") { }
        public task3(string connectionString) : base(connectionString) { }
        static task3()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<task3, ConsoleApp13.Migrations.Configuration>(true));
        }

        public DbSet<Users> Users { get; set; }
    }
}
