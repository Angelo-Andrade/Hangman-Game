using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MinhaForca
{
    internal class Class_Forca
    {
        private string palavra = "palavra", tema = "tema";
        private char[] letras = new char[48];
        private char[] erros = new char[7];
        private int tentativas;
        private int[] acertos = new int[48];


        public Class_Forca(int tipo)
        {
            tentativas = 6;
            Class_Palavra obj;
            Class_Biblioteca biblioteca = new Class_Biblioteca();

            if (tipo == 1)
            {
                //com API
                string json = (biblioteca.getMethod()).Content;
                obj = JsonConvert.DeserializeObject<Class_Palavra>(json);

                if (obj != null)
                {
                    palavra = obj.randonWord();
                    wordLetters();
                }

                for (int letra = 0; letra < palavra.Length; letra++)
                {
                    if (letras[letra] == ' ' || letras[letra] == '-')
                    {
                        acertos[letra] = 1;
                    }
                    else
                    {
                        acertos[letra] = 0;
                    }
                }
            }
            else
            {
                tema = biblioteca.getTema();
                palavra = biblioteca.getPalavra(tema);
                wordLetters();

                for (int letra = 0; letra < palavra.Length; letra++)
                {
                    if (letras[letra] == ' ' || letras[letra] == '-')
                    {
                        acertos[letra] = 1;
                    }
                    else
                    {
                        acertos[letra] = 0;
                    }
                }

            }

        }

        public string getDica ()
        {
            return tema;
        }

        public bool checkWord(char c)
        {
            bool word = false;

            if (palavra.Contains(c))
            {
                for (int i = 0; i < palavra.Length; i++)
                {
                    char letra = palavra[i];
                    if (letra == c)
                    {
                        rightAnswer(i);
                        word = true;
                    }
                }
            }
            else
            {
                word = false;
                wrongAnswer();
                
                if(erros[0] == '\0')
                {
                    erros[0] = c;
                }
                else
                {
                    switch (getTry())
                    {
                        case 1:
                            erros[4] = c;
                            break;
                        case 2:
                            erros[3] = c;
                            break;
                        case 3:
                            erros[2] = c;
                            break;
                        case 4:
                            erros[1] = c; 
                            break;
                    }
                }
            }

            return word;
        }

        public int wordLength()
        {
            return palavra.Length;
        }

        public bool canTry()
        {
            if (tentativas > 0)
            {
                return true;
            }
            return false;
        }

        public int getTry()
        {
            return tentativas;
        }

        private void wordLetters()
        {
            int i = 0;
            foreach (char letra in palavra)
            {
                letras[i] = letra;
                i++;
            }
        }

        public string tryChars ()
        {
            string caracteres = "";
                        
            foreach (char c in erros)
            {
                if (c == erros[0])
                {
                    caracteres = c.ToString();
                }
                else
                {
                    if (c != '\0')
                    {
                        caracteres += $", {c}";
                    }
                }
            }

            return caracteres;
        }

        private void rightAnswer(int pos)
        {
            for (int acerto = 0; acerto < (acertos.Length - 1); acerto++)
            {
                if (acerto == pos) acertos[acerto] = 1;
            }
        }

        private void wrongAnswer()
        {
            tentativas--;
        }

        public string hiddenWord()
        {
            string hiddenWord = "X";
            for (int i = 1; i < palavra.Length; i++)
            {
                hiddenWord += " X";
            }

            return hiddenWord;
        }

        public string showWord()
        {
            string labelText;
            int acerto;

            if (acertos[0] == 1)
            {
                labelText = letras[0].ToString();
            }
            else
            {
                labelText = "X";
            }


            for (acerto = 1; acerto < palavra.Length; acerto++)
            {
                if (acertos[acerto] == 1)
                {
                    labelText += " " + letras[acerto].ToString();
                }
                else
                {
                    labelText += " X";
                }
            }

            return labelText;
        }

        public string wordComplete()
        {
            bool completa = false;

            foreach(int i in acertos)
            {
                if (i == 1)
                {
                    completa = true;
                }
                else
                {
                    completa = false;
                }
            }

            if (completa)
            {
                return palavra;
            }

            return "incomplete";
        }
    }
}
