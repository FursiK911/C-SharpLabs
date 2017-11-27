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
            Console.Write("a1 = ");
            string A1 = Console.ReadLine();
            double a1 = double.Parse(A1);
            Console.Write("a2 = ");
            string A2 = Console.ReadLine();
            double a2 = double.Parse(A2);
            Console.Write("a3 = ");
            string A3 = Console.ReadLine();
            double a3 = double.Parse(A3);
            Console.Write("b1 = ");
            string B1 = Console.ReadLine();
            double b1 = double.Parse(B1);
            Console.Write("b2 = ");
            string B2 = Console.ReadLine();
            double b2 = double.Parse(B2);
            Console.Write("b3 = ");
            string B3 = Console.ReadLine();
            double b3 = double.Parse(B3);
            Console.Write("z1 = ");
            string Z1 = Console.ReadLine();
            double z1 = double.Parse(Z1);
            Console.Write("z2 = ");
            string Z2 = Console.ReadLine();
            double z2 = double.Parse(Z2);
            Console.Write("z3 = ");
            string Z3 = Console.ReadLine();
            double z3 = double.Parse(Z3);
            Console.Write("d1 = ");
            string D1 = Console.ReadLine();
            double d1 = double.Parse(D1);
            Console.Write("d2 = ");
            string D2 = Console.ReadLine();
            double d2 = double.Parse(D2);
            Console.Write("d3 = ");
            string D3 = Console.ReadLine();
            double d3 = double.Parse(D3);
            double delt = a1 * b2 * z3 + a3 * b1 * z2 + a2 * b3 * z1 - a3 * b2 * z1 - a2 * b1 * z3 - a1 * b3 * z2;
            double deltx = (d1 * b2 * z3 + d3 * b1 * z2 + d2 * b3 * z1 - d3 * b2 * z1 - d2 * b1 * z3 - d1 * b3 * z2);
            double x = deltx / delt;
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
