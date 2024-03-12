using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class Carta
    {
        int ValorReal { get; set; }
        int[] PossiveisValores { get; set; }    
        char Naipe { get; set; }
        bool Disponivel {  get; set; }  

        public Carta (string naipe)
        {
            this.PossiveisValores = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};

            this.Naipe = Convert.ToChar(naipe);

            this.Disponivel = true;
        }
    }
}
