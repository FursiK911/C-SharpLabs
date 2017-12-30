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
        public Image explosion;
        public int xCastle;
        public int yCastle;
        public bool destroy;
        public bool currentlyAnimating;
        public int xExplosion;
        public int yExplosion;
        public short tick;
    }
    public partial class Form1 : Form
    {
        Image background, plane, zoom, cloud;
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        Timer timer;
        Random r = new Random();
        Graphics g;
        int xPlain = 240, yPlain = 420, xBack = 500, yBack = 2500, xZoom = 290, yZoom = 300, xCloud, yCloud, score = 0;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            plane = Image.FromFile("plane.png");
        }

        EnemyObject[] enemy = new EnemyObject[4];
        System.Media.SoundPlayer fly = new System.Media.SoundPlayer();
        System.Windows.Media.MediaPlayer boom = new System.Windows.Media.MediaPlayer();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && xPlain > 0)
            {
                plane = Image.FromFile("planeLeft.png");
                xPlain -= 3;
            }
            if (e.KeyCode == Keys.D && xPlain < 455)
            {
                plane = Image.FromFile("planeRight.png");
                xPlain += 3;
            }
            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (xZoom + 33 >= enemy[i].xCastle - 30 &&
                        xZoom + 33 <= enemy[i].xCastle + 130 && yZoom + 33 >= enemy[i].yCastle - 100 &&
                        yZoom + 33 <= enemy[i].yCastle + 65)
                    {
                        AnimateImage(i);
                        enemy[i].currentlyAnimating = true;
                        enemy[i].destroy = true;
                        score += i + 1;
                        boom.Open(new Uri("boom.wav", System.UriKind.Relative));
                        boom.Play();
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            fly.SoundLocation = "fly.wav";
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
                enemy[i].tick = 0;
                enemy[i].currentlyAnimating = false;
                enemy[i].explosion = Image.FromFile("explosion.gif");
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
            fly.PlayLooping();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(pictureBox1.CreateGraphics(), this.DisplayRectangle);
            myBuffer.Graphics.DrawImage(background, 0, 0, new Rectangle(xBack, yBack, 650, 558), GraphicsUnit.Pixel);
            CreateAndMoveEnemy();
            myBuffer.Graphics.DrawImage(zoom, xZoom, yZoom);
            myBuffer.Graphics.DrawImage(plane, xPlain, yPlain);
            myBuffer.Graphics.DrawString("A-left\nD-right\nSpace-fire", new Font("Times New Roman", 30), Brushes.Black, 10, 10);
            myBuffer.Graphics.DrawString("Score: " + score, new Font("Times New Roman", 30), Brushes.Black, 450, 20);
            SpawnCloud();
            myBuffer.Graphics.DrawImage(cloud, xCloud, yCloud);
            xZoom = xPlain + 50;
            myBuffer.Render(pictureBox1.CreateGraphics());
            myBuffer.Dispose();


            if (yBack < 500)
                yBack = 2500;
            yBack--;
            yCloud++;

            if (GameOver())
            {
                fly.Stop();
                timer.Enabled = false;
                MessageBox.Show("Вы проиграли! Ваш счет: " + score);
                this.Close();
            }

        }
        bool FreePlace(int x, int y)
        {
            bool free = true;
            for (int i = 0; i < enemy.Length; i++)
            {
                if (x >= enemy[i].xCastle - 100 &&
                        x <= enemy[i].xCastle + 180 && y >= enemy[i].yCastle - 130 &&
                        y <= enemy[i].yCastle + 220)
                    free = false;

            }
            return free;
        }
        void CreateAndMoveEnemy()
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                Frames(i);
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

                if (enemy[i].yExplosion > 650)
                    enemy[i].currentlyAnimating = false;
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

        void SpawnCloud()
        {
            if (yCloud >= 600)
            {
                xCloud = r.Next(50, 400);
                yCloud = r.Next(-400, -100);
            }
        }

        bool GameOver()
        {
            if (xPlain + 30 >= xCloud - 20 && xPlain + 30 <= xCloud + 80 && yPlain >= yCloud - 20 && yPlain <= yCloud + 20)
            {
                return true;
            }
            return false;
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate();
        }

        public void AnimateImage(int j)
        {
            if (enemy[j].currentlyAnimating == false)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(enemy[j].explosion, new EventHandler(this.OnFrameChanged));
                enemy[j].currentlyAnimating = true;
                enemy[j].xExplosion = enemy[j].xCastle + 33;
                enemy[j].yExplosion = enemy[j].yCastle - 33;
            }
        }

        void Frames(int j)
        {
            if (enemy[j].currentlyAnimating)
            {
                enemy[j].tick++;
                if (enemy[j].tick == 93)
                {
                    enemy[j].tick = 0;
                    ImageAnimator.StopAnimate(enemy[j].explosion, new EventHandler(this.OnFrameChanged));
                    enemy[j].currentlyAnimating = false;
                }
                ImageAnimator.UpdateFrames();
                myBuffer.Graphics.DrawImage(enemy[j].explosion, new Point(enemy[j].xExplosion, enemy[j].yExplosion));
                enemy[j].yExplosion++;
            }
        }

    }
}
