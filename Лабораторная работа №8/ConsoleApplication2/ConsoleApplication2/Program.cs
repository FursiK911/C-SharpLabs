using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        public static int[] computePrefixFunction(string s)
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
        public static int KMPSearch(string pattern, string text)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 0;
            int n = text.Length;
            int m = pattern.Length;

            int[] prefix = computePrefixFunction(pattern);

            int j = 0;

            for (int i = 1; i <= n; i++)
            {
                count++;
                while (j > 0 && pattern[j] != text[i - 1])
                {
                    j = prefix[j - 1];
                }
                if (pattern[j] == text[i - 1])
                {
                    j++;
                }
                if (j == m)
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                    Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                    Console.WriteLine("Количество сравнений : " + count);
                    return i - m;	 // Найдено в позиции i - m 
                }
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}", time1.Seconds, time1.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime1);
            Console.WriteLine("Количество сравнений : " + count);
            return -1;		 // Не найдено
        }
        public static int BMSearch(string pattern, string text)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 0;
            int n = text.Length-1;
            int m = pattern.Length;

            if (m > n)
            {
                sw.Stop();
                TimeSpan time = sw.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                Console.WriteLine("Количество сравнений : " + count);
                return -1;
            }

            int[] badShift = BadCharactersTable(pattern);
            int[] goodSuffix = GoodSuffixTable(pattern);

            int offset = 0;

            while (offset <= n - m)
            {
                int i;
                for (i = m - 1; i >= 0 && pattern[i] == text[i + offset]; i--) ;
                {
                    count++;
                    if (i < 0)
                    {
                        sw.Stop();
                        TimeSpan time = sw.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                        Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                        Console.WriteLine("Количество сравнений : " + count);
                        return offset;
                    }
                }                               // Match found

                offset += Math.Max(i - badShift[(int)text[offset + i]], goodSuffix[i]);
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}", time1.Seconds, time1.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime1);
            Console.WriteLine("Количество сравнений : " + count);
            return -1;
        }
        public static int[] BadCharactersTable(string pattern)
        {
            int m = pattern.Length;

            int[] badShift = new int[256];

            for (int i = 0; i < 256; i++)
            {
                badShift[i] = -1;
            }

            for (int i = 0; i < m - 1; i++)
            {
                badShift[(int)pattern[i]] = i;
            }

            return badShift;
        }
        public static int[] GoodSuffixTable(string pattern)
        {
            int m = pattern.Length;

            int[] suffixes = Suffixes(pattern);

            int[] goodSuffixes = new int[m];

            for (int i = 0; i < m; i++)
                goodSuffixes[i] = m;

            for (int i = m - 1; i >= 0; i--)
                if (suffixes[i] == i + 1)
                    for (int j = 0; j < m - i - 1; j++)
                        if (goodSuffixes[j] == m)
                            goodSuffixes[j] = m - i - 1;

            for (int i = 0; i < m - 2; i++)
            {
                goodSuffixes[m - 1 - suffixes[i]] = m - i - 1;
            }

            return goodSuffixes;
        }
        public static int[] Suffixes(string pattern)
        {
            int m = pattern.Length;
            int[] suffixes = new int[m];
            suffixes[m - 1] = m;

            int g = m - 1, f = 0;

            for (int i = m - 2; i >= 0; --i)
            {
                if (i > g && suffixes[i + m - 1 - f] < i - g)
                    suffixes[i] = suffixes[i + m - 1 - f];
                else if (i < g)
                    g = i;
                f = i;

                while (g >= 0 && pattern[g] == pattern[g + m - 1 - f]) g--;

                suffixes[i] = f - g;
            }

            return suffixes;
        }
        public static int JustSearch(string text, string pattern)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 0;
            int y = 0;
            for (int i = 0; i < text.Length-1; i++)
            {
                count++;
                if (pattern[y] == text[i])
                {
                    y++;
                    if (y == pattern.Length)
                    {
                        sw.Stop();
                        TimeSpan time = sw.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                        Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                        Console.WriteLine("Количество сравнений : " + count);
                        return i - pattern.Length + 1;
                    }
                }
                else
                {
                    y = 0;
                }
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}", time1.Seconds, time1.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime1);
            return -1;
        }
        static void Main(string[] args)
        {
            string txt = "Наруjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj,kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkЙоу, собаки. Я Наруто Узумаки";
            string find = "Наруто";
            Console.WriteLine("Индекс найденной подстроки: {0}", JustSearch(txt,find));
            Console.WriteLine("Индекс найденной подстроки: {0}", KMPSearch(find, txt));
            Console.WriteLine("Индекс найденной подстроки: {0}", BMSearch(find, txt));

        }
    }
}
