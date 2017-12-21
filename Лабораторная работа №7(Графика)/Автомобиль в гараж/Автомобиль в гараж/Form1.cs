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
        Image iCar, background;
        int xCar = 400, yCar = 250,yGates = 230;
        Timer timer;
        bool waiting = false, openGates = false;
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        System.Media.SoundPlayer snd = new System.Media.SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            snd.SoundLocation = "opengates.wav";
            snd.Load();
            iCar = Image.FromFile("car1.png");
            background = Image.FromFile("background.jpg");
            timer = new Timer();
            timer.Interval = 1;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            myBuffer.Graphics.DrawImage(background, 0, 0);
            myBuffer.Graphics.DrawImage(iCar, xCar, yCar);
            myBuffer.Graphics.FillRectangle(new SolidBrush(Color.DarkGray),30,230,270,120);
            myBuffer.Graphics.FillRectangle(new SolidBrush(Color.Black), 300, yGates, 20, 120);
            myBuffer.Render();
            myBuffer.Render(pictureBox1.CreateGraphics());
            myBuffer.Dispose();

            if (waiting == false && xCar > 50)
            {
                xCar--;
            }
            if (xCar == 310)
            {
                waiting = true;
                openGates = true;
            }
            if (openGates == true && yGates > 130)
            {
                yGates--;
                if (yGates == 130)
                {
                    waiting = false;
                    openGates = false;
                    snd.PlayLooping();
                    snd.Dispose();
                }
            }
            if (xCar <= 60 && yGates <= 230)
                yGates++;
        }

    }
}
