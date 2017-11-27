using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            structura[] nabor = new structura[100];

            structura peremennaya;

            FileStream file = new FileStream(@"lab.dat", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sReader = new StreamReader(file);
            for (int i = 1; !sReader.EndOfStream; i++)
            {
                string[] line = sReader.ReadLine().Split(';');
                for (int y = 0; y < 4; y++)
                {
                    switch (y)
                    {
                        case 0:
                            nabor[i].fio = line[0];
                            break;
                        case 1:
                            nabor[i].tip = Convert.ToChar(line[1]);
                            break;
                        case 2:
                            nabor[i].year = Convert.ToInt32(line[2]);
                            break;
                        case 3:
                            nabor[i].exp = Convert.ToInt32(line[3]);
                            break;
                    }
                }
            }
            sReader.Close();
            file.Close();

            for (int k = 0; ; k++)
            {
                try
                {
                    Console.WriteLine("Выберите действие:\n1 - Просмотр таблицы\n2 - Добавить запись\n3 - Удалить запись\n4 - Обновить список\n5 - Поиск записей\n6 - Просмотреть лог\n7 - Сортировать\n8 - Выход");
                    string selection = Console.ReadLine();
                    switch (selection[0])
                    {
                        case '1':
                            Console.WriteLine("{0,-12}{1,-19}{2,-20}{3,-10}", "ФИО", "Тип", "Год рождения", "Опыт");
                            for (int i = 1; i < 100; i++)
                            {
                                if (nabor[i].fio == null)
                                    continue;
                                else

                                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);

                            }
                            break;
                        case '2':
                            try
                            {
                                for (int i = 1; i < nabor.Length; i++)
                                {
                                    if (nabor[i].fio == null)
                                    {
                                        Console.WriteLine("Введите ФИО");
                                        peremennaya.fio = (Console.ReadLine());
                                        Console.WriteLine("Введите Тип");
                                        peremennaya.tip = char.Parse(Console.ReadLine());
                                        if (peremennaya.tip != 'С' && peremennaya.tip != 'Т')
                                        {
                                            Console.WriteLine("Такого типа не существует. Введите С-спортсмен или Т-тренер.");
                                            break;
                                        }
                                        Console.WriteLine("Введите Год рождения");
                                        peremennaya.year = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Введите Опыт");
                                        peremennaya.exp = int.Parse(Console.ReadLine());
                                        nabor[i] = peremennaya;
                                        for (int j = 1; ; j++)
                                        {
                                            if (Log[j].Action == ActionLog.None)
                                            {
                                                Log[j].Time = DateTime.Now;
                                                Log[j].Action = ActionLog.Add;
                                                Log[j].name = peremennaya.fio;
                                                Log[0].Time = DateTime.Now;
                                                Log[j].gaps = Log[i].Time.Subtract(Log[j - 1].Time);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }                             
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                            }
                            break;
                        case '3':
                            {
                                try
                                {
                                    Console.WriteLine("Какую запись вы хотите удалить?");
                                    k = int.Parse(Console.ReadLine());
                                    if (nabor[k].fio == null)
                                        Console.WriteLine("Запись пуста!");
                                    for (int i = 1; i < Log.Length - 1; i++)
                                    {
                                        if (Log[i].Action == ActionLog.None)
                                        {
                                            Log[i].Time = DateTime.Now;
                                            Log[i].Action = ActionLog.Delete;
                                            Log[i].name = nabor[k].fio;
                                            Log[0].Time = DateTime.Now;
                                            Log[i].gaps = Log[i].Time.Subtract(Log[i - 1].Time);
                                            break;
                                        }
                                    }
                                    nabor[k].fio = null;
                                    nabor[k].tip = '0';
                                    nabor[k].year = 0;
                                    nabor[k].exp = 0;
                                    for (int j = 0; j < nabor.Length - 1; j++)
                                    {
                                        if (nabor[j].fio == null)
                                        {
                                            nabor[j].fio = nabor[j + 1].fio;
                                            nabor[j].tip = nabor[j + 1].tip;
                                            nabor[j].year = nabor[j + 1].year;
                                            nabor[j].year = nabor[j + 1].year;
                                            nabor[j + 1].fio = null;
                                            nabor[j + 1].tip = '0';
                                            nabor[j + 1].year = 0;
                                            nabor[j + 1].exp = 0;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ошибка: " + ex.Message);
                                }
                                break;
                            }
                        case '4':
                            try
                            {
                                Console.WriteLine("Какую запись вы хотите обновить?");
                                int n = int.Parse(Console.ReadLine());
                                if (nabor[n].fio == null)
                                    Console.WriteLine("Запись пуста!");
                                else
                                {
                                    Console.WriteLine("Введите ФИО");
                                    peremennaya.fio = (Console.ReadLine());
                                    Console.WriteLine("Введите Тип");
                                    peremennaya.tip = char.Parse(Console.ReadLine());
                                    if (peremennaya.tip != 'С' && peremennaya.tip != 'Т')
                                    {
                                        Console.WriteLine("Такого типа не существует. Введите С-спортсмен или Т-тренер.");
                                        break;
                                    }
                                    Console.WriteLine("Введите Год рождения");
                                    peremennaya.year = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите Опыт");
                                    peremennaya.exp = int.Parse(Console.ReadLine());
                                    nabor[n] = peremennaya;
                                    Console.WriteLine("Запись обновлена!");
                                    for (int i = 1; ; i++)
                                    {
                                        if (Log[i].Action == ActionLog.None)
                                        {
                                            Log[0].Time = DateTime.Now;
                                            Log[i].Time = DateTime.Now;
                                            Log[i].Action = ActionLog.Update;
                                            Log[i].name = nabor[n].fio;
                                            Log[i].gaps = Log[i].Time.Subtract(Log[i - 1].Time);
                                            break;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка:" + ex.Message);
                            }
                            break;
                        case '5':
                            bool uslovie = true;
                            for (int p = 0; uslovie; p++)
                            {
                                Console.WriteLine("1 - Фильтр ФИО\n2 - Фильтр Тип\n3 - Фильтр Год рождения\n4 - Фильтр Опыт\n5 - Выход");
                                string selection1 = Console.ReadLine();
                                switch (selection1[0])
                                {
                                    case '1':
                                        try
                                        {
                                            Console.WriteLine("Введите ФИО");
                                            peremennaya.fio = Console.ReadLine();
                                            for (int i = 0; i < nabor.Length; i++)
                                            {
                                                if (peremennaya.fio == nabor[i].fio)
                                                    Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Ошибка: " + ex.Message);
                                        }
                                        break;
                                    case '2':
                                        try
                                        {
                                            Console.WriteLine("Введите тип(С-спортсмен;Т-тренер)");
                                            peremennaya.tip = char.Parse(Console.ReadLine());
                                            if (peremennaya.tip == 'С' || peremennaya.tip == 'Т')
                                            {
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.tip == nabor[i].tip)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого типа не существует. Введите С-спортсмен или Т-тренер.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Ошибка: " + ex.Message);
                                        }
                                        break;
                                    case '3':
                                        try
                                        {
                                            Console.WriteLine("Введите желаемое действие( > ; < ; = ). После нажмите ENTER и введите год");
                                            string FindAction = (Console.ReadLine());
                                            if (FindAction == "<")
                                            {
                                                Console.WriteLine("Введите год");
                                                peremennaya.year = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.year > nabor[i].year && nabor[i].year != 0)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                            if (FindAction == ">")
                                            {
                                                Console.WriteLine("Введите год");
                                                peremennaya.year = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.year <= nabor[i].year)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                            if (FindAction == "=")
                                            {
                                                Console.WriteLine("Введите год");
                                                peremennaya.year = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.year == nabor[i].year)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Ошибка: " + ex.Message);
                                        }
                                        break;
                                    case '4':
                                        try
                                        {
                                            Console.WriteLine("Введите желаемое действие(>;<;=)");
                                            string FindAction2 = (Console.ReadLine());
                                            if (FindAction2 == "<")
                                            {
                                                Console.WriteLine("Введите стаж");
                                                peremennaya.exp = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.exp >= nabor[i].exp && nabor[i].exp != 0)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                            if (FindAction2 == ">")
                                            {
                                                Console.WriteLine("Введите стаж");
                                                peremennaya.exp = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.exp <= nabor[i].exp)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                            if (FindAction2 == "=")
                                            {
                                                Console.WriteLine("Введите стаж");
                                                peremennaya.exp = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < nabor.Length; i++)
                                                {
                                                    if (peremennaya.exp == nabor[i].exp)
                                                        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", nabor[i].fio, nabor[i].tip, nabor[i].year, nabor[i].exp);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Ошибка: " + ex.Message);
                                        }
                                        break;
                                    case '5':
                                        uslovie = false;
                                        break;
                                }
                            }
                            break;
                        case '6':
                            TimeSpan LongGaps = Log[0].gaps;
                            for (int i = 0; i < Log.Length; i++)
                            {
                                if (Log[i].Action != ActionLog.None)
                                    Console.WriteLine(Log[i].Time.Hour + ":" + Log[i].Time.Minute + ":" + Log[i].Time.Second + " - " + Log[i].Action + " - " + Log[i].name);
                            }
                            for (int j = 1; j < Log.Length; j++)
                            {
                                if (LongGaps < Log[j].gaps)
                                    LongGaps = Log[j].gaps;

                            }
                            Console.WriteLine("\n{0:00} : {1:00} : {2:00} - Самый долгий период бездействия пользователя", LongGaps.Hours, LongGaps.Minutes, LongGaps.Seconds);
                            break;
                        case '7':
                            {
                                for (int i = 1; nabor[i].year != 0 && i <= nabor.Length; i++)
                                    for (int j = i; j > 0; j--)
                                        if (nabor[j - 1].year > nabor[j].year)
                                        {
                                            int tmp = nabor[j-1].year;
                                            nabor[j - 1].year = nabor[j].year;
                                            nabor[j].year = tmp;
                                        }
                                break;
                            }
                        case '8':
                            file = new FileStream(@"lab.dat", FileMode.Create, FileAccess.Write);
                            StreamWriter sWriter = new StreamWriter(file);
                            for (int i = 1; i < nabor.Length; i++)
                            {
                                if (nabor[i].fio == null)
                                    continue;
                                sWriter.WriteLine(nabor[i].fio + ";" + Convert.ToString(nabor[i].tip) + ";" + Convert.ToString(nabor[i].year) + ";" + Convert.ToString(nabor[i].exp) + ";");
                            }
                            sWriter.Close();
                            file.Close();
                            return;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ошибка: Вы не выбрали действие.");
                }
            }
        }
    }
}