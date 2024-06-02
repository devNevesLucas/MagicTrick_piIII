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
            char naipeAtual;
            bool comparar;
            
            CartaHistorico cartaAtual, maiorCarta;            
            List<CartaHistorico> listaRodada = historico.Baralho[this.Rodada];

            this.NaipeRodada = listaRodada[0].Naipe;
            this.Naipes.Add(listaRodada[0].Naipe);

            maiorCarta = listaRodada[0];

            for(int i = 1; i < listaRodada.Count; i++)
            {
                cartaAtual = listaRodada[i];
                comparar = false;

                naipeAtual = cartaAtual.Naipe;

                if (!this.Naipes.Contains(naipeAtual))
                    this.Naipes.Add(naipeAtual);

                if(cartaAtual.Naipe == maiorCarta.Naipe)               
                    comparar = true;
                
                if(cartaAtual.Naipe == 'C' && maiorCarta.Naipe != 'C')
                {
                    maiorCarta = cartaAtual;
                    continue;
                }

                if(comparar && cartaAtual.ValorReal > maiorCarta.ValorReal)                
                    maiorCarta = cartaAtual;                
            }
            
            this.IdJogador = maiorCarta.IdJogador;
        }

        public static void AtribuirPonto(Jogador jogador, Ponto ponto, Control.ControlCollection controle)
        {
            jogador.PontosRodada.Add(ponto);

            int qtdPontosRodada = jogador.PontosRodada.Count;
            char naipePonto = ponto.NaipeRodada;

            foreach(char naipe in ponto.Naipes)            
                if (!jogador.NaipesDePontosDaRodada.Contains(naipe))
                    jogador.NaipesDePontosDaRodada.Add(naipe);

            jogador.AtualizarLblNaipesVitorias();

            ponto.ImagemPonto = new ImagemPonto(jogador.Posicao, qtdPontosRodada, naipePonto);
            controle.Add(ponto.ImagemPonto.PnlPonto);
            ponto.ImagemPonto.PnlPonto.BringToFront();
        }

        public static void AtribuirUltimoPontoDoRound(Jogador jogador, Ponto ponto)
        {
            jogador.PontosRodada.Add(ponto);

            int qtdPontosRodada = jogador.PontosRodada.Count;
            char naipePonto = ponto.NaipeRodada;

            foreach (char naipe in ponto.Naipes)
                if (!jogador.NaipesDePontosDaRodada.Contains(naipe))
                    jogador.NaipesDePontosDaRodada.Add(naipe);

            jogador.AtualizarLblNaipesVitorias();

            ponto.ImagemPonto = new ImagemPonto(jogador.Posicao, qtdPontosRodada, naipePonto);
        }
    }
}
