﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Jogo Jogo;

        public Form1()
        {
            InitializeComponent();
            Jogo = new Jogo(ref timer1, ref LbPontuacao, ref PnTela);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inciarJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jogo.StartGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Jogo.Tick();
        }

        private void Clicado(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Jogo.Arrow = e.KeyCode;
            }
        }
    }
}
