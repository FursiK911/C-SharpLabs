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
    public partial class Form5 : Form
    {
        public static bool pass;
        public Form5()
        {
            InitializeComponent();
            label1.Text = "Вы уверены что хотите удалить запись " + Form2.mas[Form2.index].data + " " + Form2.mas[Form2.index].action + "?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pass = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pass = false;
            this.Close();
        }
    }
}
