using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
            public static int[,] Slogenie(int[,] array1, int[,] array2, int[,] array3, out double sr) 
            { 
                Console.Write("\nСложение:");
                sr = 0;
                for (int i = 0; i < 3; i++) 
                { 
                    for (int j = 0; j < 3; j++) 
                    { 
                        array3[i, j] = array1[i, j] + array2[i, j];
                        sr += array1[i, j] + array2[i, j];
                    } 
                }
                sr /= 18;
                return array3; 
            }
            public static int[,] Vichetanie(int[,] array1, int[,] array2, int[,] array3, out double sr)
            {
                Console.Write("\nВычетание:");
                sr = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        array3[i, j] = array1[i, j] - array2[i, j];
                        sr += array1[i, j] + array2[i, j];
                    }
                }
                sr /= 18;
                return array3;
            }

            static void Main(string[] args)
            {
                int m = 3;
                double sr;
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

                    //Проводим операции
                for (int k = 0; ; k++)
                {
                    Console.WriteLine("Выберите действие:\nСумма всех элементов - Q\nРазность всех элементов - W\nВыход - E");
                    string selection = Console.ReadLine();
                    switch (selection[0])
                    {
                        case 'E':
                            Console.WriteLine("Завершено");
                            return;
                        case 'Q':
                            Slogenie(mas1, mas2, mas3, out sr);
                            Console.WriteLine("\nМассив №3");
                            for (int a = 0; a < m; a++)
                            {
                                for (int b = 0; b < m; b++)
                                {
                                    Console.Write(mas3[a, b] + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("Cреднее значение всех элементов входных массивов = {0}",sr);
                            break;
                        case 'W':
                            Vichetanie(mas1, mas2, mas3, out sr);
                            Console.WriteLine("\nМассив №3");
                            for (int a = 0; a < m; a++)
                            {
                                for (int b = 0; b < m; b++)
                                {
                                    Console.Write(mas3[a, b] + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("Cреднее значение всех элементов входных массивов = {0}", sr);
                            break;
                        default:
                            break;
                    }
                }
                    Console.ReadKey(); 
                } 
            }
     }