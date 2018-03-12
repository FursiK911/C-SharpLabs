
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10_prog1
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pb_source.CreateGraphics();
        }

        void DrawCorner(Vector2d i_vector,int width, int upX, int upY)
        {
            g.DrawLine(new Pen(Color.Black, 2), 
                new Point(Convert.ToInt32(i_vector.x), Convert.ToInt32(i_vector.y)),
                new Point(Convert.ToInt32(i_vector.x + width * 1.5 * upX), Convert.ToInt32(i_vector.y)));
            g.DrawLine(new Pen(Color.Black, 2),
               new Point(Convert.ToInt32(i_vector.x), Convert.ToInt32(i_vector.y)),
               new Point(Convert.ToInt32(i_vector.x), Convert.ToInt32(i_vector.y + width * upY)));
        }

        void DrawWindow()
        {
            Vector2d xmin_ymax = new Vector2d(Convert.ToSingle(tb_xmin.Text), Convert.ToSingle(tb_ymax.Text), pb_source.Height, pb_source.Width);
            Vector2d xmax_ymin = new Vector2d(Convert.ToSingle(tb_xmax.Text), Convert.ToSingle(tb_ymin.Text), pb_source.Height, pb_source.Width);
            Vector2d xmin_ymin = new Vector2d(Convert.ToSingle(tb_xmin.Text), Convert.ToSingle(tb_ymin.Text), pb_source.Height, pb_source.Width);
            Vector2d xmax_ymax = new Vector2d(Convert.ToSingle(tb_xmax.Text), Convert.ToSingle(tb_ymax.Text), pb_source.Height, pb_source.Width);

            int line_space = 10;

            DrawCorner(xmin_ymax, line_space,1,1);
            DrawCorner(xmax_ymin, line_space,-1,-1);
            DrawCorner(xmin_ymin, line_space,1,-1);
            DrawCorner(xmax_ymax, line_space,-1,1);
        }

        private void bt_draw_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawWindow();
            DrawLine(
                Convert.ToSingle(tb_x_p.Text),
                Convert.ToSingle(tb_y_p.Text),
                Convert.ToSingle(tb_x_q.Text),
                Convert.ToSingle(tb_y_q.Text)
                );
        }

        void DrawLine(double x1, double y1, double x2, double y2)
        {
            bool flagvalidatestart = x1 >= Convert.ToSingle(tb_xmin.Text) && x1 <= Convert.ToSingle(tb_xmax.Text)
                && y1 >= Convert.ToSingle(tb_ymin.Text) && y1 <= Convert.ToSingle(tb_ymax.Text);

            bool flagvalidateend = x2 >= Convert.ToSingle(tb_xmin.Text) && x2 <= Convert.ToSingle(tb_xmax.Text)
                && y2 >= Convert.ToSingle(tb_ymin.Text) && y2 <= Convert.ToSingle(tb_ymax.Text);

            if (flagvalidatestart && flagvalidateend)
            {
                Vector2d start = new Vector2d(x1, y1, pb_source.Height, pb_source.Width);
                Vector2d end = new Vector2d(x2, y2, pb_source.Height, pb_source.Width);

                g.DrawLine(new Pen(Color.Black, 2),
                     new Point(Convert.ToInt32(start.x), Convert.ToInt32(start.y)),
                     new Point(Convert.ToInt32(end.x), Convert.ToInt32(end.y)));
            }
            else if (!flagvalidatestart && !flagvalidateend)
            {
                DrawLine(x1/2, y1/2, x2/2, y2/2);
                return;
            }
            else
            {
                if (!flagvalidatestart)
                {
                    if (x1 <= Convert.ToSingle(tb_xmin.Text))
                        x1 = Convert.ToSingle(tb_xmin.Text);
                    if (x1 >= Convert.ToSingle(tb_xmax.Text))
                        x1 = Convert.ToSingle(tb_xmax.Text);
                    if (y1 <= Convert.ToSingle(tb_ymin.Text))
                        y1 = Convert.ToSingle(tb_ymin.Text);
                    if (y1 >= Convert.ToSingle(tb_ymax.Text))
                        y1 = Convert.ToSingle(tb_ymax.Text);
                }

                if (!flagvalidateend)
                {
                    if (x2 <= Convert.ToSingle(tb_xmin.Text))
                        x2 = Convert.ToSingle(tb_xmin.Text);
                    if (x2 >= Convert.ToSingle(tb_xmax.Text))
                        x2 = Convert.ToSingle(tb_xmax.Text);
                    if (y2 <= Convert.ToSingle(tb_ymin.Text))
                        y2 = Convert.ToSingle(tb_ymin.Text);
                    if (y2 >= Convert.ToSingle(tb_ymax.Text))
                        y2 = Convert.ToSingle(tb_ymax.Text);
                }

                DrawLine(x1, y1, x2, y2);
                return;
            }


          
        }

    }
}
