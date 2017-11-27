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
            Console.WriteLine("Введите длину первого катета");
            string x = Console.ReadLine();
            double katet1 = double.Parse(x);
            Console.WriteLine("Введите длину второго катета");
            string y = Console.ReadLine();
            double katet2 = double.Parse(y);
            double gipotinuza = Math.Sqrt(Math.Pow(katet1,2) + Math.Pow(katet2,2));
            Console.WriteLine("Гипотинуза вашего треугольника = {0}", gipotinuza);
            double P = katet1 + katet2 + gipotinuza;
            double S = 0.5 * katet1 * katet2;
            Console.WriteLine("P = {0}",P);
            Console.WriteLine("S = {0}",S);
            Console.ReadKey();
        }
    }
}
