using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartaVerificacao : CartaComValor
    {
        public char Status { get; set; }  

        public CartaVerificacao(int posicao, char naipe, int valor, char status) : base(posicao, naipe, valor)
        {
            this.Status = status;
        }
    }
}
