using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. *Написать приложение, выполняющее парсинг CSV-файла, произвольной структуры и
//сохраняющего его в обычный TXT-файл. Все операции проходят в потоках.
//CSV-файл заведомо имеет большой объём.
namespace hw5
{
    public static class _2
    {
        public static string input = @"FL_insurance_sample.csv";
        public static string output = @"output.txt";
        public static void Hw52()
        {
            int current = 0;
            using (var reader = new StreamReader(input))
            {
                using (var writer = new StreamWriter(output))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                        Console.WriteLine("Запись строки " + ++current);
                    }
                }
            }

            //using (var reader = new StreamReader(input))
            //{
            //    using (var writer = new StreamWriter(output))
            //    {
            //        writer.WriteLine(reader.ReadToEnd());
            //        Console.WriteLine("Текст записан за" + Console.Title);
            //    }
            //}

        }
    }
}
