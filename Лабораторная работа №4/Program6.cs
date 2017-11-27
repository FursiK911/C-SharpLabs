using System;
using System.Text.RegularExpressions;
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
            Console.WriteLine("Введите пример");
            string Sentence = Console.ReadLine();
            int a, b, c;

            Regex RegExp = new Regex(@"\s*([-]?\d*)\s*[+-]\s*([-]?\d*)\s*=\s*([-]?\d*)");
            Match match = RegExp.Match(Sentence);
            a = int.Parse(match.Groups[1].Value);
            b = int.Parse(match.Groups[2].Value);
            c = int.Parse(match.Groups[3].Value);
            Console.WriteLine("{0} {1} {2}",a,b,c);
            Console.ReadKey();

        }
    }
}