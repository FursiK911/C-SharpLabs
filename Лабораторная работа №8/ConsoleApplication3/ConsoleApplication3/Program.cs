using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СonsoleApplication3
{
    class Program
    {

        //КМП 

        static int[] computePrefixFunction(string s)
        {

            int m = s.Length;

            int[] pi = new int[m];

            int j = 0;

            pi[0] = 0;

            for (int i = 1; i < m; i++)
            {

                while (j > 0 && s[j] != s[i])
                {

                    j = pi[j];

                }

                if (s[j] == s[i])
                {

                    j++;

                }

                pi[i] = j;

            }

            return pi;

        }

        static int Search1(string pattern, string text, ref long comparison)
        {

            int n = text.Length;

            int m = pattern.Length;

            int[] prefix = computePrefixFunction(pattern);

            int q = 0;

            for (int i = 1; i <= n; i++)
            {

                while (q > 0 && pattern[q] != text[i - 1])
                {

                    q = prefix[q - 1];

                }

                if (pattern[q] == text[i - 1])
                {

                    q++;

                    comparison++;

                }

                if (q == m)
                {

                    comparison++;

                    return i - m;

                }

            }

            return -1;

        }

        //БМ
        public static int[] tableshift;
        static void TableShift(string readtemplate)
        {

            tableshift = new int[char.MaxValue];

            for (int i = 0; i < tableshift.Length; i++)
            {

                tableshift[i] = readtemplate.Length;

            }

            for (int i = 0; i < readtemplate.Length; i++)
            {

                tableshift[readtemplate[i]] = readtemplate.Length - i;

            }

        }
        public static int BoyerMoore(string readsource, string readtemplate, ref long comparison1)
        {

            var source = readsource;

            var template = readtemplate;

            TableShift(template);

            if (template.Length > source.Length)
            {

                comparison1++;

                return -1;

            }

            //if (template == source) 

            //{ 

            // Console.WriteLine("Шаблон и исходная строка равны"); 

            // return -1; 

            //} 

            for (int i = template.Length; i < source.Length + 1; ) // Основной цикл 
            {

                for (int j = template.Length - 1; j >= 0; j--) // Цикл проверки на совпадения 
                {

                    if (template[j] == source[i - template.Length + j]) // Проверка на совпадения 
                    {

                        comparison1++;

                        if (j == 0) // Если первый символ шаблона схож с текущим символом исходной строки 
                        {

                            comparison1++;

                            return i - template.Length + 1;

                        }

                    }

                    else
                    {

                        comparison1++;

                        i += tableshift[source[i]];

                        break;

                    }

                }

            }

            return -1;

        }

        static void Main(string[] args)
        {

            string text = "йцукенгшщзхъфывапролджэячсмитьбюячсмифыварцукцуколваргфшдугародфвыраплавлоаплаврплыоаврфдаожвалотмоамрга";

            long comparison = 0;

            long comparison1 = 0;

            string pattern = "мифы";

            string s = "ми";

            //КМП 

            DateTime dt = DateTime.Now;

            computePrefixFunction(s);

            Search1(pattern, text, ref comparison);

            DateTime dt0 = DateTime.Now;

            TimeSpan ts = dt0 - dt;

            string time = ts.ToString(@"ss\.ffff");

            int i = Search1(pattern, text, ref comparison);

            Console.WriteLine("\nIndex = {0}", i);

            Console.WriteLine("Comparison = {0}", comparison);

            Console.WriteLine("Time: {0}", time);

            //Бойер-Мур 

            DateTime dt1 = DateTime.Now;

            TableShift(pattern);

            BoyerMoore(text, pattern, ref comparison1);

            DateTime dt2 = DateTime.Now;

            TimeSpan ts1 = dt2 - dt1;

            string time1 = ts1.ToString(@"ss\.ffff");

            int i2 = BoyerMoore(text, pattern, ref comparison1);

            Console.WriteLine("\nIndex = {0}", i2);

            Console.WriteLine("Comparison = {0}", comparison1);

            Console.WriteLine("Time: {0}", time1);

            Console.ReadKey();
        }
    }
}