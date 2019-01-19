using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. *В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные пробелами.
//Первое число - целое, обозначает действие, 1- умножение и 2- деление, остальные два - числа с плавающей точкой.
//Написать многопоточное приложение, выполняющее выполняющее вышеуказанные действия над числами и сохраняющими результат в файл result.dat.
//Количество файлов в директории заведомо много.
namespace hw6_2
{
    class Program
    {
        private const string output = "result.dat";
        static void Main(string[] args)
        {
            //if (File.Exists(output)) File.Delete(output);

            var files = Directory.GetFiles("dir", "*.txt");

            Parallel.ForEach(files, Operation);
        }

        static void Operation(string filePath)
        {
            var file = File.ReadAllLines(filePath);
            foreach (var str in file)
            {
                var operation = str.Split(' ').Select(v => Convert.ToDouble(v, CultureInfo.InvariantCulture)).ToArray();
                switch (operation[0])
                {
                    case 1:
                        Task.Run(() => Write(operation[1] * operation[2], str));
                        break;
                    case 2:
                        Task.Run(() => Write(operation[1] / operation[2], str));
                        break;
                    default: break;
                }
            }
        }
        static object l = new object();
        static void Write(double result, string input)
        {
            //File.WriteAllText(output, $"{input}: {result}");
            lock (l)
            {
                using (var sw = new StreamWriter(output, true))
                {
                    sw.WriteLineAsync($"{input}: {result}");
                }
            }
        }
    }
}
