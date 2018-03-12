using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Рекурсивный_алгоритм_отсечения_линий
{
    public partial class Form1 : Form
    {
        Graphics dc; Pen p;
        int x0, y0, x, y;
        float Xmin, Xmax, Ymin, Ymax;

        public Form1()
        {
            InitializeComponent();
            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Black, 2);
            textBox1.Text = "30";
            textBox2.Text = "80";
            textBox4.Text = "100";
            textBox3.Text = "100";
            textBox5.Text = "10";
            textBox7.Text = "100";
            textBox6.Text = "10";
            textBox8.Text = "100";
        }

        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        /* Своя функция вычечивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point((int)x1, (int)y1);
            Point point2 = new Point((int)x2, (int)y2);
            dc.DrawLine(p, point1, point2);
        }

        /* Метод получение кода положения точки относительно окна по алгоритму Коєна-Сазерленда */
        private uint code(double x, double y)
        {
            return (uint)((Convert.ToUInt16(x < Xmin) << 3) |
            (Convert.ToUInt16(x > Xmax) << 2) |
            (Convert.ToUInt16(y < Ymin) << 1) |
            Convert.ToUInt16(y > Ymax));
        }
        /* Метод отсечения линий */
        private void clip(double x1, double y1, double x2, double y2)
        {
            uint c1;
            uint c2;
            double dx, dy;
            c1 = code(x1, y1);
            c2 = code(x2, y2);

            while ((c1 | c2) != 0)
            {
                if ((c1 & c2) != 0) return;
                dx = x2 - x1;
                dy = y2 - y1;
                if (c1 != 0)
                {
                    if (x1 < Xmin) { y1 += dy * (Xmin - x1) / dx; x1 = Xmin; }
                    else
                    if (x1 > Xmax) { y1 += dy * (Xmax - x1) / dx; x1 = Xmax; }
                    else
                    if (y1 < Ymin) { x1 += dx * (Ymin - y1) / dy; y1 = Ymin; }
                    else
                    if (y1 > Ymax) { x1 += dx * (Ymax - y1) / dy; y1 = Ymax; }
                    c1 = code(x1, y1);
                }
                else
                {
                    if (x2 < Xmin) { y2 += dy * (Xmin - x2) / dx; x2 = Xmin; }
                    else
                    if (x2 > Xmax) { y2 += dy * (Xmax - x2) / dx; x2 = Xmax; }
                    else
                    if (y2 < Ymin) { x2 += dx * (Ymin - y2) / dy; y2 = Ymin; }
                    else
                    if (y2 > Ymax) { x2 += dx * (Ymax - y2) / dy; y2 = Ymax; }
                    c2 = code(x2, y2);
                }
            }
            Draw(x1, y1, x2, y2); // Соединяем точки линией
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dc.Clear(Color.White);
            pictureBox1.InitialImage = null;
            x0 = int.Parse(textBox1.Text);
            y0 = int.Parse(textBox2.Text);
            x = int.Parse(textBox4.Text);
            y = int.Parse(textBox3.Text);
            Xmin = float.Parse(textBox5.Text);
            Xmax = float.Parse(textBox7.Text);
            Ymin = float.Parse(textBox6.Text);
            Ymax = float.Parse(textBox8.Text);

            Draw(Xmin, Ymin, Xmax, Ymin); Draw(Xmax, Ymin, Xmax, Ymax);
            Draw(Xmax, Ymax, Xmin, Ymax); Draw(Xmin, Ymax, Xmin, Ymin);

            //dc.FillRectangle(Brushes.Red, Xmin, Ymin, Xmax, Ymax);

            clip(x0,y0,x,y);
        }
    }
}
