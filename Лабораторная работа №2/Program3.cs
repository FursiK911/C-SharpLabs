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
            int n = int.Parse(Console.ReadLine());
            int fib, fib0=1, fib1 = 1;
            for (int i = 0; i < n; i++) ;
                {
                    int sum = fib0 + fib1;
                    Console.WriteLine("{0} ", sum);
                    fib = fib1;
                    fib1 = fib0 + fib1;
                    fib0 = fib;
                }
            Console.ReadKey();
        }
    }
}
