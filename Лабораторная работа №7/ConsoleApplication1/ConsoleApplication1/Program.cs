using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        public static void SelectionSort(int[] a, int l, int r)
        {
            int[] b = (int[])a.Clone();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = l; i < r-1; i++)
            {
                int max = i;
                for (int j = i + 1; j <= r-1; j++)
                    if (b[j] > b[max])
                        max = j;

                Swap(ref b[i], ref b[max]);
            }
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            Console.WriteLine("Сортировка выбором");
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
        }
        public static void InsertionSort(int[] a, int l, int r)
        {
            int[] b = (int[])a.Clone();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = l + 1; i <= r-1; i++)
                for (int j = i; j > l; j--)
                    if (b[j - 1] < b[j])
                        Swap(ref b[j - 1], ref b[j]);
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
        }
        public static void BubbleSort(int[] a, int l, int r)
        {
            int[] b = (int[])a.Clone();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i <= b.Length - 2; i++)
                for (int j = i + 1; j <= b.Length - 1; j++)
                {
                    if (b[i] < b[j])
                    {
                        Swap(ref b[j - 1], ref b[j]);
                    }
                }
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
        }
        public static void ShakerSort(int[] a, int l, int r)
        {
            int[] b = (int[])a.Clone();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                for (int i = l; i < r-1; i++)
                {
                    if (b[i] < b[i + 1])
                    {
                        Swap(ref b[i], ref b[i + 1]);
                    }
                }

                r--;

                for (int i = r; i > l; i--)
                {
                    if (b[i] > b[i - 1])
                    {
                        Swap(ref b[i], ref b[i - 1]);
                    }
                }

                l++;
            }
            while (l <= r);
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
        }
        public static void SortShell(int[] a, int l, int r)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] H = { 57, 23, 10, 4, 1 };
            int HN = H.Length;

            foreach (int step in H)
            {
                int[] b = (int[])a.Clone();
                for (int i = l + step; i <= r-1; i++)
                {
                    int j = i;
                    int tmp = b[i];

                    while (j >= l + step && tmp > a[j - step])
                    {
                        b[j] = b[j - step];
                        j -= step;
                    }
                    b[j] = tmp;
                }
            }
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
        }

        static void Main(string[] args)
        {
            int[] mas1 = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = rand.Next(1000);
            }
            int[] mas2 = (int[])mas1.Clone();
            Array.Sort(mas2);
            int[] mas3 = (int[])mas2.Clone();
            Array.Reverse(mas3);
            //foreach (int elem in mas3)
            //    Console.Write(elem + " ");
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //sw.Stop();
            //TimeSpan time = sw.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds / 10);
            //Console.WriteLine("Время выполнения алгоритма: " + elapsedTime);
            //Console.ReadKey();

            SelectionSort(mas1, 0, mas1.Length - 1);
            InsertionSort(mas1, 0, mas1.Length - 1);
            BubbleSort(mas1, 0, mas1.Length - 1);
            ShakerSort(mas1, 0, mas1.Length - 1);
            SortShell(mas1, 0, mas1.Length - 1);

            SelectionSort(mas2, 0, mas2.Length - 1);
            InsertionSort(mas2, 0, mas2.Length - 1);
            BubbleSort(mas2, 0, mas2.Length - 1);
            ShakerSort(mas2, 0, mas2.Length - 1);
            SortShell(mas2, 0, mas2.Length - 1);

            SelectionSort(mas3, 0, mas3.Length);
            InsertionSort(mas3, 0, mas3.Length);
            BubbleSort(mas3, 0, mas3.Length);
            ShakerSort(mas3, 0, mas3.Length);
            SortShell(mas3, 0, mas3.Length);

            FileStream file = new FileStream(@"sorted.dat", FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(file);
            for (int i = 1; i < mas1.Length; i++)
            {
                sWriter.Write(mas1[i] + ";");
            }
            sWriter.WriteLine();
            for (int i = 1; i < mas2.Length; i++)
            {
                sWriter.Write(mas2[i] + ";");
            }
            sWriter.WriteLine();
            for (int i = 1; i < mas3.Length; i++)
            {
                sWriter.Write(mas3[i] + ";");
            }

            sWriter.Close();
            file.Close();

            Console.ReadKey();
        }
    }
}
