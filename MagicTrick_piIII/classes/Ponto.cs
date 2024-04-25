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


        public Ponto(List<CartasHistorico> historico, int rodadaAtual)
        {
            this.Naipes = new List<char>();

            this.Rodada = rodadaAtual - 1;
            int indexRodada = historico[0].Rodadas.IndexOf(this.Rodada);

            this.NaipeRodada = historico[0].NaipeCartas[indexRodada];

            int indexMaior = 0, maiorValor = 0;
            int valorAtual;          
            char naipeDoMaiorValor = this.NaipeRodada;
            char naipeAtual;
            bool comparar;
            
            for (int i = 0; i < historico.Count; i++)
            {
                naipeAtual = historico[i].NaipeCartas[indexRodada];               
                valorAtual = historico[i].Valores[indexRodada];

                comparar = false;

                if (naipeDoMaiorValor == 'C' && this.NaipeRodada != 'C' && naipeAtual == 'C')
                    comparar = true;

                if (this.NaipeRodada == naipeAtual)
                    comparar = true;

                if (comparar && valorAtual > maiorValor)
                {
                    maiorValor = valorAtual;
                    indexMaior = i;
                    naipeDoMaiorValor = naipeAtual;
                }

                if (!this.Naipes.Contains(naipeAtual))
                    this.Naipes.Add(naipeAtual);

            }
            this.IdJogador = historico[indexMaior].IdJogador;
        }

        public static void AtribuirPonto(Jogador jogador, Ponto ponto, int indexJogador, Control.ControlCollection controle)
        {
            jogador.PontosRodada.Add(ponto);

            int qtdPontosRodada = jogador.PontosRodada.Count;
            char naipePonto = ponto.NaipeRodada;

            foreach(char naipe in ponto.Naipes)            
                if (!jogador.NaipesDePontosDaRodada.Contains(naipe))
                    jogador.NaipesDePontosDaRodada.Add(naipe);
            
            ponto.ImagemPonto = new ImagemPonto(indexJogador, qtdPontosRodada, naipePonto);
            controle.Add(ponto.ImagemPonto.PnlPonto);
            ponto.ImagemPonto.PnlPonto.BringToFront();
        }
    }
}
