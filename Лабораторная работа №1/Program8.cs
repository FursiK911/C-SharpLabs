using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace задание_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.WriteLine("Введите число");
            x = Convert.ToInt32(Console.ReadLine());

            y = x * (x * (x * (3 * x - 5)) + 2) - x + 7;
            Console.WriteLine(y);

            Console.ReadKey();
        }
    }
}
