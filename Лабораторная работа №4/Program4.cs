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
            //
            Console.WriteLine("Введите семь предложений");
            string[] str = new string[7];
            for(int i=0;i<str.Length;i++)
            {
                str[i] = Console.ReadLine();
            }

            //.com
            Console.WriteLine("Слова на .com:");
            for(int i=0;i<str.Length;i++)
            {
                if(str[i].EndsWith(".com")==true)
                {
                    Console.WriteLine(str[i]);
                }
        }
            Console.ReadKey();
        }
    }
}
