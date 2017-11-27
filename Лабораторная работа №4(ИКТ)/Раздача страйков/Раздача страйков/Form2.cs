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
    public partial class Form2 : Form
    {
        public Font font1;
        public Brush brush1;
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = Form1.copyright.text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            font1 = font.Font;
            textBox1.Font = font1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.copyright.text = textBox1.Text;
            Form1.copyright.font = font1;
            Form1.copyright.brush = brush1;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            brush1 = new SolidBrush(cd.Color);
            textBox1.ForeColor = cd.Color;
        }
    }
}
