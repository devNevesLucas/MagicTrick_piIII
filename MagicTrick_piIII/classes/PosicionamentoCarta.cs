using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class PosicionamentoCarta : Posicionamento
    {
        int MargemCartas = 10;

        public PosicionamentoCarta(int x, int y, char orientacao) : base(x, y)
        {
            if (orientacao == 'V')
            {
                this.Altura = 38;
                this.Largura = 56;
            }
            else
            {
                this.Altura = 56;
                this.Largura = 38;
            }
        }

        public PosicionamentoCarta(int x, int y, char orientacao, int iterador) : base(38, 56, orientacao)
        {
            int xFinal = x;
            int yFinal = y;

            if (orientacao == 'V')
            {
                if (iterador >= 7)
                {
                    iterador -= 7;
                    xFinal += this.Largura + this.MargemCartas;
                }

                yFinal += this.Altura * iterador;
                yFinal += this.MargemCartas * iterador;
            }

            else
            {
                if (iterador >= 7)
                {
                    iterador -= 7;
                    yFinal += this.Altura + this.MargemCartas;
                }

                xFinal += this.Largura * iterador;
                xFinal += this.MargemCartas * iterador;
            }

            this.Ponto = new Point(xFinal, yFinal);
        }
    }
}
