using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поворот_эллипсов
{
    public partial class Form1 : Form
    {
        Graphics g; Pen p;
        int R = 3, N = 40;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Red, 1);
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
        /* Своя функция вычерчивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1)
        {
            RectangleF point1 = new RectangleF(IX(x1), IY(y1), 50, 50);
            g.DrawEllipse(p, point1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[] x; x = new double[40];
            double[] y; y = new double[40];
            int i, j;
            double Pi, Phi, cos_Phi, sin_Phi, dx, dy, angle = 6;
            double x0 = 5.0, y0 = 3.5, xold = 0.0, yold = 0.0;
            Pi = 4.0 * Math.Atan(1.0);
            Phi = angle * Pi / 180;
            cos_Phi = Math.Cos(Phi);
            sin_Phi = Math.Sin(Phi);


            //смещение относительно центра вращения
            //for (j = 0; j < 4; j++) { x[j] += x0; y[j] += y0; }
            //цикл прорисовки прямоугольников
            for (i = 0; i < N; i++)
            {
                cos_Phi = Math.Cos(Phi);
                sin_Phi = Math.Sin(Phi);
                x[i] = x0 + (i * R / N) * cos_Phi;
                y[i] = y0 + ((N - i) * R / N) * sin_Phi;
                Draw(x[i], y[i]);
                angle += 6;
                Phi = angle * Pi / 180;
            }
            // ******************************************** Подпись ***************
            Brush blueBrush = Brushes.Blue;
            Font boldTimesFont = new Font("Times New Roman", 12, FontStyle.Bold |

            FontStyle.Underline);

            string str = "Лабораторная работа No9";
            SizeF sizefText = g.MeasureString(str, boldTimesFont);
            g.DrawString(str, boldTimesFont, blueBrush,
            (pictureBox1.Size.Width - sizefText.Width) / 2,
            (pictureBox1.Size.Height - sizefText.Height) / 2);

        }
    }
}
