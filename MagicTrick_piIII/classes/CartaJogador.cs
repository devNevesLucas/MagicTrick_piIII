using MagicTrick_piIII.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.classes
{
    public class CartaJogador : CartaComValor
    {
        public List<int> PossiveisValores { get; set; }                   
        public bool Disponivel { get; set; }     
        public bool Descoberta { get; set; }   
        public ImagemCarta ImagemCarta { get; set; }


        int[] valores = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

        public CartaJogador (char naipe, int posicao) : base(posicao, naipe)
        {
            this.PossiveisValores = new List<int>();

            this.PossiveisValores.AddRange(valores.ToList());

            this.Naipe = naipe;

            this.Posicao = posicao;

            this.Disponivel = true;
            this.Descoberta = false;
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

        public static void LimitarDeckJogador(List<CartaJogador> deck, int posicao, int valorCarta)
        {
            for(int i = 0; i < posicao - 1; i++)
                if (deck[i].Disponivel || deck[i].PossiveisValores.Count > 1)
                    deck[i].LimitarAcima(valorCarta);

            for (int i = posicao; i < deck.Count; i++)
                if (deck[i].Disponivel || deck[i].PossiveisValores.Count > 1)
                    deck[i].LimitarAbaixo(valorCarta);                        
        }

        public void LimitarAcima(int limite)
        {
            List<int> valoresRemovidos = new List<int>();

            foreach (int valor in this.PossiveisValores)
                if (valor > limite)
                    valoresRemovidos.Add(valor);

            foreach (int valorRemovido in valoresRemovidos)
                this.PossiveisValores.Remove(valorRemovido);

            if (this.PossiveisValores.Count == 1)
                this.AtualizarCartaDescoberta();
        }

        public void LimitarAbaixo(int limite)
        {
            List<int> valoresRemovidos = new List<int>();
           
            foreach (int valor in this.PossiveisValores)
                if (valor < limite)
                    valoresRemovidos.Add(valor);

            foreach (int valorRemovido in valoresRemovidos)
                this.PossiveisValores.Remove(valorRemovido);

            if (this.PossiveisValores.Count == 1)
                this.AtualizarCartaDescoberta();
        }
   
        public void AtualizarCartaDescoberta()
        {
            this.ValorReal = this.PossiveisValores[0];
            this.ImagemCarta.ExibirValorDescoberto(this.ValorReal);
        }

        public bool ContemValorSuperior(int valor)
        {
            bool flagValor = false;

            foreach (int valorPossivel in PossiveisValores)
                if (valorPossivel > valor)
                {
                    flagValor = true;
                    break;
                }

            return flagValor;
        }
    }
}
