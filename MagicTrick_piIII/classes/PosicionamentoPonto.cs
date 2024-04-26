using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using MagicTrick_piIII.Enums;

namespace MagicTrick_piIII.classes
{
    public class PosicionamentoPonto : Posicionamento
    {
        int MargemPontos = 2;

        public PosicionamentoPonto(int x, int y, Orientacao orientacao, int iterador) : base(18)
        {
            int xFinal = x;
            int yFinal = y;

            iterador--;

            if (orientacao == Orientacao.Vertical)
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
