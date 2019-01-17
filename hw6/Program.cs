using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//1. Даны 2 двумерных матрицы. Размерность 100х100 каждая. Напишите приложение, производящее параллельное умножение матриц. Матрицы заполняются случайными целыми числами от 0 до10.

//2. *В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные пробелами.
//Первое число - целое, обозначает действие, 1- умножение и 2- деление, остальные два - числа с плавающей точкой.
//Написать многопоточное приложение, выполняющее выполняющее вышеуказанные действия над числами и сохраняющими результат в файл result.dat.
//Количество файлов в директории заведомо много.
namespace hw6
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DoSomethingAsync().Result);

            Console.ReadKey();
        }

        static async Task<int> DoSomethingAsync()
        {
            await Task.Delay(5000);
            return 42;
        }
    }
}
