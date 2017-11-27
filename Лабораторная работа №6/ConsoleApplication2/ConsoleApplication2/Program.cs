using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Function()
        {
            BinaryReader bReader = new BinaryReader(new FileStream(@"ex2_1.dat", FileMode.OpenOrCreate, FileAccess.Read));
            BinaryWriter bWriter1 = new BinaryWriter(new FileStream(@"ex2_2.dat", FileMode.OpenOrCreate, FileAccess.Write));
            for (int i = 0;bReader.Endofstream; i++)
            {
                double x = bReader.ReadDouble();
                bWriter1.Write(x);
            }
            bWriter1.Close();
            bReader.Close();
            return;
        }
        static void Main(string[] args)
        {
            double log;
            FileStream fStream = new FileStream(@"ex2_1.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bWriter = new BinaryWriter(fStream);
            for (int i = 1; i < 128; i++)
            {
                log = Math.Log(i, 2);
                bWriter.Write(i - log);
            }
            bWriter.Close();
            fStream.Close();
            Function();
        }
    }
}
