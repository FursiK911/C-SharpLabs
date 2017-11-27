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
            Console.WriteLine("Введите число");
            int x = int.Parse(Console.ReadLine());
            int min=8,blizkoe=0,y;
            for (int i = 3; i < x + 7; i += 7)
            {
                y = x - i;
                if (min > Math.Abs(y))
                {
                    min = Math.Abs(y);
                    blizkoe = i;
                }
            }
            Console.WriteLine(blizkoe);
            Console.ReadKey();
        }
    }
}
