using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab6_prog5
{
    class Program
    {
        static string GetSizeByte(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(2, SeekOrigin.Begin);
            return String.Format("Size : {0}", bReader.ReadInt32());
        }
        static string GetSizeX(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(18, SeekOrigin.Begin);
            return String.Format("SizeX : {0}", bReader.ReadInt32());
        }
        static string GetSizeY(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(22, SeekOrigin.Begin);
            return String.Format("SizeY : {0}", bReader.ReadInt32());
        }
        static string GetByteOnPixels(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(28, SeekOrigin.Begin);
            int byteOnPixels = bReader.ReadInt16();
            switch (byteOnPixels)
            {
                case 1:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "monochrome palette. Кол-во цветов = 2");
                case 4:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "4bit palletized.  Кол-во цветов = 16");
                case 8:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "8bit palletized.  Кол-во цветов = 256");
                case 16:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "16bit RGB.  Кол-во ветов = 65536");
                case 24:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "24bit RGB.  Кол-во ветов = 16M");
                default:
                    return String.Format("Type BI : {0} ({1})", byteOnPixels, "None");
            }
        }
        static string GetVPixel(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(38, SeekOrigin.Begin);
            return String.Format("VerticalPixel : {0}", bReader.ReadInt32());
        }
        static string GetHPixel(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(42, SeekOrigin.Begin);
            return String.Format("HorizontalPixel : {0}", bReader.ReadInt32());
        }
        static string GetTypeBI(FileStream fStream, BinaryReader bReader)
        {
            fStream.Seek(30, SeekOrigin.Begin);
            int typeBi = bReader.ReadInt32();
            switch(typeBi)
            {
                case 0:
                    return String.Format("Type BI : {0} ({1})", typeBi, "без сжатия");
                case 1:
                    return String.Format("Type BI : {0} ({1})", typeBi, "8 bit RLE сжатие");
                case 2:
                    return String.Format("Type BI : {0} ({1})", typeBi, "4 bit RLE сжатие");
                default:
                    return String.Format("Type BI : {0} ({1})", typeBi, "None");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Имя .bmp файла");
            string pathName = Console.ReadLine();
            try
            {
                FileStream fStream = new FileStream(pathName + @".bmp", FileMode.Open, FileAccess.Read);
                BinaryReader bReader = new BinaryReader(fStream);
                Console.WriteLine(
                    "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
                    GetSizeByte(fStream,bReader),
                    GetSizeX(fStream,bReader),
                    GetSizeY(fStream,bReader),
                    GetByteOnPixels(fStream,bReader),
                    GetVPixel(fStream,bReader),
                    GetHPixel(fStream,bReader),
                    GetTypeBI(fStream,bReader)
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
