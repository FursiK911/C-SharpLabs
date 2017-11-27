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
            int a, b;
            Console.WriteLine("Введите а (а<b)");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите b (a<b)");
            b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++) 
            {
                if (i % 2 == 0)
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
