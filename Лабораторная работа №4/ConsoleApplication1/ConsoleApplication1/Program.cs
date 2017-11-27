using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод
            Console.WriteLine("Введите предложение и завершите точкой");
            string Sentence = Console.ReadLine();
            char[] mas = Sentence.ToCharArray();

            for (int k = 0; ; k++)
            {
                Console.WriteLine("Выберите действие:\nС помощью массива - Q\nС помощью методов string - W\nВыход - E");
                string selection = Console.ReadLine();
                switch (selection[0])
                {
                    case 'Q': for (int i = 0; i < mas.Length; i++)
                        {
                            int n = 0;
                            for (int j = 0; j < mas.Length; j++)
                            {
                                if (i == j) continue;
                                if (mas[i] == mas[j]) n++;
                            }
                            if (n == 0) Console.WriteLine(mas[i]);
                        }
                        break;
                    case 'W': for (int i = 0; i < Sentence.Length; i++)
                        {
                            int a = Sentence.IndexOf(Sentence[i]);
                            int b = Sentence.LastIndexOf(Sentence[i]);
                            if (a == b)
                                Console.WriteLine(Sentence[i]);
                        }
                        break;
                    case 'E': Console.WriteLine("Завершено");
                        return;
                }
                Console.ReadKey();
            }
        }
    }
}