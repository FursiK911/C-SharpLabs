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
Console.Write("Введите кол-во элементов массива ");
            int N = int.Parse(Console.ReadLine());
            Random rand = new Random();
            int[] samples = new int[N];
            for (int i = 0; i < N; i++)
            {
                samples[i] = rand.Next(10);
                Console.Write(" " + samples[i]);
            }
            Console.WriteLine("\nКак много позиций вы хотите сдвинуть?");
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; ++i)
            {
                int samplesLast = samples[N - 1];
                   for (int j = N - 1; j > 0; j--)
                       samples[j] = samples[j - 1];
                   samples[0]=samplesLast;
            }
        

                    for (int i = 0; i < N; i++)
                    {
                        Console.Write(" " + samples[i]);
                    }
            
            Console.ReadKey();
    }

        }
    }
