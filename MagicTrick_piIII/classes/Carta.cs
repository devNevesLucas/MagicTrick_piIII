using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class Carta
    {
        public int Posicao { get; set; }
        public char Naipe { get; set; }

        public Carta(int posicao, char naipe)
        {
            this.Posicao = posicao;
            this.Naipe = naipe;
        }
    }
}
