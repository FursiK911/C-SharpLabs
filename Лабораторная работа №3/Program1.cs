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
                samples[i] = rand.Next(-30, 45);
            for (int i = 0; i < samples.Length; i++)
            {
                if (i%10==0)
                    Console.WriteLine("");
                Console.Write(samples[i]+" ");
            }
            Console.WriteLine("\nВ обратном порядке:\n");
            for (int i = samples.Length-1; i != -1; i--)
            {
                if (i % 10 == 0)
                    Console.WriteLine("");
                if (samples[i] < 0)
                    continue;
                Console.Write(samples[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
