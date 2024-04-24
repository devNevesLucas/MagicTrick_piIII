using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class PosicionamentoPonto : Posicionamento
    {
        int MargemPontos;

        public PosicionamentoPonto(int x, int y, char orientacao, int iterador) : base(18)
        {
            int xFinal = x;
            int yFinal = y;

            if (orientacao == 'V')
            {
                if (iterador >= 7)
                {
                    iterador -= 7;
                    xFinal += this.Largura + this.MargemPontos;
                }

                yFinal += this.Altura * iterador;
                yFinal += this.MargemPontos * iterador;
            }

            else
            {
                if (iterador >= 7)
                {
                    iterador -= 7;
                    yFinal += this.Altura + this.MargemPontos;
                }

                xFinal += this.Largura * iterador;
                xFinal += this.MargemPontos * iterador;
            }

            this.Ponto = new Point(xFinal, yFinal);
        }



    }
}
