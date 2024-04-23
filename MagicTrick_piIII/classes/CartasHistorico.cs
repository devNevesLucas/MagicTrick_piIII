using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartasHistorico : CartasChamadas
    {
        public List<int> Rodadas { get; set; }  
        public List<int> Valores { get; set; }

        CartasHistorico(int idJogador, int posicao, char naipe, int rodada, int valor) : base(idJogador, posicao, naipe)
        {
            this.Rodadas = new List<int>();
            this.Rodadas.Add(rodada);

            this.Valores = new List<int>(); 
            Valores.Add(valor);
        }

        public static List<CartasHistorico> HandleHistoricoJogadas(Partida partida)
        {
            List<CartasHistorico> cartasHistoricoTmp = new List<CartasHistorico>();

            int idPartida = partida.IdPartida;
            int round = partida.Round;

            string result;

            try
            {
                result = Jogo.ExibirJogadas2(idPartida, round);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return cartasHistoricoTmp;
            }

            if (Auxiliar.VerificarErro(result))
                return cartasHistoricoTmp;

            result = result.Replace("\r", "");

            return RetornarHistoricoJogadasTratado(result);
        }

        private static List<CartasHistorico> RetornarHistoricoJogadasTratado(string consultaBruta)
        {
            List<CartasHistorico> historicoJogadas = new List<CartasHistorico>();

            string[] dadosBrutos = consultaBruta.Split('\n');
            string[] dados;

            int idJogador, rodada ,valor, posicao, indexJogador;
            char naipe;

            for (int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i] == "") continue;

                dados = dadosBrutos[i].Split(',');

                rodada = Convert.ToInt32(dados[0]);
                idJogador = Convert.ToInt32(dados[1]);
                naipe = Convert.ToChar(dados[2]);
                valor = Convert.ToInt32(dados[3]);
                posicao = Convert.ToInt32(dados[4]);

                indexJogador = historicoJogadas.FindIndex(h => h.IdJogador == idJogador);

                if (indexJogador > -1)
                {
                    historicoJogadas[indexJogador].Rodadas.Add(rodada);
                    historicoJogadas[indexJogador].NaipeCartas.Add(naipe);
                    historicoJogadas[indexJogador].Valores.Add(valor);
                    historicoJogadas[indexJogador].Posicoes.Add(posicao);
                }
                else
                    historicoJogadas.Add(new CartasHistorico(idJogador, posicao, naipe, rodada, valor));
            }
            return historicoJogadas;
        }
    }
}
