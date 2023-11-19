using JogoDaForca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaForca
{
    public partial class Forms_Inicio : Form
    {
        private Form1 jogo;
        public Forms_Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jogo = new Form1(1);
            this.Hide();
            jogo.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jogo = new Form1(2);
            this.Hide();
            jogo.ShowDialog();
            this.Show();
        }
    }
}
