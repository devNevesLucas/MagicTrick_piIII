using MagicTrick_piIII.Interfaces;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class BaralhoHistorico
    {
        public Dictionary<int, List<CartaHistorico>> Baralho { get; set; }

        public BaralhoHistorico()
        {
            this.Baralho = new Dictionary<int, List<CartaHistorico>>(); 
        }

        public static BaralhoHistorico HandleHistoricoJogadas(Partida partida)
        {
            BaralhoHistorico cartasHistoricoTmp = new BaralhoHistorico();

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

        private static BaralhoHistorico RetornarHistoricoJogadasTratado(string consultaBruta)
        {
            BaralhoHistorico historicoJogadas = new BaralhoHistorico();

            string[] dadosBrutos = consultaBruta.Split('\n');
            string[] dados;

            int idJogador, rodada ,valor, posicao;
            char naipe;

            CartaHistorico cartaTmp;
            List<CartaHistorico> listaTmp;

            for (int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i] == "") continue;

                dados = dadosBrutos[i].Split(',');

                rodada = Convert.ToInt32(dados[0]);
                idJogador = Convert.ToInt32(dados[1]);
                naipe = Convert.ToChar(dados[2]);
                valor = Convert.ToInt32(dados[3]);
                posicao = Convert.ToInt32(dados[4]);
             
                cartaTmp = new CartaHistorico(posicao, naipe, valor, rodada);               

                if (historicoJogadas.Baralho.ContainsKey(idJogador))                                   
                    historicoJogadas.Baralho[idJogador].Add(cartaTmp);
                
                else
                {
                    listaTmp = new List<CartaHistorico>
                    { 
                        cartaTmp 
                    };

                    historicoJogadas.Baralho.Add(idJogador, listaTmp);
                }                                
            }
            return historicoJogadas;
        }
    }
}
