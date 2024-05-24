using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartaHistorico : CartaComValor
    {
        public int IdJogador { get; set; } 

        public CartaHistorico(int posicao, char naipe, int valor, int idJogador) : base(posicao, naipe, valor)
        {
            this.IdJogador = idJogador;
        }
    }
}
