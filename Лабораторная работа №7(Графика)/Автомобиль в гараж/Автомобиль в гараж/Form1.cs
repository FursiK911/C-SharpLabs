using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Автомобиль_в_гараж
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void CreateGarage()
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush garage = new SolidBrush(Color.Gray);
            SolidBrush gates = new SolidBrush(Color.Black);
            g.FillRectangle(garage, 10, pictureBox1.Height/2 + 30 , 250, 150);
            g.FillRectangle(gates, 252, pictureBox1.Height / 2 + 30, 15, 150);
        }

        public void CreateCar()
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush car = new SolidBrush(Color.DarkBlue);
            SolidBrush wheel = new SolidBrush(Color.Black);
            SolidBrush windows = new SolidBrush(Color.Aqua);
            Image img = Image.FromFile("car1.bmp");
            TextureBrush car1 = new TextureBrush(img);

            int xStartCar = pictureBox1.Width/2;
            int yStartCar = pictureBox1.Height/2;
            g.FillPolygon(car1, new PointF[] { new PointF ( xStartCar, yStartCar ), new PointF (xStartCar + 20,yStartCar), new PointF(xStartCar+40, yStartCar-30),
                new PointF(xStartCar+120, yStartCar-30), new PointF(xStartCar+120, yStartCar+30),new PointF ( xStartCar, yStartCar+30 ), });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CreateGarage();
            CreateCar();
        }
    }
}
