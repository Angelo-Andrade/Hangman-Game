using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaForca
{
    internal class Class_Palavra
    {
        private int Sense { get; set; }
        private string Word { get; set; }
        private int Wid { get; set; }

        public Class_Palavra(int sense, string word, int wid)
        {
            Sense = sense;
            Word = word;
            Wid = wid;
        }

        public string randonWord()
        {
            if (Word == null)
            {
                return "";

            }

            return Word;
        }
    }
}
