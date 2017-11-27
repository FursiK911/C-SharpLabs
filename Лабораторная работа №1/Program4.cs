using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число №1");
            string X = Console.ReadLine();
            int x = int.Parse(X);
            Console.WriteLine("Введите число №2");
            string Y = Console.ReadLine();
            int y = int.Parse(Y);
            x = x + y;
            y = x - y;
            x = x - y;
            Console.WriteLine("Число №1 = {0}", x);
            Console.WriteLine("Число №2 = {0}", y);
            Console.ReadKey();
        }
    }
}
