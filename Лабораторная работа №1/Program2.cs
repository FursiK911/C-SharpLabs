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
            int hour, min;
            Console.WriteLine("Введите кл-во секунд");
            string x = Console.ReadLine();
            int sec = int.Parse(x);
            hour = sec / 3600;
            min = (sec - hour * 3600) / 60;
            sec = sec - ((3600*hour)+(min*60));
            Console.WriteLine("Кл-во часов = {0}",hour);
            Console.WriteLine("Кл-во минут = {0}",min);
            Console.WriteLine("Кл-во секунд = {0}",sec);
            Console.ReadKey();
        }
    }
}
