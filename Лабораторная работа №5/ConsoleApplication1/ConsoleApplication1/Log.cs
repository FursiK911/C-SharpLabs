using System;

namespace ConsoleApplication1
{
    partial class Program
    {
        enum ActionLog { None, Add, Delete, Update }
        struct RecordLog
        {
            public DateTime Time;
            public ActionLog Action;
            public string name;
            public TimeSpan gaps;
        }
       static RecordLog[] Log = new RecordLog[50];
    }
}