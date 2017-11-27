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
            Console.WriteLine("Введите переменную а");
            string x = Console.ReadLine();
            double a = double.Parse(x);
            Console.WriteLine("Введите переменную b");
            x = Console.ReadLine();
            double b = double.Parse(x);
            Console.WriteLine("Введите переменную t");
            x = Console.ReadLine();
            double t = double.Parse(x);
            const double e = 2.7182;
            double y = Math.Pow(e, -b * t) * Math.Sin(a * t + b) - Math.Sqrt(Math.Abs(b * t + a));
            double z = b * Math.Sin(a * Math.Pow(t, 2) * Math.Cos(2 * t)) - 1;
            Console.WriteLine("y = {0}\nz = {1}", y, z);
            Console.ReadKey();
        }
    }
}
