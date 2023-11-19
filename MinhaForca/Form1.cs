using MinhaForca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JogoDaForca
{
    public partial class Form1 : Form
    {
        Class_Forca forca;
        DialogResult restart;
        private int tipoJogo;
        public Form1(int num)
        {
            tipoJogo = num;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            forca = new Class_Forca(tipoJogo);
            label4.Hide();
            if (tipoJogo == 2)
            {
                label4.Show();
                label4.Text = $"Tema: {forca.getDica()}";
            }

            label1.Text = forca.hiddenWord();
            textBox1.Text = "";
            textBox1.Focus();
            label2.Text = $"Tentativa: {forca.getTry()}";
            label3.Hide();
            label3.Text = "";

            pictureBox1.Show();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text;
            if (texto != "")
            {
                char letra = textBox1.Text[0];

                if (char.IsLetter(letra))
                {
                    bool tentativaValida = forca.canTry();

                    if (tentativaValida)
                    {
                        bool letraValida = forca.checkWord(letra);

                        if (letraValida)
                        {
                            MessageBox.Show("Letra encontrada na palavra!", "Boa tentativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            label1.Text = forca.showWord();

                            string palavra = forca.wordComplete();

                            if (palavra != "incomplete")
                            {
                                restart = MessageBox.Show($"Parabéns! Você completou a palavra: {palavra}.\nDeseja recomeçar?", "Sucesso", MessageBoxButtons.YesNo);
                                if (restart == DialogResult.Yes)
                                {
                                    forca = new Class_Forca(tipoJogo);
                                    pictureBox7.Hide();
                                    pictureBox1.Show();
                                    label1.Text = forca.hiddenWord();
                                    textBox1.Enabled = true;
                                    textBox1.Text = "";
                                    textBox1.Focus();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Letra não encontrada na palavra!", "Que pena", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                            label3.Show();
                            label3.Text = forca.tryChars();
                            
                            switch (forca.getTry())
                            {
                                
                                case 5:
                                    label2.BackColor = Color.LightGreen;
                                    pictureBox1.Hide();
                                    pictureBox2.Show();
                                    break;
                                case 4:
                                    label2.BackColor = Color.GreenYellow;
                                    pictureBox2.Hide();
                                    pictureBox3.Show();
                                    break;
                                case 3:
                                    label2.BackColor = Color.Yellow;
                                    pictureBox3.Hide();
                                    pictureBox4.Show();
                                    break;
                                case 2:
                                    label2.BackColor = Color.Orange;
                                    pictureBox4.Hide();
                                    pictureBox5.Show();                                    
                                    break;
                                case 1:
                                    label2.BackColor = Color.OrangeRed;
                                    pictureBox5.Hide();
                                    pictureBox6.Show();
                                    break;
                                case 0:
                                    label2.BackColor = Color.Red;
                                    pictureBox6.Hide();
                                    pictureBox7.Show();
                                    break;
                                
                            }
                        }
                        label2.Text = $"Tentativas restantes: {forca.getTry()}";
                        
                    }
                    else
                    {
                        restart = MessageBox.Show("Suas tentativas acabaram. Deseja recomeçar?", "Fim de jogo", MessageBoxButtons.YesNo);
                        textBox1.Enabled = false;

                        if (restart == DialogResult.Yes)
                        {
                            forca = new Class_Forca(tipoJogo);
                            pictureBox7.Hide();
                            pictureBox1.Show();
                            label1.Text = forca.hiddenWord();
                            textBox1.Enabled = true;
                            textBox1.Text = "";
                            textBox1.Focus();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não existem palavras com esse caracter. Por favor digite apenas letras, uma letra por tentativa!", "Tentativa inválida");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            restart = MessageBox.Show("Tem certeza que deseja desistir?", "Fim de jogo", MessageBoxButtons.YesNo);

            if (restart == DialogResult.Yes)
            {
                forca = new Class_Forca(tipoJogo);
                pictureBox7.Hide();
                pictureBox1.Show();
                label1.Text = forca.hiddenWord();
                textBox1.Enabled = true;
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                //goto menu
            }
        }
    }
}
