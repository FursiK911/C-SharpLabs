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
            Console.WriteLine("Введите трехзначное число");
            string X = Console.ReadLine();
            int x = int.Parse(X);
            int e = x / 100;
            int d = (x / 10) % 10;
            int s = x % 10;
            int y = s * 100 + d * 10 + e;
            Console.WriteLine("Ваше число в обратном порядке = {0}", y);
            Console.ReadKey();
        }
    }
}
