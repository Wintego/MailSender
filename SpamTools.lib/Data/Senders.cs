using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib.Data
{
    public class Senders
    {
        public static List<Sender> List { get; } = new List<Sender>
        {
            new Sender {Name = "Ivanov", Adress="ivanov@mail.ru"},
            new Sender {Name = "Petrov", Adress="petrov@mail.ru"},
            new Sender {Name = "Sidorov", Adress="sidorov@mail.ru"},
        };
    }
}
