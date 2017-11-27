using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laboratory6LW3
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinaryReader bReader = new BinaryReader(new FileStream("lab.txt", FileMode.Open, FileAccess.Read)); 
            //BinaryWriter bWriter = new BinaryWriter(new FileStream("lab1.txt", FileMode.OpenOrCreate, FileAccess.Write)); 
            StreamReader sReader = new StreamReader(new FileStream("lab.txt", FileMode.OpenOrCreate, FileAccess.Read));
            StreamWriter sWriter = new StreamWriter(new FileStream("lab1.txt", FileMode.OpenOrCreate, FileAccess.Write));
            int k = 0;
            string sr = sReader.ReadLine();
            char[] array = sr.ToCharArray();
            for (int i = 0; i<array.Length; i++) //bReader.PeekChar() < -1 
            {
                if (Char.IsDigit(array[i]))
                {
                    array[i] = '*';
                    sWriter.Write(array[i]);
                    k++;
                }
                else
                {
                    sWriter.Write(array[i]);
                }


            }
            sWriter.Close();
            sReader.Close();
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
