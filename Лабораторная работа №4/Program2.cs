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
            //Ввод
            Console.WriteLine("Введите предложение и завершите точкой");
            string Sentence = Console.ReadLine();
            string[] mas2 = Sentence.Split(' ', ',');
            foreach (string num in mas2)
                Console.WriteLine(num);



            for (int k = 0; ; k++)
            {
                Console.WriteLine("Выберите действие:\nС помощью массива - Q\nС помощью методов string - W\nВыход - E");
                string selection = Console.ReadLine();
                switch (selection[0])
                {
                    case 'Q':
                        int n = 0;
                        for (int i = 0; i < mas2.Length; i++)
                        {
                            char[] mas = mas2[i].ToCharArray();
                            for (int j = 0; j < mas.Length; j++)
                                Console.Write(mas[j]);
                            n++;
                            Console.Write("(" + n + ") ");
                        }
                        break;
                    case 'W':
                        int m = 0;
                        for (int i = 0; i < Sentence.Length; i++)
                        {
                            if (Sentence[i] == ' ')
                            {
                                m++;
                                Sentence.Insert(i, "(" + m + ") ");
                            }
                        }
                        Console.WriteLine(Sentence);
                        break;
                    case 'E': Console.WriteLine("Завершено");
                        return;
                }
                Console.ReadKey();
            }
        }
    }
}