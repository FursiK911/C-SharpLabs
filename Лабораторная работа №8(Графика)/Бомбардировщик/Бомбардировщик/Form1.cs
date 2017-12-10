using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Бомбардировщик
{
    public struct EnemyObject
    {
        public Image castle;
        public int xCastle;
        public int yCastle;
        public bool destroy;
    }
    public partial class Form1 : Form
    {
        Image background, plane, zoom, cloud;
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        Timer timer;
        Random r = new Random();
        int xPlain = 240, yPlain = 420, xBack = 500, yBack = 2500, xZoom = 290, yZoom = 300, xCloud, yCloud, score = 0;
        EnemyObject[] enemy = new EnemyObject[4];

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && xPlain > 0)
                xPlain-=3;
            if (e.KeyCode == Keys.D && xPlain < 455)
                xPlain += 3;
            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (xZoom + 33 >= enemy[i].xCastle - 30 &&
                        xZoom + 33 <= enemy[i].xCastle + 130 && yZoom + 33 >= enemy[i].yCastle - 100 &&
                        yZoom + 33 <= enemy[i].yCastle + 50)
                    {
                        enemy[i].destroy = true;
                        score += i;
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            plane = Image.FromFile("plane.png");
            zoom = Image.FromFile("zoom.png");
            background = Image.FromFile("background2.jpg");
            cloud = Image.FromFile("cloud.png");
            xCloud = r.Next(50, 400);
            yCloud = r.Next(-400, -100);
            int tmpX, tmpY;
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].castle = Image.FromFile("castle" + i + ".png");
                enemy[i].destroy = false;
                do
                {
                    tmpX = r.Next(50, 400);
                    tmpY = r.Next(-400, -100);
                } while (!FreePlace(tmpX, tmpY));
                enemy[i].xCastle = tmpX;
                enemy[i].yCastle = tmpY;
            }
            timer = new Timer();
            timer.Interval = 1;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            myBuffer.Graphics.DrawImage(background, 0, 0, new Rectangle(xBack, yBack, 650, 558), GraphicsUnit.Pixel);
            CreateAndMoveEnemy();
            myBuffer.Graphics.DrawImage(zoom, xZoom, yZoom);
            myBuffer.Graphics.DrawImage(plane, xPlain, yPlain);
            myBuffer.Graphics.DrawString("A-left\nD-right\nSpace-fire", new Font("Times New Roman", 30), Brushes.Black, 10, 10);
            myBuffer.Graphics.DrawString("Score: " + score, new Font("Times New Roman", 30), Brushes.Black, 450, 20);
            if (yCloud >= 600)
            {
                xCloud = r.Next(50, 400);
                yCloud = r.Next(-400, -100);
            }
            myBuffer.Graphics.DrawImage(cloud, xCloud, yCloud);
            xZoom = xPlain + 50;
            myBuffer.Render(pictureBox1.CreateGraphics());
            if (yBack < 500)
                yBack = 2500;
            yBack--;
            yCloud++;
            myBuffer.Dispose();
            if (xPlain + 30 >= xCloud - 20 && xPlain + 30 <= xCloud + 80 && yPlain >= yCloud - 20 && yPlain <= yCloud + 20)
            {
                timer.Enabled = false;
                MessageBox.Show("Вы проиграли! Ваш счет: " + score);
                this.Close();
                //this.Hide();
                //Form2 form2 = new Form2();
                //form2.ShowDialog();
            }

        }
        bool FreePlace(int x, int y)
        {
            bool free = true;
            for (int i = 0; i < enemy.Length; i++)
            {
                if (x >= enemy[i].xCastle - 100 &&
                        x <= enemy[i].xCastle + 180 && y >= enemy[i].yCastle - 120 &&
                        y <= enemy[i].yCastle + 200)
                    free = false;
                    
            }
            return free;
        }
        void CreateAndMoveEnemy()
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].destroy)
                {
                    enemy[i].destroy = false;
                    int tmpX, tmpY;
                    do
                    {
                        tmpX = r.Next(50, 400);
                        tmpY = r.Next(-400, -100);
                    } while (!FreePlace(tmpX, tmpY));
                    enemy[i].xCastle = tmpX;
                    enemy[i].yCastle = tmpY;
                }
                if (enemy[i].yCastle < 650 && enemy[i].destroy == false)
                {
                    myBuffer.Graphics.DrawImage(enemy[i].castle, enemy[i].xCastle, enemy[i].yCastle - 80);
                    enemy[i].yCastle++;
                }
                else
                {
                    enemy[i].destroy = true;
                }
            }
        }
    }
}
