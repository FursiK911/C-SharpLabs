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
            double y = double.Parse(Console.ReadLine());
            double Pi,i,x,d=4.0;
            for (x = 3, Pi = 0, i = 0; i < y; i++,x += 2)
            {
                Console.WriteLine(d);
                Pi += d;
                if (d < 0) d = Math.Abs(4 / x);
                else d = -(4 / x);
            }
            Console.WriteLine("Результат = {0}",Pi);
            Console.ReadKey();
        }
    }
}
