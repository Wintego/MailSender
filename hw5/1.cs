using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw5
{
    class Program
    {
        static void Main(string[] args)
        {
            //int value = Convert.ToInt32(Console.ReadLine());

            //Thread f = new Thread(() => Factorial(value));
            //f.Start();

            //Thread s = new Thread(() => Sum(value));
            //s.Start();

            Thread csvtotxt = new Thread(hw5._2.Hw52);
            csvtotxt.IsBackground = true;
            csvtotxt.Start();
            var dt = DateTime.Now;
            while (true)
                Console.Title = (DateTime.Now-dt).ToString();

            Console.ReadKey();
        }

        //static int Factorial(int f)
        //{
        //    if (f == 1) return 1;
        //    return f * Factorial(f - 1);
        //}
        static void Factorial(int f)
        {
            int fact = 1;
            for (int i = 1; i <= f; i++)
            {
                fact *= i;
            }
            Console.WriteLine(fact);
        }

        //static int Sum(int s)
        //{
        //    if (s == 0) return 0;
        //    return s + Sum(s - 1);
        //}
        static void Sum(int s)
        {
            int sum = 0;
            for (int i = 1; i <= s; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
