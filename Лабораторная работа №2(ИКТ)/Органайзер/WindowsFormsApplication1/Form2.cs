using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public struct Event
    {
        public string time;
        public string data;
        public string action;
        public string type;
    }
    public partial class Form2 : Form
    {
        public static int index;
        public static int count = 0;
        public static Event add;
        public static Event[] mas = new Event[5];
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.S && e.Control)
            {
                FileStream fStream = new FileStream(@"lab.dat", FileMode.Create, FileAccess.Write);
                StreamWriter sWriter = new StreamWriter(fStream);
                for (int k = 0; k <= mas.Length - 1 && mas[k].data != null; k++)
                {
                    sWriter.Write("{0};{1};{2}", mas[k].data, mas[k].action, mas[k].time);
                    //sWriter.Write(mas[k].type); 
                    sWriter.WriteLine();
                    e.Handled = true;
                }
                sWriter.Close();
                fStream.Close();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                Process.Start(@"lab.dat");
            }
            else if (e.KeyCode == Keys.Delete)
            {
                int index = listView1.FocusedItem.Index;
                listView1.Items.Clear();
                for (int i = index; i < count; i++)
                {
                    mas[i] = mas[i + 1];
                }
                count--;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i].data != null)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                        lvi.SubItems.Add(Convert.ToString(mas[i].time));
                        lvi.SubItems.Add(mas[i].action);
                        switch (mas[i].type)
                        {
                            case "Задание":
                                lvi.ImageIndex = 0;
                                break;
                            case "Встреча":
                                lvi.ImageIndex = 1;
                                break;
                            case "Памятка":
                                lvi.ImageIndex = 2;
                                break;
                        }
                        listView1.Items.Add(lvi);
                        count++;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            listView1.Items.Clear();
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].data != null)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                    lvi.SubItems.Add(Convert.ToString(mas[i].time));
                    lvi.SubItems.Add(mas[i].action);
                    switch (mas[i].type)
                    {
                        case "Задание":
                            lvi.ImageIndex = 0;
                            break;
                        case "Встреча":
                            lvi.ImageIndex = 1;
                            break;
                        case "Памятка":
                            lvi.ImageIndex = 2;
                            break;
                    }
                    listView1.Items.Add(lvi);
                    count++;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (radioButton1.Checked)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i].data != null && this.comboBox1.Text == mas[i].type)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                        lvi.SubItems.Add(Convert.ToString(mas[i].time));
                        lvi.SubItems.Add(mas[i].action);
                        switch (mas[i].type)
                        {
                            case "Задание":
                                lvi.ImageIndex = 0;
                                break;
                            case "Встреча":
                                lvi.ImageIndex = 1;
                                break;
                            case "Памятка":
                                lvi.ImageIndex = 2;
                                break;
                        }
                        listView1.Items.Add(lvi);
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (radioButton2.Checked)
            {
                for (int i = 0; i < mas.Length && mas[i].data != null; i++)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                    lvi.SubItems.Add(Convert.ToString(mas[i].time));
                    lvi.SubItems.Add(mas[i].action);
                    switch (mas[i].type)
                    {
                        case "Задание":
                            lvi.ImageIndex = 0;
                            break;
                        case "Встреча":
                            lvi.ImageIndex = 1;
                            break;
                        case "Памятка":
                            lvi.ImageIndex = 2;
                            break;
                    }
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (radioButton1.Checked)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i].data != null && this.comboBox1.Text == mas[i].type)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                        lvi.SubItems.Add(Convert.ToString(mas[i].time));
                        lvi.SubItems.Add(mas[i].action);
                        switch (mas[i].type)
                        {
                            case "Задание":
                                lvi.ImageIndex = 0;
                                break;
                            case "Встреча":
                                lvi.ImageIndex = 1;
                                break;
                            case "Памятка":
                                lvi.ImageIndex = 2;
                                break;
                        }
                        listView1.Items.Add(lvi);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            BubbleSort();
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].data != null)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                    lvi.SubItems.Add(Convert.ToString(mas[i].time));
                    lvi.SubItems.Add(mas[i].action);
                    switch (mas[i].type)
                    {
                        case "Задание":
                            lvi.ImageIndex = 0;
                            break;
                        case "Встреча":
                            lvi.ImageIndex = 1;
                            break;
                        case "Памятка":
                            lvi.ImageIndex = 2;
                            break;
                    }
                    listView1.Items.Add(lvi);
                }
            }

        }

        public void Swap(ref string a, ref string b)
        {
            string tmp = a;
            a = b;
            b = tmp;
        }

        public void BubbleSort()
        {
            for (int i = 0; i < mas.Length - 1; i++)
                for (int j = mas.Length - 1; j > i; j--)
                    if (mas[j - 1].time != null && mas[j].time != null)
                        if (DateTime.Parse(mas[j - 1].time) > DateTime.Parse(mas[j].time))
                        {
                            Swap(ref mas[j - 1].data, ref mas[j].data);
                            Swap(ref mas[j - 1].time, ref mas[j].time);
                            Swap(ref mas[j - 1].action, ref mas[j].action);
                            Swap(ref mas[j - 1].type, ref mas[j].type);
                        }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
            listView1.Items.Clear();
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (Convert.ToDateTime(mas[i].data) == Form4.Find)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                    lvi.SubItems.Add(Convert.ToString(mas[i].time));
                    lvi.SubItems.Add(mas[i].action);
                    switch (mas[i].type)
                    {
                        case "Задание":
                            lvi.ImageIndex = 0;
                            break;
                        case "Встреча":
                            lvi.ImageIndex = 1;
                            break;
                        case "Памятка":
                            lvi.ImageIndex = 2;
                            break;
                    }
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            Form3 form3 = new Form3();
            form3.ShowDialog();
            listView1.Items.Clear();
            mas[index] = mas[Form3.edit];
            mas[Form3.edit].data = null;
            mas[Form3.edit].time = null;
            mas[Form3.edit].action = null;
            mas[Form3.edit].type = null;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].data != null)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                    lvi.SubItems.Add(Convert.ToString(mas[i].time));
                    lvi.SubItems.Add(mas[i].action);
                    switch (mas[i].type)
                    {
                        case "Задание":
                            lvi.ImageIndex = 0;
                            break;
                        case "Встреча":
                            lvi.ImageIndex = 1;
                            break;
                        case "Памятка":
                            lvi.ImageIndex = 2;
                            break;
                    }
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
            if (Form5.pass == true)
            {
                int index = listView1.FocusedItem.Index;
                listView1.Items.Clear();
                for (int i = index; i < count; i++)
                {
                    mas[i] = mas[i + 1];
                }
                count--;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i].data != null)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(mas[i].data));
                        lvi.SubItems.Add(Convert.ToString(mas[i].time));
                        lvi.SubItems.Add(mas[i].action);
                        switch (mas[i].type)
                        {
                            case "Задание":
                                lvi.ImageIndex = 0;
                                break;
                            case "Встреча":
                                lvi.ImageIndex = 1;
                                break;
                            case "Памятка":
                                lvi.ImageIndex = 2;
                                break;
                        }
                        listView1.Items.Add(lvi);
                        count++;
                    }
                }
            }
        }
    }
}