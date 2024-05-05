using MagicTrick_piIII.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartasVerificacao : CartasChamadas, IValoresContainer
    {
        public List<int> Valores { get; set; }    
        public List<char> StatusCartas { get; set; }

        public CartasVerificacao(int idJogador, int posicao, char naipe, int valor, char status) : base(idJogador, posicao, naipe) 
        {
            this.Valores = new List<int>();
            this.StatusCartas = new List<char>();

            this.Valores.Add(valor);
            this.StatusCartas.Add(status);
        }

        public static List<CartasVerificacao> RetornarCartasVerificacaoTratadas(string[] dadosBrutos, ref char? naipeRodada)
        {
            List<CartasVerificacao> cartasTmp = new List<CartasVerificacao>();

            string[] dados;
            int idJogador, valorCarta, posicaoCarta, indexJogador;
            char naipe, status;

            bool flagNaipeRodada = false;

            for(int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i].Length == 0) continue;

                if (dadosBrutos[i].StartsWith("C:"))
                {
                    status = 'C';
                    dadosBrutos[i] = dadosBrutos[i].Replace("C:", "");
                }
                else
                {
                    status = 'A';
                    dadosBrutos[i] = dadosBrutos[i].Replace("A:", "");
                }

                dados = dadosBrutos[i].Split(',');

                idJogador = Convert.ToInt32(dados[0]);
                naipe = Convert.ToChar(dados[1]);
                valorCarta = Convert.ToInt32(dados[2]);

                if(status == 'C' && !flagNaipeRodada)
                {
                    naipeRodada = naipe;
                    flagNaipeRodada = true;
                }

                if (status == 'C')
                    posicaoCarta = Convert.ToInt32(dados[3]);

                else
                    posicaoCarta = Convert.ToInt32(dados[4]);

                indexJogador = cartasTmp.FindIndex(c => c.IdJogador == idJogador);

                if (indexJogador > -1)
                {
                    cartasTmp[indexJogador].NaipeCartas.Add(naipe);
                    cartasTmp[indexJogador].Valores.Add(valorCarta);
                    cartasTmp[indexJogador].Posicoes.Add(posicaoCarta);
                    cartasTmp[indexJogador].StatusCartas.Add(status);
                }

                else
                    cartasTmp.Add(new CartasVerificacao(idJogador, posicaoCarta, naipe, valorCarta, status));
            }
            return cartasTmp;
        }
    }
}
