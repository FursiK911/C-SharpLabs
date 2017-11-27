using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"E:\Lab6_Temp");
            FileStream file = new FileStream(@"C:\Users\Дмитрий\Desktop\Учеба\C#\Лабораторная работа №6\ConsoleApplication1\ConsoleApplication1\bin\Debug\lab.dat", FileMode.Open);
            FileStream file2 = new FileStream(@"E:\Lab6_Temp\lab_backup.dat", FileMode.Create);
            file.CopyTo(file2);
            file2.Close();
            file.Close();
            FileInfo fInfo = new FileInfo(@"E:\Lab6_Temp\lab_backup.dat");
            string info = String.Format("Размер - {0}; Последняя запись - {1}; Последний доступ - {2}", fInfo.Length, fInfo.LastWriteTime, fInfo.LastAccessTime);
            Console.WriteLine(info);
               
        }
    }
}
