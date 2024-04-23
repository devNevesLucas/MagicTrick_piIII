using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class Ponto
    {
        public int IdJogador { get; set; }  
        public char Naipe { get; set; }    
        public int Rodada { get; set; }
        public List<char> Naipes { get; set; }

        public Ponto(List<CartasHistorico> historico, int rodadaAtual)
        {
            this.Naipes = new List<char>();

            this.Rodada = rodadaAtual - 1;
            int indexRodada = historico[0].Rodadas.IndexOf(this.Rodada);

            int indexMaior, maiorValor = 0;
            int valorAtual;
            char naipeRodada = historico[0].NaipeCartas[indexRodada];
            char  naipeMaior, naipeAtual;

            for(int i = 0; i < historico.Count; i++)
            {
                naipeAtual = historico[i].NaipeCartas[indexRodada];
                this.Naipes.Add(naipeAtual);

                valorAtual = historico[i].Valores[indexRodada];

                if (naipeRodada == naipeAtual)                
                    if (valorAtual > maiorValor)
                    {
                        maiorValor = valorAtual;
                        indexMaior = i;
                        naipeMaior = naipeAtual;
                    }
                
                if(naipeRodada != 'C' && naipeAtual == 'C')
                {

                }
               
                


            }


        }


    }
}
