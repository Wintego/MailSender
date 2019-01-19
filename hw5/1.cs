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
        static int fact = 1, sum = 0;
        static void Main(string[] args)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            Thread second = new Thread(() => OnConsole(value));
            second.Start();
            Console.ReadKey();
        }
        static void OnConsole(int value)
        {
            
            Thread third = new Thread(() => Factorial(fact));
            third.Start();
            Console.WriteLine(sum);

            Thread forth = new Thread(() => Sum(sum));
            forth.Start();
            Console.WriteLine(fact);
        }
        static void Factorial(int f)
        {
            for (int i = 1; i <= f; i++)
            {
                fact *= i;
            }
        }

        static void Sum(int s)
        {
            for (int i = 1; i <= s; i++)
            {
                sum += i;
            }
        }

        
        
    }
}
