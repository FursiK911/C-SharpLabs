using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {   Console.WriteLine("Введите переменную x");
            string x = Console.ReadLine();
            double X = double.Parse(x);
            int d = (int)(10 * (X - (int)X));
            Console.WriteLine(d);
            Console.ReadKey();
       
        }
    }
}
