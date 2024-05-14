using MagicTrick_piIII.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartaComValor : Carta, IValor
    {
        public int ValorReal { get; set; }

        public CartaComValor(int posicao, char naipe, int valor) : base(posicao, naipe)
        {
            this.ValorReal = valor;
        }

        public CartaComValor(int posicao, char naipe) : base(posicao, naipe)
        {
            this.ValorReal = -1;
        }
    }
}
