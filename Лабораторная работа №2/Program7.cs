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
            string Day, Month;
            Console.WriteLine("Введите день");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите год");
            int year = int.Parse(Console.ReadLine());

            if (day < 10)
            {
                Day = day.ToString();
                Day = 0 + Day;
            }
            else
                Day = day.ToString();
            if (month < 10)
            {
                Month = month.ToString();
                Month = 0 + Month;
            }
            else
                Month = month.ToString();

            Console.WriteLine("{0}/{1}/{2}", Day, Month, year);
            Console.ReadKey();
        }
    }
}
