using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CardsForm
{
    public partial class Form1 : Form
    {

        Bitmap wallpaper;
        Bitmap cardsTable;
        int num;
        int coloda;
        Image[] pack;
        public Point cur;
        public Point PlaceForCard;
        bool press;

        public Form1()
        {
            InitializeComponent();
            coloda = 1;
            pack = new Image[54];
            for (int i = 0; i < 54; i++)
                pack[i] = imageList1.Images[i];
            //Заполнение стола градиентом
            wallpaper = new Bitmap(pictureBox2.Image, ClientRectangle.Width, ClientRectangle.Height);
            Graphics dc = Graphics.FromImage(wallpaper);
            dc.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.White, Color.Black), ClientRectangle);
            BackgroundImage = wallpaper;
            cardsTable = wallpaper;
            //dc.Dispose();
            //Рандомная сортировка массива с картами
            Random rand = new Random();
            pack = pack.OrderBy(s => rand.Next()).ToArray();

            num = 0;


        }

        public void rotate(string side)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap temp = new Bitmap(pictureBox2.Image);
                pictureBox2.Image.Dispose();
                switch (side)
                {
                    case "left":
                        temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case "right":
                        temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
                pictureBox2.Image = temp;
                temp = null;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (coloda == 1)
            {
                if (num == 53)
                    pictureBox1.Visible = false;
                cur = Cursor.Position;
                press = true;
            }
            else if (coloda == 2)
            {
                if (num == 35)
                    pictureBox1.Visible = false;
                cur = Cursor.Position;
                press = true;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (press == true)
                pictureBox2.Location = new Point(Cursor.Position.X - cur.X, Cursor.Position.Y - cur.Y );
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            press = false;
            PlaceForCard = pictureBox2.Location;
            pictureBox2.Location = new Point(12, 27);
            Graphics dc = Graphics.FromImage(pack[num]);
            dc.RotateTransform(45);
            dc.DrawImage(pack[num] , 0 , 0);

            Graphics g = Graphics.FromImage(cardsTable);
            g.DrawImage(pack[num], PlaceForCard);

            BackgroundImage = cardsTable;
            if (coloda == 1)
            {
                if (num == 53)
                {
                    pictureBox2.Visible = false;

                    MessageBox.Show("Нажмите F2");
                }
                else
                {
                    num++;

                }
            }
            else if (coloda == 2)
            {
                if (num == 35)
                {
                    pictureBox2.Visible = false;

                    MessageBox.Show("Нажмите F2");
                }
                else
                {
                    num++;

                }
            }
        }

 
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F2)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                wallpaper = new Bitmap(pictureBox1.Image,ClientRectangle.Width,ClientRectangle.Height);
                Graphics dc = Graphics.FromImage(wallpaper);
                dc.FillRectangle(new LinearGradientBrush(new Point(0,0),new Point(ClientRectangle.Width, ClientRectangle.Height),Color.White, Color.Black), ClientRectangle);
                BackgroundImage = wallpaper;
                cardsTable = wallpaper;
                //dc.Dispose();

                Random rand = new Random();
                pack = pack.OrderBy(s => rand.Next()).ToArray();

                num = 0;


            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            wallpaper = new Bitmap(pictureBox1.Image,ClientRectangle.Width,ClientRectangle.Height);
            Graphics dc = Graphics.FromImage(wallpaper);
            dc.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.White, Color.Black), ClientRectangle);
            BackgroundImage = wallpaper;
            cardsTable = wallpaper;
            //dc.Dispose();

            Random rand = new Random();
            pack = pack.OrderBy(s => rand.Next()).ToArray();

            num = 0;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это же обычные карты, дурень:)");
        }

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "36 карт";
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            wallpaper = new Bitmap(pictureBox1.Image,ClientRectangle.Width,ClientRectangle.Height);
            Graphics dc = Graphics.FromImage(wallpaper);
            dc.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.White, Color.Black), ClientRectangle);
            BackgroundImage = wallpaper;
            cardsTable = wallpaper;
            dc.Dispose();
            pack = new Image[36];
            for (int i = 0; i < 36; i++)
                pack[i] = imageList2.Images[i];
            Random rand = new Random();
            pack = pack.OrderBy(s => rand.Next()).ToArray();

            num = 0;
            coloda = 2;
            
        }

        private void cardsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label2.Text = "54 карты";
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            wallpaper = new Bitmap(pictureBox1.Image, ClientRectangle.Width,ClientRectangle.Height);
            Graphics dc = Graphics.FromImage(wallpaper);
            dc.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.White, Color.Black), ClientRectangle);
            BackgroundImage = wallpaper;
            cardsTable = wallpaper;
            dc.Dispose();
            pack = new Image[54];
            for (int i = 0; i < 54; i++)
                pack[i] = imageList1.Images[i];
            Random rand = new Random();
            pack = pack.OrderBy(s => rand.Next()).ToArray();

            num = 0;
            coloda = 1;
            
        }
    }
}
