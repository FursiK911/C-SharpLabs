using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab7_prog2
{
    enum typeofarray {Random,SortedUp,SortedDown};
    struct AlgorythmsWork
    {
        public TimeSpan time;
        public string namealgorythms;
        public typeofarray typeArray;
        public long comparecount;
        public long reshufflecount;
        public int[] array;
    }
    class SystemCheckedSortAlgorythm
    {
        struct WorkAlg
        {
            public string name;
            public bool value;
        }
        List<WorkAlg> workalg = new List<WorkAlg>();
        FileStream fStream;
        public SystemCheckedSortAlgorythm(FileStream fStream)
        {
            this.fStream = fStream;
        }
        public void TestUP(string namesort, string sourceArray)
        {
            WorkAlg wa = new WorkAlg();
            wa.name = namesort;
            string[] array = sourceArray.Split(' ');
            for (int i = 1; i <= Program.arraysLenght - 1; i++)
            {
                if (Convert.ToInt32(array[i - 1]) <= Convert.ToInt32(array[i]))
                    wa.value = true;
                else
                {
                    wa.value = false;
                    break;
                }
            }
            workalg.Add(wa);
        }
        public void TestDown(string namesort, string sourceArray)
        {
            WorkAlg wa = new WorkAlg();
            wa.name = namesort;
            string[] array = sourceArray.Split(' ');
            for (int i = 1; i <= Program.arraysLenght - 1; i++)
            {
                if (Convert.ToInt32(array[i - 1]) >= Convert.ToInt32(array[i]))
                    wa.value = true;
                else
                {
                    wa.value = false;
                    break;
                }
            }
            workalg.Add(wa);
        }
        public void TestDataAlgorythm()
        {
            try
            {
                StreamReader sReader = new StreamReader(fStream);
                for (int i = 0; ; i++)
                {
                    string[] source = sReader.ReadLine().Split(';');
                    if (source.Length > 1)
                    {
                        if (source[0].IndexOf("up") != -1)
                            TestUP(source[0],source[5]);
                        else
                            TestDown(source[0],source[5]);
                    }
                }
            }
            catch
            {
                CloseStream();
            }
            PrintInfo();
        }
        public void PrintInfo()
        {
            Console.WriteLine();
            foreach (var item in workalg)
            {
                Console.WriteLine("{0} - {1}",item.name,item.value);
            }
        }
        private void CloseStream()
        {
            fStream.Close();
        }
    }
    class AlgorythmsSort
    {
        public List<AlgorythmsWork> algorythmData = new List<AlgorythmsWork>();
        public AlgorythmsSort(List<AlgorythmsWork> algorythmData)
        {
            this.algorythmData = algorythmData;
        }
        public int[] CopyArray(int[] intArray)
        {
            int[] array = new int[intArray.Length];
            intArray.CopyTo(array, 0);
            return array;
        }
        public void GetTest(int[] intArray,typeofarray typeofArray)
        {
           BubbleUp(CopyArray(intArray), typeofArray);
           BubbleDown(CopyArray(intArray), typeofArray);
           InsertsUp(CopyArray(intArray), typeofArray);
           InsertsDown(CopyArray(intArray), typeofArray);
           ChoiceUp(CopyArray(intArray), typeofArray);
           ChoiceDown(CopyArray(intArray), typeofArray);
           ShakerUp(CopyArray(intArray), typeofArray);
           ShakerDown(CopyArray(intArray), typeofArray);
           ShellUp(CopyArray(intArray), typeofArray);
           ShellDown(CopyArray(intArray), typeofArray);
        }
        public TimeSpan GetWorkLastAlgorythm(DateTime dtStartWorking, DateTime dtEndWorking)
        {
            return dtEndWorking - dtStartWorking;
        }
        public void BubbleUp(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 0; i <= array.Length - 2; i++)
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    aw.comparecount++;
                    if (array[i] > array[j])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Bubble up";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}",aw.namealgorythms,aw.typeArray);
        }
        public void BubbleDown(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 0; i <= array.Length - 2; i++)
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    aw.comparecount++;
                    if (array[i] < array[j])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Bubble down";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void InsertsUp(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int key = array[i];
                while (aw.comparecount++ != -1 & j > 0 && key < array[j - 1])
                {
                    aw.reshufflecount++;
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = key;
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Insert up";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void InsertsDown(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int key = array[i];
                while (aw.comparecount++ != -1 & j > 0 && key > array[j - 1])
                {
                    aw.reshufflecount++;
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = key;
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Insert down";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ChoiceUp(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 0; i <= array.Length -1; i++)
            {
                int min = i;
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    aw.comparecount++;
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[min];
                array[min] = tmp;
                aw.reshufflecount++;
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Choice up";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ChoiceDown(int[] array, typeofarray typeofArray) 
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            for (int i = 0; i <= array.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    aw.comparecount++;
                    if (array[j] > array[max])
                    {
                        max = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[max];
                array[max] = tmp;
                aw.reshufflecount++;
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Choice down";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ShakerUp(int[] array, typeofarray typeofArray)
        {
            int l = 0;
            int r = array.Length - 1;
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            do
            {
                //Сдвигаем к концу массива "тяжелые элементы"
                for (int i = l; i < r; i++)
                {
                    aw.comparecount++;
                    if (array[i] > array[i + 1])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
                r--;
                //Сдвигаем к началу массива "легкие элементы"
                for (int i = r; i > l; i--)
                {
                    aw.comparecount++;
                    if (array[i] < array[i - 1])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
                l++;
            }
            while (l <= r);
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Shaker up";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ShakerDown(int[] array, typeofarray typeofArray)
        {
            int l = 0;
            int r = array.Length - 1;
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            do
            {
                //Сдвигаем к концу массива "тяжелые элементы"
                for (int i = l; i < r; i++)
                {
                    aw.comparecount++;
                    if (array[i] < array[i + 1])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
                r--;
                //Сдвигаем к началу массива "легкие элементы"
                for (int i = r; i > l; i--)
                {
                    aw.comparecount++;
                    if (array[i] > array[i - 1])
                    {
                        aw.reshufflecount++;
                        int tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                    }
                }
                l++;
            }
            while (l <= r);
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Shaker down";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ShellUp(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            int[] H = {20, 10, 4, 1 };
            int HN = H.Length;
            foreach (int step in H)
            {
                for (int i = 0 + step; i <= array.Length - 1; i++)
                {
                    int j = i;
                    int tmp = array[i];
                    while (j >= 0 + step && tmp < array[j - step] && aw.comparecount++ != -1)
                    {
                        aw.reshufflecount++;
                        array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = tmp;
                }
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Shell up";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
        public void ShellDown(int[] array, typeofarray typeofArray)
        {
            AlgorythmsWork aw = new AlgorythmsWork();
            DateTime dtStartWorking = DateTime.Now;
            aw.comparecount = 0;
            aw.reshufflecount = 0;
            int[] H = { 20, 10, 4, 1 };
            int HN = H.Length;
            foreach (int step in H)
            {
                for (int i = 0 + step; i <= array.Length - 1; i++)
                {
                    int j = i;
                    int tmp = array[i];
                    while (j >= 0 + step && tmp > array[j - step] && aw.comparecount++ != -1)
                    {
                        aw.reshufflecount++;
                        array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = tmp;
                }
            }
            aw.time = GetWorkLastAlgorythm(dtStartWorking, DateTime.Now);
            aw.namealgorythms = "Shell down";
            aw.typeArray = typeofArray;
            aw.array = array;
            algorythmData.Add(aw);
            Console.WriteLine("{0} отработал. Тип массива: {1}", aw.namealgorythms, aw.typeArray);
        }
    }
    class Program
    {
        public static List<AlgorythmsWork> algorythmData = new List<AlgorythmsWork>();
        public static int arraysLenght = 10000;
        public static void GetSystemCheckedSortAlgorythm()
        {
            try
            {
                SystemCheckedSortAlgorythm scsa = new SystemCheckedSortAlgorythm(new FileStream(@"sorted.dat", FileMode.Open, FileAccess.Read));
                scsa.TestDataAlgorythm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static AlgorythmsSort algorythm = new AlgorythmsSort(algorythmData);
        static public void RecordAlgorythmsWork(List<AlgorythmsWork> algorythmData)
        {
                using (StreamWriter sWriter = new StreamWriter(new FileStream(@"sorted.dat", FileMode.Create, FileAccess.Write)))
                {
                    foreach (AlgorythmsWork item in algorythmData)
                    {
                        sWriter.Write(String.Format("{0};{1};{2};{3};{4}:{5};",
                            item.namealgorythms,
                            item.typeArray,
                            item.comparecount,
                            item.reshufflecount,
                            item.time.Seconds,
                            item.time.Milliseconds
                            ));
                        for (int i = 0; i <= item.array.Length - 1; i++)
                        {
                            sWriter.Write(item.array[i] + " ");
                        }
                        sWriter.Write(sWriter.NewLine);
                    }
            }
        }
        static void PrintArray(int[] intArray)
        {
            for (int i = 0; i <= intArray.Length - 1; i++)
            {
                Console.Write(intArray[i] + " ");
                if (i % 10 == 0)
                    Console.WriteLine();
            }
        }
        static List<AlgorythmsWork> SortAlgorythms(List<AlgorythmsWork> algorythmData)
        {
            List<AlgorythmsWork> sortedAlgUnFull = new List<AlgorythmsWork>();
            List<AlgorythmsWork> sortedAlgFull = new List<AlgorythmsWork>();
            for (int i = 0; i < algorythmData.Count - 1; i++)// получение только рандом массивов
            {
                if (algorythmData[i].typeArray == typeofarray.Random)
                {
                    sortedAlgUnFull.Add(algorythmData[i]);
                }
            }
            for (int i = 1; i < sortedAlgUnFull.Count; i++)
            {
                int j = i;
                AlgorythmsWork tmp = sortedAlgUnFull[i];
                while (j > 0 && tmp.time.CompareTo(sortedAlgUnFull[j - 1].time) == 1)
                {
                    sortedAlgUnFull[j] = sortedAlgUnFull[j - 1]; 
                    j--;
                }
                sortedAlgUnFull[j] = tmp;
            }
            sortedAlgFull.AddRange(sortedAlgUnFull);
            sortedAlgUnFull.Clear();
            for (int i = 0; i < algorythmData.Count - 1; i++)// получение только рандом массивов
            {
                if (algorythmData[i].typeArray == typeofarray.SortedUp)
                {
                    sortedAlgUnFull.Add(algorythmData[i]);
                }
            }
            for (int i = 1; i < sortedAlgUnFull.Count; i++)
            {
                int j = i;
                AlgorythmsWork tmp = sortedAlgUnFull[i];
                while (j > 0 && tmp.time.CompareTo(sortedAlgUnFull[j - 1].time) == 1)
                {
                    sortedAlgUnFull[j] = sortedAlgUnFull[j - 1];
                    j--;
                }
                sortedAlgUnFull[j] = tmp;
            }
            sortedAlgFull.AddRange(sortedAlgUnFull);
            sortedAlgUnFull.Clear();
            for (int i = 0; i < algorythmData.Count - 1; i++)// получение только рандом массивов
            {
                if (algorythmData[i].typeArray == typeofarray.SortedDown)
                {
                    sortedAlgUnFull.Add(algorythmData[i]);
                }
            }
            for (int i = 1; i < sortedAlgUnFull.Count; i++)
            {
                int j = i;
                AlgorythmsWork tmp = sortedAlgUnFull[i];
                while (j > 0 && tmp.time.CompareTo(sortedAlgUnFull[j - 1].time) == 1)
                {
                    sortedAlgUnFull[j] = sortedAlgUnFull[j - 1];
                    j--;
                }
                sortedAlgUnFull[j] = tmp;
            }
            sortedAlgFull.AddRange(sortedAlgUnFull);
            return sortedAlgFull;
        }
        static void PrintInfoAlgorythms(List<AlgorythmsWork> algorythmData)
        {
            algorythmData = SortAlgorythms(algorythmData);
            for (int i = 0; i <= algorythmData.Count - 1; i++)
            {
                Console.WriteLine(String.Format("DATA SOURCE;{0}  ({3})  - {1}:{2} \n Compare -   {4,-10}\n Reshuffle - {5,-10}\n",
                    algorythmData[i].namealgorythms,
                    algorythmData[i].time.Seconds,
                    algorythmData[i].time.Milliseconds,
                    algorythmData[i].typeArray,
                    algorythmData[i].comparecount,
                    algorythmData[i].reshufflecount
                    ));
            }
        }
        static void GenerateArray(int[] intArray,typeofarray typeofArray)
        {
            Random rnd = new Random();
            switch (typeofArray)
            {
                case typeofarray.Random:
                    for (int i = 0; i <= intArray.Length - 1; i++)
                    {
                        intArray[i] = rnd.Next(20);
                    }
                    break;
                case typeofarray.SortedDown:
                     for (int i = intArray.Length - 1; i >= 0 ; i--)
                    {
                        intArray[i] = i;
                    }
                    break;
                case typeofarray.SortedUp:
                    for (int i = 0; i <= intArray.Length - 1; i++)
                    {
                        intArray[i] = i;
                    }
                    break;
            }
            
        }
        static void Main(string[] args)
        {
            int[] intArray = new int[arraysLenght];
            GenerateArray(intArray,typeofarray.Random);
            algorythm.GetTest(intArray,typeofarray.Random);
            GenerateArray(intArray, typeofarray.SortedDown);
            algorythm.GetTest(intArray, typeofarray.SortedDown);
            GenerateArray(intArray, typeofarray.SortedUp);
            algorythm.GetTest(intArray, typeofarray.SortedUp);
            Console.Clear();
            PrintInfoAlgorythms(algorythmData);
            RecordAlgorythmsWork(algorythmData);
            Console.Write("Проверка данных...");
            GetSystemCheckedSortAlgorythm();
            Console.ReadKey();
        }
    }
}
