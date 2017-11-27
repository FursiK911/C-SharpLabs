using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public static int edit;
        public DateTime time_Select;
        public Form3()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            string[] time_Now = this.dateTimePicker1.Text.Split(':');
        }
        public void button1_Click(object sender, EventArgs e)
        {
            time_Select = this.dateTimePicker1.Value;
            DateTime selected_date = monthCalendar1.SelectionStart.Date;
            DateTime test = (selected_date.Date + time_Select.TimeOfDay);
            if (test < DateTime.Now)
            {
                MessageBox.Show("Выбрана не корректная дата или время");
            }
            else
            {
                for (int i = 0; i < Form2.mas.Length; i++)
                {
                    if (Form2.mas[i].data == null)
                    {
                        Form2.mas[i].action = this.textBox1.Text;
                        Form2.mas[i].time = this.dateTimePicker1.Text;
                        Form2.mas[i].data = Convert.ToString(selected_date.Day + "." + selected_date.Month + "." + selected_date.Year);
                        Form2.mas[i].type = this.comboBox1.Text;
                        edit = i;
                        break;
                    }
                }
                this.Close();
            }

        }
    }
}
