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
        public List<int> PossiveisValores { get; set; }    
        public char Naipe { get; set; }
        public bool Disponivel {  get; set; }     
        public ImagemCarta ImagemCarta { get; set; }


        int[] valores = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

        public Carta (char naipe)
        {
            this.PossiveisValores = new List<int>();

            this.PossiveisValores.AddRange(valores.ToList());

            this.Naipe = naipe;

            this.Disponivel = true;
        }

        public void ResetarCarta (char naipe)
        {
            this.PossiveisValores = new List<int>();

            this.PossiveisValores.AddRange(valores.ToList());

            this.Naipe = naipe;

            this.Disponivel = true;
        }

        public void TornarIndisponivel(int numeroCarta)
        {
            this.ValorReal = numeroCarta; 
            this.Disponivel = false;

            this.PossiveisValores.Clear();
            this.PossiveisValores.Add(numeroCarta);

            this.ImagemCarta.ExibirLabelNumero(numeroCarta);
        }

        public void AtualizarCarta(char naipe, int numeroCarta, int contador)
        {
            this.Naipe = naipe;

            this.TornarIndisponivel(numeroCarta);
            this.ImagemCarta.AtualizarImagemCarta(naipe, contador);
        }
    }
}
