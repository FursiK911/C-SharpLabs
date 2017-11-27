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
            Console.Write("Введите число N = ");
            int n = int.Parse(Console.ReadLine());
            int i = 0;
            for (int x = 1; x < n; x++)
            {
                for (int y = 1; y < n; y++)
                {
                    for (int z = 1; z < n; z++)
                    {
                        if (Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3) == n)
                        {
                            Console.WriteLine("{0} {1} {2}", x, y, z);
                            i = 1;
                        }
                    }
                }
            }
            if (i == 0)
                Console.WriteLine("No such combination!");
            Console.ReadKey();
        }
    }
}
