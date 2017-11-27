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
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double c = int.Parse(Console.ReadLine());
            double d = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine("Дискриминант = {0}", d);
            if (d >= 0)
            {
                if (d > 0)
                {
                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("Первый корень = {0} \nВторой корень = {1}", x1, x2);
                }
                else
                {
                    double x1 = -b / (2 * a);
                    Console.WriteLine("Корень уравнения = {0}", x1);
                }
            }
            else
                {
                    Console.WriteLine("Уравнение не имеет действительных решений");
                }
            Console.ReadKey();
            }
        }
    }
