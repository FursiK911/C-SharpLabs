using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_prog1
{
    class Vector2d
    {
        public double x { private set; get; }
        public double y { private set; get; }

        public Vector2d(double i_x, double i_y, int i_height = 1, int i_width = 1)
        {
            x = Convert.ToInt32(i_x * (i_width / 10.0));
            y = Convert.ToInt32(i_height - i_y * (i_height / 7.0));
        }
    }
}
