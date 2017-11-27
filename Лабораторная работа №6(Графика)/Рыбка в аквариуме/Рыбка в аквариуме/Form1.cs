using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Рыбка_в_аквариуме
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Show();
        }
     
        public void PrintBackground()
        {
            Pen aquarium = new Pen(Color.Aqua, 3);
            SolidBrush water = new SolidBrush(Color.Blue);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawArc(aquarium, 100, 50, 600, 400,-45,270);
            g.FillPie(water, 100, -50, 600, 550, 0, 180);
        }
        public void PrintFish()
        {
            Graphics g = pictureBox1.CreateGraphics();
            //SolidBrush body = new SolidBrush(Color.Yellow);
            //SolidBrush fins = new SolidBrush(Color.Orange);
            Image img = Image.FromFile("body2.bmp");
            TextureBrush body = new TextureBrush(img);

            int xFins = 405;
            int yFins = 325;
            g.FillEllipse(body, 400, 300, 100, 50);
            Image img2 = Image.FromFile("fist1.bmp");
            TextureBrush fins1 = new TextureBrush(img2);
            g.FillPolygon(fins1, new PointF[] { new PointF(xFins, yFins),
                new PointF(xFins - 80, yFins - 50), new PointF(xFins - 40, yFins),
                new PointF(xFins - 80, yFins + 50)});
            xFins = 465;
            yFins = 303;

            Image img3 = Image.FromFile("fist2.bmp");
            TextureBrush fins2 = new TextureBrush(img3);
            g.FillPolygon(fins2, new PointF[] { new PointF(xFins, yFins),
                new PointF(xFins - 30, yFins - 20), new PointF(xFins - 30, yFins),});
            xFins = 475;
            yFins = 340;
            Image img4 = Image.FromFile("fist3.bmp");
            TextureBrush fins3 = new TextureBrush(img4);
            g.FillPolygon(fins3, new PointF[] { new PointF(xFins, yFins),
                new PointF(xFins - 30, yFins + 20), new PointF(xFins - 60, yFins + 20),
                new PointF(xFins - 30, yFins)});
            Image img5 = Image.FromFile("eye.bmp");
            TextureBrush fins4 = new TextureBrush(img5);
            g.FillEllipse(fins4, 470, 314, 19, 19);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrintBackground();
            PrintFish();
        }
    }
}
