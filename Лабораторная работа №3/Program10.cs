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
            Console.WriteLine("Введите число элементов массива");
            int a = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[] samples = new int[a];
            for (int i = 0; i < a; i++)
                samples[i] = rand.Next(9);

            for (int i = 0; i < samples.Length; i++)
            {
                Console.Write(samples[i] + " ");
            }

            int max = samples[2];
            for (int i = 0; i < a; i++)
            {
                if (i % 2 == 0)
                {
                    if (samples[i] % 2 != 0)
                    {
                        if (max < samples[i])
                        {
                            max = samples[i];
                        }
                    }
                }
            }

            Console.WriteLine("\nМаксимальный элемент среди нечетных элементов массива, находящихся на четных позициях = {0}",max);
            Console.ReadKey();

        }
    }
}
