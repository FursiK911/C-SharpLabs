using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static int it_sum(int[] array, int sum)
        {
            for (int i = 0; i < array.Length - 1; i++)
                sum += array[i];
            return sum;
        }

        public static int it_min(int[] array, int min)
        {
            min = array[0];
            for (int i = 0; i < array.Length - 1; i++)
                if (min < array[i])
                    min = array[i];
            return min;
        }

        public static int rec_sum(int[] array, int x)
        {
            int sum;
            if (x == 0)
                return array[0];
            return array[x - 1] + rec_sum(array, x - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива");
            int a = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[] samples = new int[a];
            for (int i = 0; i < a; i++)
                samples[i] = rand.Next(9);

            rec_sum(samples, a);
        }
    }
}

