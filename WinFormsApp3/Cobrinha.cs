using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinFormsApp3
{
    class Cobrinha
    {
        public int Length { get; private set; }
        public Point[] location { get; private set; }

        public Cobrinha()
        {
            location = new Point[28 * 28];
            Reset();
        }
        public void Reset()
        {
            Length = 5;
            for (int i = 0; i < Length; i++)
            {
                location[i].X = 12;
                location[i].Y = 12;
            }
        }
        public void Follow()
        {
            for (int i = Length - 1; i > 0; i--)
            {
                location[i] = location[i - 1];
            }
        }
        public void Up()
        {
            Follow();
            location[0].Y--;
            if (location[0].Y < 0)
            {
                location[0].Y += 28;
            }
        }
        public void Down()
        {
            Follow();
            location[0].Y++;
            if (location[0].Y > 27)
            {
                location[0].Y -= 28;
            }
        }
        public void Left()
        {
            Follow();
            location[0].X--;
            if (location[0].X < 0)
            {
                location[0].X += 28;
            }
        }
        public void Right()
        {
            Follow();
            location[0].X++;
            if (location[0].X > 27)
            {
                location[0].X -= 28;
            }
        }
        public void Eat()
        {
            Length++;
        }
    }
}
