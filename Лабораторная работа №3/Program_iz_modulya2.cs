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
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            int min = 10, max = -10, sum;
            int[] samples = new int[n];
            Random rand = new Random();
            for (int i = 0; i<n; i++)
            {
                samples[i] = rand.Next(-10,10);
                if (samples[i]>max)
                    max=samples[i];
                if (samples[i]<min)
                    min=samples[i];
            }
            for (int i=0;i<n;i++)
                Console.Write(samples[i]+"\t");
            sum=min+max;
            Console.WriteLine("\nСумма минимального и максимального элемента массива = {0}",sum);
            Console.ReadKey();
        }
    }
}
