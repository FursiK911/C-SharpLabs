using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        public static int LinearSearch(int[] a, int elem)
        {
            Console.WriteLine("Линейный поиск");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == elem)
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                    Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                    return i;
                }
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}", time1.Seconds, time1.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime1);
            return -1;
        }
        public static int BinarySearch(int elem, int[] a, int N)
        {
            Console.WriteLine("Бинарный поиск");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int l = 0, r = N - 1;
            while (r >= l)
            {
                int mid = (l + r) / 2;

                if (a[mid] == elem)
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                    Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                    return mid;
                }

                if (a[mid] > elem)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}", time1.Seconds, time1.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime1);
            return -1;
        }
        public static int InterpolationSearch(int elem, int[] a, int N)
        {
            Console.WriteLine("Интерполяционный поиск");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int l = 0, r = N - 1;

            while (r >= l)
            {
                int mid = l + (r - l) * (elem - a[l]) / (a[r] - a[l]);

                if (elem < a[mid])
                    r = mid - 1;
                else if (elem > a[mid])
                    l = mid + 1;
                else
                {
                    sw.Stop();
                    TimeSpan time = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
                    Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
                    return mid;
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
            FileStream fStream = new FileStream(@"C:\Users\Дмитрий\Desktop\Учеба\C#\Лабораторная работа №7\ConsoleApplication1\ConsoleApplication1\bin\Debug\sorted.dat", FileMode.Open,FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream);
            string[] line1 = sReader.ReadLine().Split(';');
            string[] line2 = sReader.ReadLine().Split(';');
            int[] lineUp = new int[10000];
            int[] lineDown = new int[10000];
            Console.Write("Введите число: ");
            int result = int.Parse(Console.ReadLine());
            for(int i = 0; i<line1.Length-1;i++)
            {
                lineUp[i] = Convert.ToInt32(line1[i]);
                lineDown[i] = Convert.ToInt32(line2[i]);
            }

            Console.WriteLine("Найден элемент! Позиция: {0}", LinearSearch(lineUp,result));
            Console.WriteLine("Найден элемент! Позиция: {0}", BinarySearch(result, lineUp, lineUp.Length-1));
            Console.WriteLine("Найден элемент! Позиция: {0}", InterpolationSearch(result, lineUp, lineUp.Length-1));
            Console.WriteLine("Найден элемент! Позиция: {0}", LinearSearch(lineDown, result));
            Console.WriteLine("Найден элемент! Позиция: {0}", BinarySearch(result, lineDown, lineDown.Length - 1));
            Console.WriteLine("Найден элемент! Позиция: {0}", InterpolationSearch(result, lineDown, lineDown.Length - 1));
            sReader.Close();
            fStream.Close();
        }
    }
}
