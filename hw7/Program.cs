using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//4. *Есть CSV-файл с таким содержанием:
// Иванов И.И., ivanov@mail.ru, +7(111) 123-45-67
// Петров П.П.,petrov@mail.ru, +7(222) 123-45-67
// Федоров Ф.Ф., fedorov@mail.ru, +7(333) 123-45-67
// 
// То есть записи представляют собой значения: ФИО, почта, телефон. 
// Необходимо написать приложение, которое:
// a. импортирует данный файл в базу данных;
// b. позволяет редактировать данные.
namespace hw7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("hw7-4.csv");
            List <Client> input = new List<Client>();

            for (int i = 0; i < file.Length; i++)
            {
                var a = file[i].Split(',');
                input.Add(new Client {Name = a[0], Email = a[1], Phone = a[2]});
            }

            using (var db = new DB())
            {
                db.Clients.AddRange(input);
                db.SaveChanges();
                Console.WriteLine("Импорт данных завершен.");
            }

            Edit();
        }

        static void Edit()
        {
            using (var db = new DB())
            {
                var clients = db.Clients;
                foreach (var client in clients)
                    Console.WriteLine($"{client.Id}. {client.Name} ({client.Email})");

                Console.WriteLine("\nВведите номер элемента для редактирования: ");
                int inputNumber = Convert.ToInt32(Console.ReadLine());


                foreach (var property in typeof(Client).GetProperties())
                    Console.WriteLine(property.Name);
                Console.WriteLine("\nВведите свойство которое требуется изменить: ");
                string inputProperty = Console.ReadLine();

                Console.WriteLine("\nВведите новое значение:");
                string newValue = Console.ReadLine();

                switch (inputProperty)
                {
                    case "Id": db.Clients.Find(inputNumber).Id = Convert.ToInt32(newValue);
                        break;
                    case "Name": db.Clients.Find(inputNumber).Name = newValue;
                        break;
                    case "Email":
                        db.Clients.Find(inputNumber).Email = newValue;
                        break;
                    case "Phone":
                        db.Clients.Find(inputNumber).Phone = newValue;
                        break;
                }
                db.SaveChanges();

                Console.WriteLine($"Строка изменена.");
            }

        }
    }
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    class DB : DbContext
    {
        public DB(): this("name=hw7") { }
        public DB(string ConnectionString) : base(ConnectionString)
        {

        }

        static DB()
        {
            System.Data.Entity.Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<DB, hw7.Migrations.Configuration>(true));
        }
        public DbSet<Client> Clients { get; set; }
    }
}
