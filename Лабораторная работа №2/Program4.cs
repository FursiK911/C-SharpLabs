using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    class Program
    {
        public static double fact(int k)
        {
            int r = 1;
            for (int i = 1; i <= k; i++)
            {
                r *= i;
                Console.WriteLine("Факториал " + i + " = " + r);
            }
            return (double)r;
        }
        static void Main()
        {
            Console.Clear();
            Console.Write("x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("q = ");
            double q = double.Parse(Console.ReadLine());

            int c = 0;
            double cosx = 1.0;
            double d = -1.0;
            for (int k = 2; k < q; k += 2)
            {
                Console.WriteLine("cos = {0}\n",cosx);
                c++;
                if (d < 0)
                {
                    cosx -= (Math.Pow(x, k) / fact(k));
                    d = 1;
                }
                else
                {
                    cosx += (Math.Pow(x, k) / fact(k));
                    d = -1;
                }
            }
            Console.WriteLine("\ncos({0}) = {1}\n", x, cosx);
            Console.WriteLine("Число слагаемых: {0};", c);
            Console.ReadKey();
        }
    }
}