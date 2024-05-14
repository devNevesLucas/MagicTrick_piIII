using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.classes
{
    public class Ponto
    {
        public int IdJogador { get; set; }  
        public char NaipeRodada { get; set; }    
        public int Rodada { get; set; }
        public List<char> Naipes { get; set; }
        public ImagemPonto ImagemPonto { get; set; }


        public Ponto(BaralhoHistorico historico, int rodadaAtual)
        {
            this.Naipes = new List<char>();

            this.Rodada = rodadaAtual - 1;           
            int indexMaior = 0, maiorValor = 0;
            int valorAtual;
            char naipeDoMaiorValor = 'L';
            char naipeAtual;
            bool comparar;

            CartaHistorico cartaTmp;

            bool flagInicio = false;

            foreach(KeyValuePair<int, List<CartaHistorico>> chaveValor in historico.Baralho)
            {               
                cartaTmp = chaveValor.Value.Find(c => c.Rodada == this.Rodada);

                naipeAtual = cartaTmp.Naipe;
                valorAtual = cartaTmp.ValorReal;

                if (!flagInicio)
                {
                    this.NaipeRodada = naipeAtual;
                    naipeDoMaiorValor = naipeAtual;
                    flagInicio = true;
                }

                comparar = false;

                if (this.NaipeRodada != 'C' && naipeAtual == 'C')
                    if (naipeDoMaiorValor == 'C')
                        comparar = true;

                    else
                    {
                        maiorValor = valorAtual;
                        indexMaior = chaveValor.Key;
                        naipeDoMaiorValor = naipeAtual;
                    }

                if (this.NaipeRodada == naipeAtual)
                    comparar = true;

                if (comparar && valorAtual > maiorValor)
                {
                    maiorValor = valorAtual;
                    indexMaior = chaveValor.Key;
                    naipeDoMaiorValor = naipeAtual;
                }

                if (!this.Naipes.Contains(naipeAtual))
                    this.Naipes.Add(naipeAtual);
            }
       
            this.IdJogador = indexMaior;
        }

        public static void AtribuirPonto(Jogador jogador, Ponto ponto, Control.ControlCollection controle)
        {
            jogador.PontosRodada.Add(ponto);

            int qtdPontosRodada = jogador.PontosRodada.Count;
            char naipePonto = ponto.NaipeRodada;

            foreach(char naipe in ponto.Naipes)            
                if (!jogador.NaipesDePontosDaRodada.Contains(naipe))
                    jogador.NaipesDePontosDaRodada.Add(naipe);
            
            ponto.ImagemPonto = new ImagemPonto(jogador.Posicao, qtdPontosRodada, naipePonto);
            controle.Add(ponto.ImagemPonto.PnlPonto);
            ponto.ImagemPonto.PnlPonto.BringToFront();
        }
    }
}
