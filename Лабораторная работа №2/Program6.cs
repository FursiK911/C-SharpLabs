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
            Console.WriteLine("Введите любое число от 1 до 100");
            string X = Console.ReadLine();
            int x = int.Parse(X);
            if (x >= 10 && x <= 20)
            {
                Console.WriteLine("{0} лет",x);
            }
            else
            {
                int y = x % 10;
                switch (y)
                {
                    case 1: Console.WriteLine("{0} год", x); break;
                    case 2:
                    case 3:
                    case 4: Console.WriteLine("{0} года", x); break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10: Console.WriteLine("{0} лет", x); break;
                    default: Console.WriteLine("Error"); break;
                }
            }
            Console.ReadKey();
        }
    }
}
