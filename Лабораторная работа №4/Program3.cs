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

            for (int k = 0; ; k++)
            {
                Console.WriteLine("Выберите действие:\nС помощью массива - Q\nС помощью методов string - W\nВыход - E");
                string selection = Console.ReadLine();
                switch (selection[0])
                {
                    case 'Q':
                        for (int i = mas2.Length - 1; i != -1; i--)
                        {
                            Console.Write(mas2[i]+" ");
                        }
                        break;
                    case 'W':
                        string[] reverse = mas2.Reverse().ToArray();
                        foreach (string element in reverse)
                            Console.Write(element+" ");
                        break;
                    case 'E':
                        Console.WriteLine("Завершено");
                        return;
                }
            }
            Console.ReadKey();
        }
    }
}