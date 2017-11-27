using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ICapture myCapture;
        public Form1()
        {
            myCapture = new Emgu.CV.VideoCapture();
            InitializeComponent();
        }


        private void GetVideo(object sender, EventArgs e)
        {
            //Берем кадр
            var Kadr = myCapture.QueryFrame();

            //Вставляем в imageBox
            imageBox1.Image = myCapture.QueryFrame();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            //Делаем это безпрерывно
            Application.Idle += GetVideo;
        }

    }
}
