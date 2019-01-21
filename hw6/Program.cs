using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//1. Даны 2 двумерных матрицы. Размерность 100х100 каждая.
//Напишите приложение, производящее параллельное умножение матриц.
//Матрицы заполняются случайными целыми числами от 0 до10.

//2. *В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные пробелами.
//Первое число - целое, обозначает действие, 1- умножение и 2- деление, остальные два - числа с плавающей точкой.
//Написать многопоточное приложение, выполняющее выполняющее вышеуказанные действия над числами и сохраняющими результат в файл result.dat.
//Количество файлов в директории заведомо много.
namespace hw6
{

    class Program
    {
        static int w = 10, h = 10;
        static void Main(string[] args)
        {
            //создаем
            int[,] matrixA = new int[w, h];
            int[,] matrixB = new int[w, h];
            
            //заполняем
            var fill = Task.Factory.StartNew(() =>
            {
                Fill(matrixA);
                Fill(matrixB);
            });
            fill.Wait();

            //умножаем
            var multiple = new Task<int[,]>(() => Multiplication(matrixA, matrixB));
            multiple.Start();

            //выводим результат
            multiple.ContinueWith(t => Show(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadKey();
        }

        static void Fill(int[,] matrix)
        {
            var rnd = new Random();
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    matrix[i, j] = rnd.Next(0, 10);
        }

        static int[,] Multiplication(int[,] matrixA, int[,] matrixB)
        {
            int[,] matrixNew = new int[w, h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    matrixNew[i, j] = matrixA[i, j] * matrixB[i, j];
            return matrixNew;
        }

        static void Show(int[,] matrix)
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    Console.Write($"{i},{j}={matrix[i, j]}" + "\t");
                Console.WriteLine();
            }
        }
    }
}
