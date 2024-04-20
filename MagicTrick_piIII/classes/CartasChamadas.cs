using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public abstract class CartasChamadas
    {
        public int IdJogador { get; set; }
        public List<int> Posicoes { get; set; }
        public List<char> NaipeCartas { get; set; }


        public CartasChamadas(int idJogador, int posicao, char naipe) 
        {
            this.IdJogador = idJogador;
            this.Posicoes = new List<int>();
            this.NaipeCartas = new List<char>();

            this.Posicoes.Add(posicao);
            this.NaipeCartas.Add(naipe);
        }
    }
}
