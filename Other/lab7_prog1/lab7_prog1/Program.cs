using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_prog1
{

    enum position { NaN, Assistans = 'А', Student = 'C', Lecturer = 'П' }
    enum operation { NaN, Add, Delete, Update };

    partial class Program
    {
        static int maxyear = 2017;
        struct Log
        {
            public DateTime time;
            public operation oper;
            public string name;
        }
        struct Department
        {
            public string name;
            public ushort year;
            public double salary;
            public position post;
        }
          static void GetSortedStructUp(Department[] departament)
          {
              for (int i = 1; departament[i].year != 0 && i <= departament.Length - 1; i++)
              {
                  int j = i; 
                  Department tmp = departament[i]; 

                  while (j <= departament.Length - 1 && departament[j + 1].year != 0 && tmp.year > departament[j + 1].year)
                  {
                      departament[j] = departament[j + 1];
                      j++;
                  }

                  departament[j] = tmp;
              }
          }
          static void GetSortedStructDown(Department[] departament)
          {
              for (int i = 1; departament[i].year != 0 && i <= departament.Length - 1; i++)
              {
                  int j = i;
                  Department tmp = departament[i];
                  while (j >= 1 && tmp.year > departament[j - 1].year)
                  {
                      departament[j] = departament[j - 1];
                      j--;
                  }
                  departament[j] = tmp;
              }
          }
        static void GetSortedStruct(ref Department[] departament)
        {
            for (int i = 0; ; i++)
            {
                try
                {
                    Console.WriteLine("0 : По убыванию\n1 : По возрастанию\n");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    if (selection >= 2 || selection < 0)
                    {
                        throw new FormatException();
                    }
                    if (selection == 0)
                    {
                        GetSortedStructDown(departament);
                    }
                    if (selection == 1)
                    {
                        GetSortedStructUp(departament);
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
        static void GetSave(Department[] departament)
        {
            FileStream fStream = new FileStream(@"lab.dat", FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fStream);
            for (int user = 0; departament[user].post != position.NaN; user++)
            {
                sWriter.WriteLine(departament[user].name + ";" + Convert.ToString((char)departament[user].post) + ";" + Convert.ToString(departament[user].year) + ";" + Convert.ToString(departament[user].salary));
            }
            sWriter.Close();
            fStream.Close();
        }
        static bool CheckOut(Department[] departament, int i)
        {
            if (departament[i].name == null && departament[i].year == 0 && departament[i].salary == 0.0 && departament[i].post == 0)
            {
                return false;
            }
            return true;
        }
        static void GetStandart(ref Department[] departament)
        {
            //Department dep;
            FileStream fStream = new FileStream(@"lab.dat", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream);

            for (int user = 0; !sReader.EndOfStream; user++)
            {
                string[] info = sReader.ReadLine().Split(';');
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            departament[user].name = info[0];
                            break;
                        case 1:
                            switch (info[1][0])
                            {
                                case 'А':
                                    departament[user].post = position.Assistans;
                                    break;
                                case 'C':
                                    departament[user].post = position.Student;
                                    break;
                                case 'П':
                                    departament[user].post = position.Lecturer;
                                    break;
                            }
                            break;
                        case 2:
                            departament[user].year = Convert.ToUInt16(info[2]);
                            break;
                        case 3:
                            departament[user].salary = Convert.ToDouble(info[3]);
                            break;
                    }
                }
            }
            sReader.Close();
            fStream.Close();
        }
        static void Menu(ref Department[] departament, ref Log[] log)
        {
            TimeSpan maxHoldTime = TimeSpan.MinValue;
            for (int i = 0; ; i++)
            {
                Console.WriteLine("1 : Просмотр таблицы\n2 : Добавить запись\n3 : Удалить запись\n4 : Обновить запись\n5 : Поиск записей\n6 : Просмотреть лог\n7 : Выход\n8 : Отсортировать структуру\n");
                switch (GetOperation(ref maxHoldTime))
                {
                    case 1:
                        ViewPersons(departament);
                        break;
                    case 2:
                        AddPerson(ref departament, ref log);
                        break;
                    case 3:
                        DeletePerson(ref departament, ref log);
                        break;
                    case 4:
                        RefreshPerson(ref departament, ref log);
                        break;
                    case 5:
                        FindPerson(departament);
                        break;
                    case 6:
                        ViewLog(log, maxHoldTime);
                        break;
                    case 7:
                        Console.WriteLine("");
                        return;
                    case 8:
                        GetSortedStruct(ref departament);
                        break;
                }
            }
        }
        static int GetOperation(ref TimeSpan maxHoldTime)
        {
            sbyte selection;
            DateTime startTime;
            TimeSpan holdTime;
            try
            {
                Console.Write("Ваш выбор: ");
                startTime = DateTime.Now;
                selection = Convert.ToSByte(Console.ReadLine());
                holdTime = DateTime.Now - startTime;
                if (holdTime > maxHoldTime)
                {
                    maxHoldTime = holdTime;
                }
                Console.WriteLine();
                if (selection > 8 || selection <= 0)
                {
                    throw new FormatException();
                }
                return selection;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message + "Повторите попытку.");
                return GetOperation(ref maxHoldTime);
            }

        }
        static void ViewPersons(Department[] departament)
        {
            Console.WriteLine("\nОтдел кадров:\n{0,-20}{1,-15}{2,-10}{3,-12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
            for (int i = 0; position.NaN != departament[i].post; i++)
            {
                Console.WriteLine("{0,-20}{1,-15}{2,-10}{3,-12:#.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
            }
            Console.WriteLine("Перечисляемый тип: П - преподаватель, С - студент, А - аспирант\n");
        }
        static void AddPerson(ref Department[] departament, ref Log[] log)
        {
            Department dep;
            short number = 0;
            for (short i = 0; i < departament.Length - 1; i++)
            {
                if (departament[i].name == null && departament[i].post == position.NaN && departament[i].year == 0 && departament[i].salary == 0.0)
                {
                    number = i;
                    break;
                }
            }
            Console.Write("\nВведите ФИО:");
            dep.name = Console.ReadLine();
            for (int i = 0; ; i++)
            {
                try
                {
                    Console.Write("Введите должность:");
                    char tmp = char.ToUpper(Console.ReadLine()[0]);
                    switch (tmp)
                    {
                        case 'А':
                            dep.post = position.Assistans;
                            break;
                        case 'С':
                            dep.post = position.Student;
                            break;
                        case 'П':
                            dep.post = position.Lecturer;
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            for (int i = 0; ; i++)
            {
                Console.Write("Введите год рождения:");
                try
                {
                    dep.year = Convert.ToUInt16(Console.ReadLine());
                    if (dep.year < 1900 || dep.year >= maxyear)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            for (int i = 0; ; i++)
            {
                Console.Write("Введите оклад:");
                try
                {
                    dep.salary = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            departament[number] = dep;
            Console.WriteLine("\nЗапись \"{0}\" добавлена.\n", dep.name);
            //log
            string name = dep.name;
            AddLog(ref log, operation.Add, name);
        }
        static void DeletePerson(ref Department[] departament, ref Log[] log)
        {
            Department dep;
            ushort number = 0;
            for (int i = 0; ; i++)
            {
                Console.Write("Номер записи которую желаете удалить: ");
                try
                {
                    number = Convert.ToUInt16(Console.ReadLine());
                    if (departament[number].name == null && departament[number].post == position.NaN && departament[number].year == 0 && departament[number].salary == 0.0)
                    {
                        Console.WriteLine("\nЗаписи под номером {0} несуществует\n", number);
                    }
                    else
                    {
                        Console.WriteLine("\nЗапись под номером {0} удалена.\n", number);
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод.");
                }
            }
            string name = departament[number].name;
            dep.name = null;
            dep.post = position.NaN;
            dep.year = 0;
            dep.salary = 0.0;
            departament[number] = dep;
            int count = 0;
            for (int i = number; i <= departament.Length - 1 && count != 2; i++)
            {
                departament[i] = departament[i + 1];
                departament[i + 1] = dep;
                if (departament[i].name == null && departament[i].post == position.NaN && departament[i].year == 0 && departament[i].salary == 0.0)
                {
                    count++;
                }
            }
            AddLog(ref log, operation.Delete, name);
        }
        static void RefreshPerson(ref Department[] departament, ref Log[] log)
        {
            ushort number = 0;
            Department dep;
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Номер записи которую желаете обновить: ");
                try
                {
                    number = Convert.ToUInt16(Console.ReadLine());
                    if (departament[number].name == null && departament[number].post == position.NaN && departament[number].year == 0 && departament[number].salary == 0.0)
                    {
                        Console.WriteLine("\nЗаписи под номером {0} несуществует\n", number);
                        return;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод.");
                }
            }
            Console.Write("\nВведите ФИО:");
            dep.name = Console.ReadLine();
            string name = dep.name;
            for (int i = 0; ; i++)
            {
                try
                {
                    Console.Write("Введите должность:");
                    char tmp = Console.ReadLine()[0];
                    switch (tmp)
                    {
                        case 'А':
                            dep.post = position.Assistans;
                            break;
                        case 'C':
                            dep.post = position.Student;
                            break;
                        case 'П':
                            dep.post = position.Lecturer;
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            for (int i = 0; ; i++)
            {
                Console.Write("Введите год рождения:");
                try
                {
                    dep.year = Convert.ToUInt16(Console.ReadLine());
                    if (dep.year < 1900 || dep.year >= maxyear)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            for (int i = 0; ; i++)
            {
                Console.Write("\nВведите оклад:");
                try
                {
                    dep.salary = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Повторите ввод");
                }
            }
            Console.WriteLine("\nЗапись \"{0}\" обновлена.\n", name);
            AddLog(ref log, operation.Update, name);
            departament[number] = dep;
        }
        static void FindPerson(Department[] departament)
        {
            int selection;
            Console.Write("\nВыберите фильтр: \n1 – Оклад больше или равен 1000\n2 – Оклад меньше 1000\n3 – Возраст до 18 \n4 – Возраст от 18\n5 – Преподаватели\n6 – Студенты\n7 - Аспиранты\n8 - Поиск по фамилии\n");
            for (int i = 0; ; i++)
            {
                try
                {
                    Console.WriteLine("\nНомер фильтра:");
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (selection > 8 || selection <= 0)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message + "Повторите попытку.");
                }
            }
            switch (selection)
            {
                case 1:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].salary >= 1000)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].salary < 1000)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].year < 1998)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].year >= 1998)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].post == position.Lecturer)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].post == position.Student)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].post == position.Assistans)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("\nВведите фамилию: ");
                        string name = Console.ReadLine().ToLower();
                        Console.WriteLine("\nОтдел кадров:\n{0,7}\t{1,17}\t{2}\t{3,12}", "Фамилия", "Должность", "Год рожд", "Оклад(грн)");
                        for (int i = 0; i < departament.Length && CheckOut(departament, i); i++)
                        {
                            if (departament[i].name.ToLower().IndexOf(name) != -1)
                            {
                                Console.WriteLine("{0,9}\t{1,1}\t{2,12}\t{3,20: #.###,##}", departament[i].name, (char)departament[i].post, departament[i].year, departament[i].salary);
                            }
                        }
                        Console.WriteLine();
                        break;
                    }
                default:
                    break;
            }

        }
        static void AddLog(ref Log[] log, operation op, string name)
        {
            for (int i = 0; i <= log.Length - 1; i++)
            {
                if (log[i].oper == operation.NaN)
                {
                    log[i].oper = op;
                    log[i].time = DateTime.Now;
                    log[i].name = name;
                    break;
                }
                else if (i == log.Length - 1)
                {
                    //№1
                }
            }
        }
        static void ViewLog(Log[] log, TimeSpan maxHoldTime)
        {
            for (int i = 0; operation.NaN != log[i].oper; i++)
            {
                Console.Write("{0:D2}:{1:D2}:{2:D2} - ", log[i].time.Hour, log[i].time.Minute, log[i].time.Second);
                switch (log[i].oper)
                {
                    case operation.Add:
                        Console.Write("Добавлена запись ");
                        break;
                    case operation.Delete:
                        Console.Write("Удалена запись ");
                        break;
                    case operation.Update:
                        Console.Write("Обновлена запись ");
                        break;
                    default:
                        break;
                }
                Console.Write("\"{0}\"\n", log[i].name);
            }
            Console.WriteLine("\n{0:D2}:{1:D2}:{2:D2} - Самый долгий период бездействия пользователя\n", maxHoldTime.Hours, maxHoldTime.Minutes, maxHoldTime.Seconds);
        }
        static void Main(string[] args)
        {
            Department[] departament = new Department[200];
            Log[] log = new Log[50];
            GetStandart(ref departament);
            Menu(ref departament, ref log);
            GetSave(departament);
        }
    }
}
