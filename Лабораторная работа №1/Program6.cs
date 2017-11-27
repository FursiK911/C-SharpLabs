using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {   Console.WriteLine("Введите четырехзначное число");
            string X = Console.ReadLine();
            int x = int.Parse(X);
            int a = x / 1000;
            int b = (x / 100) % 10;
            int c = (x / 10) % 10;
            int d = x % 10;
            Console.WriteLine("Первое число = {0}", a);
            Console.WriteLine("Второе число = {0}", b);
            Console.WriteLine("Третье число = {0}", c);
            Console.WriteLine("Четвертое число = {0}", d);
            int proizvedenie = a * b * c * d;
            Console.WriteLine("Произведение чисел = {0}", proizvedenie);
            Console.ReadKey();
        }
    }
}
