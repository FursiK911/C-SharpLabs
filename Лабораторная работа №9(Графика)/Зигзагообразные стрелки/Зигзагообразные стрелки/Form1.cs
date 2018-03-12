using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Зигзагообразные_стрелки
{
    public partial class Form1 : Form
    {
        Graphics dc; Pen p;
        public Form1()
        {
            InitializeComponent();
            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Red, 10);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool isLeft = false;
            int lenght = 80, sizePen = 10; ;
            double x = pictureBox1.Width / 2, y = 50, x0 = pictureBox1.Width / 2, y0 = 0;
            Point oldPos = new Point((int)x0, (int)y0), newPos = new Point((int)x, (int)y);
            double Pi, Phi, cos_Phi, sin_Phi;
            for (int i = 0;; i++)
            {
                if(isLeft)
                {
                    Pi = 4.0 * Math.Atan(1.0);
                    Phi = 30 * Pi / 180;
                    cos_Phi = Math.Cos(Phi);
                    sin_Phi = Math.Sin(Phi);
                    isLeft = false;
                }
                else
                {
                    Pi = 4.0 * Math.Atan(1.0);
                    Phi = -30 * Pi / 180;
                    cos_Phi = Math.Cos(Phi);
                    sin_Phi = Math.Sin(Phi);
                    isLeft = true;
                }
                oldPos = new Point((int)x, (int)y);
                x = x0 + (x - x0) * cos_Phi - (y - y0) * sin_Phi;
                y = y0 + (x - x0) * sin_Phi + (y - y0) * cos_Phi;
                x0 = x;
                y0 = y;
                y += lenght;
                lenght -= 3;
                newPos = new Point((int)x, (int)y);
                dc.DrawLine(p, oldPos, newPos);
                sizePen--;
                p = new Pen(Color.Red, sizePen);
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                if (y >= pictureBox1.Height)
                    break;
            }
        }
    }
}