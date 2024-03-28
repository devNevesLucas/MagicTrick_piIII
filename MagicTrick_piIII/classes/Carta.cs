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
        public int[] PossiveisValores { get; set; }    
        public char Naipe { get; set; }
        public bool Disponivel {  get; set; }  

        public Panel PanelCarta { get; set; }    
        public ImagemCarta ImagemCarta { get; set; }

        public Carta (string naipe)
        {
            this.PossiveisValores = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};

            this.Naipe = Convert.ToChar(naipe);

            this.Disponivel = true;
        }
    }
}
