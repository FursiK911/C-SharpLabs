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
            int m = 5;
            int[,] mas1 = new int[m, m];
            int[,] mas2 = new int[m, m];
            int[,] mas3 = new int[m, m];
            Random rand = new Random();

            //Ввод чисел в массив
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas1[i, j] = rand.Next(9);
                    mas2[i, j] = rand.Next(9);
                }
            }

            //Вывод массива на консоль
            Console.WriteLine("Массив №1");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mas1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nМассив №2");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mas2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //Перемножение двух матриц
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        mas3[i, j] += mas1[i, k] * mas2[k, j];
                    }
                }
            }

            Console.WriteLine("\nМассив №3");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mas3[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
