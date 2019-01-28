using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTools.lib.Service;

namespace SpamTools.lib.Data
{
    public class Senders
    {
        public void Main()
        {
            using (var db = new SpamTools.lib.Data.DataBaseContext())
            {
                
            }
        }
        public static List<Sender> List { get; } = new List<Sender>
        {
            new Sender {Name = "Ivanov", Adress="ivanov@mail.ru"},
            new Sender {Name = "Petrov", Adress="petrov@mail.ru"},
            new Sender {Name = "Sidorov", Adress="sidorov@mail.ru"},
            new Sender {Name = "Ya", Adress="berlin.22014@yandex.ru", Password = PasswordService.Encode("password")}
        };
    }
}
