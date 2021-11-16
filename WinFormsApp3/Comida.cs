using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinFormsApp3
{
    class Comida
    {
        public Point location { get; private set; }

        public void CreatFood()
        {
            Random rnd = new Random();
            location = new Point(rnd.Next(0, 27), rnd.Next(0, 27));
        }
    }
}
