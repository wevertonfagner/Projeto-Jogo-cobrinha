using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp3
{
    class Jogo
    {
        public Keys Direction { get; set; }
        public Keys Arrow { get; set; }
        private Timer timer1 { get; set; }
        private Label Lbpontuacao { get; set; }
        private Panel PnTela { get; set; }

        private int pontos = 0;

        private Comida comida;

        private Cobrinha Cobrinha;

        private Bitmap offScreenBitmap;

        private Graphics bitmapGraph;

        private Graphics screenGraph;

        public Jogo(ref Timer timer, ref Label label, ref Panel panel)
        {
            PnTela = panel;
            timer1 = timer;
            Lbpontuacao = label;
            offScreenBitmap = new Bitmap(428, 428);
            Cobrinha = new Cobrinha();
            comida = new Comida();
            Direction = Keys.Left;
            Arrow = Direction;
        }

        public void StartGame()
        {
            Cobrinha.Reset();
            comida.CreatFood();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            timer1.Enabled = true;
        }

        public void Tick()
        {
            if (((Arrow == Keys.Left) && (Direction != Keys.Right)) ||
              ((Arrow == Keys.Right) && (Direction != Keys.Left)) ||
              ((Arrow == Keys.Up) && (Direction != Keys.Down)) ||
              ((Arrow == Keys.Down) && (Direction != Keys.Up)))
            {
                Direction = Arrow;
            }

            switch (Direction)
            {
                case Keys.Left:
                    Cobrinha.Left();
                    break;
                case Keys.Right:
                    Cobrinha.Right();
                    break;
                case Keys.Up:
                    Cobrinha.Up();
                    break;
                case Keys.Down:
                    Cobrinha.Down();
                    break;
            }

            bitmapGraph.Clear(Color.White);

            bitmapGraph.DrawImage(Jogo_da_cobrinha_2.Properties.Resources.seriguela,(comida.location.X * 15), (comida.location.Y * 15), 15, 15);
            bool gameOver = false;

            for (int i = 0; i < Cobrinha.Length; i++)
            {
                if (i == 0)
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#000000")), (Cobrinha.location[i].X * 15), (Cobrinha.location[i].Y * 15), 15, 15);
                }
                else
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4F4F4F")), (Cobrinha.location[i].X * 15), (Cobrinha.location[i].Y * 15), 15, 15);
                }

                if ((Cobrinha.location[i] == Cobrinha.location[0]) && (i > 0))
                {
                    gameOver = true;

                }

            }
            screenGraph.DrawImage(offScreenBitmap, 0, 0);
            CheckCollision();
            if (gameOver)
            {
                GamerOver();

            }
        }
        public void CheckCollision()
        {
            if (Cobrinha.location[0] == comida.location)
            {
                Cobrinha.Eat();
                comida.CreatFood();
                pontos += 9;
                Lbpontuacao.Text = "PONTOS: " + pontos;
            }

        }
        public void GamerOver()
        {
            timer1.Enabled = false;
            bitmapGraph.Dispose();
            screenGraph.Dispose();
            Lbpontuacao.Text = "PONTOS: 0";
            pontos = 0;
            MessageBox.Show("Você perdeu!");

        }
    }
}
