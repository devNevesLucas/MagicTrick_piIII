using MagicTrick_piIII.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.classes
{
    public class Carta
    {
        public int ValorReal { get; set; }
        public int Posicao { get; set; }
        public List<int> PossiveisValores { get; set; }    
        public char Naipe { get; set; }
        public bool Disponivel {  get; set; }     
        public ImagemCarta ImagemCarta { get; set; }


        int[] valores = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

        public Carta () { }

        public Carta (char naipe, int posicao)
        {
            this.PossiveisValores = new List<int>();

            this.PossiveisValores.AddRange(valores.ToList());

            this.Naipe = naipe;

            this.Posicao = posicao;

            this.Disponivel = true;
        }

        public void ResetarCarta (char naipe)
        {
            this.PossiveisValores.Clear();

            this.PossiveisValores.AddRange(valores.ToList());

            this.Naipe = naipe;

            this.Disponivel = true;
        }

        public void TornarIndisponivel(int numeroCarta)
        {
            this.ImagemCarta.ExibirLabelValor(numeroCarta);

            if (!this.Disponivel)
                return;

            this.ValorReal = numeroCarta; 
            this.Disponivel = false;

            this.PossiveisValores.Clear();
            this.PossiveisValores.Add(numeroCarta);
        }

        public void AtualizarCarta(char naipe, int numeroCarta, Orientacao orientacao)
        {
            this.Naipe = naipe;

            this.TornarIndisponivel(numeroCarta);
            this.ImagemCarta.AtualizarImagemCarta(naipe, orientacao);
        }

        public void LimitarAbaixo(int limite)
        {
            int indexValor = this.PossiveisValores.IndexOf(limite);

            if (indexValor == -1)
                return;

            int posicaoFinal = indexValor - 1;

            if (posicaoFinal == -1)
                posicaoFinal = 0;

            this.PossiveisValores.RemoveRange(0, posicaoFinal);

            if (this.PossiveisValores.Count == 1)
                this.AtualizarCartaDescoberta();
        }

        public void LimitarAcima(int limite)
        {
            int indexValor = this.PossiveisValores.IndexOf(limite);
            int posicaoInicial = indexValor + 1;
            int qtdItens = this.PossiveisValores.Count - posicaoInicial;
            this.PossiveisValores.RemoveRange(posicaoInicial, qtdItens);

            if (this.PossiveisValores.Count == 1)
                this.AtualizarCartaDescoberta();
        }

        public void AtualizarCartaDescoberta()
        {
            this.ValorReal = this.PossiveisValores[0];
            this.ImagemCarta.ExibirValorDescoberto(this.ValorReal);
        }
    }
}
