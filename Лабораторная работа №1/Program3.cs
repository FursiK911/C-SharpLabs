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
            Console.WriteLine("Введите кл-во часов");
            string x = Console.ReadLine();
            double hour = double.Parse(x);
            Console.WriteLine("Введите кл-во минут");
            x = Console.ReadLine();
            double min = double.Parse(x);
            Console.WriteLine("Введите кл-во секунд");
            x = Console.ReadLine();
            double sec = double.Parse(x);
            double alpha = ((int)(hour / 12)) + min / 60 + sec;
            Console.WriteLine("Угол между положением часовой стрелки в начале суток и ее нынешнем положением = {0} градусов",alpha);
            Console.ReadKey();
        }
    }
}
