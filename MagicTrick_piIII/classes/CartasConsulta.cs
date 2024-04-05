using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartasConsulta
    {
        public int IdJogador {  get; set; }
        public List<int> Posicoes { get; set; }
        public List<char> NaipeCartas {  get; set; }


        public CartasConsulta(int IdJogador, int posicao, char naipe)
        {
            this.IdJogador = IdJogador;
            this.Posicoes = new List<int>();
            this.NaipeCartas = new List<char>();

            this.Posicoes.Add(posicao);
            this.NaipeCartas.Add(naipe);
        }

        public static List<CartasConsulta> HandleConsultarMao(int idPartida)
        {
            List<CartasConsulta> cartasConsultaTmp = new List<CartasConsulta>();

            string result = Jogo.ConsultarMao(idPartida);

            if (Auxiliar.VerificarErro(result))
                return cartasConsultaTmp;

            result = result.Replace("\r", "");

            return RetornarCartasJogadores(result);   
        }

        private static List<CartasConsulta> RetornarCartasJogadores(string consultaBruta)
        {
            List<CartasConsulta> cartasConsulta = new List<CartasConsulta>();

            string[] dadosBrutos = consultaBruta.Split('\n');
            string[] dados;

            int idJogador, indexJogador, indexCarta;
            char naipe;

            for(int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i] == "") continue;

                dados = dadosBrutos[i].Split('\n');

                idJogador = Convert.ToInt32(dados[0]);
                indexCarta = Convert.ToInt32(dados[1]);
                naipe = Convert.ToChar(dados[2]);

                indexJogador = cartasConsulta.FindIndex(c => c.IdJogador == idJogador);

                if (indexJogador > -1)
                {
                    cartasConsulta[indexJogador].Posicoes.Add(indexCarta);
                    cartasConsulta[indexJogador].NaipeCartas.Add(naipe);
                }

                else
                    cartasConsulta.Add(new CartasConsulta(idJogador, indexCarta, naipe));
            }
            return cartasConsulta;
        }
    }
}
