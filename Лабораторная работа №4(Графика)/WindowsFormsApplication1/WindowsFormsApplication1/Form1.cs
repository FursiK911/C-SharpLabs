using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] t = { 10, 15, 12, 18, 2, -2, -10, -2, 0, 8, 12, 14, 17,
            11, 4, -2, 3, -6, -9, 0, 1, 7, 0, 8, 17, 18, 16, 10, 6, 5, 0 };
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            Font fn = new Font("Arial", 10);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Рисуем ось X
            // начальная точка первой линии
            int x1 = 0; int y1 = pictureBox1.Size.Height / 2;
            // конечная точка первой линии
            int x2 = pictureBox1.Size.Width;
            int y2 = pictureBox1.Size.Height / 2;
            g.DrawLine(p, x1, y1, x2, y2);
            // Рисуем ось Y
            // начальная точка первой линии
            x1 = 0; y1 = 0;
            // конечная точка первой линии
            x2 = 0; y2 = pictureBox1.Size.Height;
            g.DrawLine(p, x1, y1, x2, y2);
            // Находим максимум в массиве темепратур
            int max = -1;
            for (int i = 0; i < t.Length; i++) { if (t[i] > max) max = t[i]; }
            // Находим количество экранных точек в единице длины по оси Y
            int dy = pictureBox1.Size.Height / (2 * max);
            // Находим количество экранных точек в единице длины по оси X
            int dx = pictureBox1.Size.Width / 31;
            // ************** Ставим метки по оси Y вверх **************
            int y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
                y = y - dy;
            }
            // ************** Ставим метки по оси Y вниз ****************
            y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
                y = y + dy;
            }
            // *************** Ставим метки по оси X ********************
            int x = dx;
            for (int i = 1; i <= 31; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, x,
                pictureBox1.Size.Height / 2 - 22, sf);
                g.DrawLine(p, x, pictureBox1.Size.Height / 2 - 5, x,
                pictureBox1.Size.Height / 2 + 5);
                x = x + dx;
            }
            p.Dispose();
            // *************** Выводим график температур ***************
            // Задаем цвет и толщину пера для вывода графика температур
            //p = new Pen(Color.Green, 5);
            // Задаем стиль линии "точечная"
            //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // Задаем начальную координату x
            x = dx;
            // Отмечаем кружком значение температуры в первый день
            g.DrawEllipse(Pens.Red, x - 3, pictureBox1.Size.Height / 2 - t[0] * dy - 3, 6, 6);
            // Организуем цикл по элементам массива температур
            int j = 0;
            for (int i = 1; i <= t.Length - 1; i++)
            {
                if(t[j]>=0)
                {
                    p = new Pen(Color.Green, 20);
                    p.CompoundArray = new float[] { 0.0f, 0.2f, 0.3f, 0.6f, 0.7f, 1.0f };
                    p.StartCap =p.EndCap=System.Drawing.Drawing2D.LineCap.Round;               }
                if (t[j] >= 15)
                {
                    p = new Pen(Color.Green, 15);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                }

                if (t[j] <= 0)
                {
                    p = new Pen(Color.Green, 10);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                }
                if (t[j] <= -5)
                {
                    p = new Pen(Color.Green, 15);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                }
                // Проводим линию из одного значения температуры в другое
                g.DrawLine(p, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                // Отмечаем кружком значение температуры
                g.DrawEllipse(Pens.Red, x + dx - 3, pictureBox1.Size.Height / 2 - t[i] * dy - 3, 6, 6);
                // Переходим к следующему дню месяца
                x = x + dx;
                j++;
            }
            p.Dispose();
        }
    }
}
