﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
namespace Laba_3
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {
    "First line", "Second line", "Third line",
    "Fourth line", "Fifth line", "Sixth line",
    "Seventh line", "Eighth line", "Ninth line",
    "Tenth line", "Eleven line", "Twelve line",
    "Thirteenth line", "Fourteenth line",
    "Fifteenth line"};

        public Form1()
        {
            InitializeComponent();
            // Предоставляем объекту "g" класса Graphics возможность
            // рисования на pictureBox1:
            g = pictureBox1.CreateGraphics();
        }

        // **************** Запись в файл ********************

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));

            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("15 строк записано в файл!\nEZ!");
        }
        // *************** Очистка файла и PictureBox **********
        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }

        // *************** Отображение строк текста *************
        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            // Чтение строк из файла
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 15; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            // **** Отображение строк разными шрифтами и выравниванием **
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 15; i++)
            {
                // Отображение первой группы строк
                if ((i >= 0) && (i < 10))
                {
                    Font fn = new Font("Broadway", 24, FontStyle.Regular);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Blue,
                    new RectangleF(0, 0 + i * 30, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                // Отображение второй группы строк
                if ((i >= 10) && (i < 13))
                {
                    k = i - 10;
                    Font fn = new Font("Arial", 36, FontStyle.Underline);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0 + k * 50, 0, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                // Отображение третьей группы строк
                if (i == 14)
                {
                    Font fn = new Font("Times New Roman", 72, FontStyle.Strikeout);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;

                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green,
                    new RectangleF(0, 0 + i * 24, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }

            }


        }
    }
}