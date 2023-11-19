using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace MinhaForca

{
    internal class Class_Biblioteca
    {
        private readonly RestClient client;
        private const string urlAPI = "https://api.dicionario-aberto.net/random";
        private Random random = new Random();

        public Class_Biblioteca()
        {
            client = new RestClient(urlAPI);
        }

        public RestResponse getMethod()
        {
            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            //MessageBox.Show(response.Content);

            return response;
        }

        public string getPalavra (string tema)
        {
            string palavra = "";
            string[] animais = { "tauntaun", "bantha", "rancor", "womp rat", "eopie" };
            string[] personagens = { "luke skywalker", "darth vader", "leia organa", "han solo", "chewbacca", "yoda", "obi-wan kenobi", "padmé amidala" };
            string[] espaçonaves = { "millennium falcon", "x-wing", "tie fighter", "star destroyer", "slave i", "death star", "the ghost", "razor crest" };


            switch (tema) 
            {
                case "Personagens":
                    palavra = personagens[random.Next(0, 7)]; 
                    break;

                case "Espaçonaves":
                    palavra = espaçonaves[random.Next(random.Next(0, 7))];
                    break;

                case "Animais":
                    palavra = animais[random.Next(0, 4)];
                    break;
            }

            MessageBox.Show(palavra);
            return palavra;
        }

        public string getTema ()
        {
            string tema = "";
            int num = random.Next(0, 3);

            string[] temas = { "Animais", "Personagens", "Espaçonaves" };

            tema = temas[num];
            return tema;
        }
    }
}
