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
            int m = 9, n = 9;
            int[,] matr = new int[m, n];

            Random ran = new Random();

            //Ввод чисел в массив
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = ran.Next(10);

            //Вывод массива на консоль
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matr[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();

            //Сумма эл-в
            for (int i = 0; i < m; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                    sum += matr[i, j] + matr[j, i];
                matr[i, i] = sum;
            }

            //Вывод результата
            Console.WriteLine("\nРезультат:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matr[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
