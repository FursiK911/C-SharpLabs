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
            int n = 7;

            int[,] matr = new int[n, n];

            Random ran = new Random();

            //Ввод чисел в массив
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = ran.Next(10);

            //Вывод массива на консоль
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matr[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();

            //Замена строк столбцами
            int m = 0;
            for (int k = 0; k < 7; k++)
            {
                m = k + 1;
                for (; m < 7; m++)
                {
                    int a = matr[m, k];
                    matr[m, k] = matr[k, m];
                    matr[k, m] = a;
                }
            }

            //Вывод в обратном порядке
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j > 3)
                    {

                    }
                    else
                    {
                        int b = matr[i, j];
                        matr[i, j] = matr[i, 6 - j];
                        matr[i, 6 - j] = b;

                    }

                }

            }

            //Вывод массива на консоль
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matr[i, j] + "\t");
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
