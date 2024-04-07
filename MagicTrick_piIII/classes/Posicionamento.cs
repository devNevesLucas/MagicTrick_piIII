using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class Posicionamento
    {

        public int Altura {  get; set; }    
        public int Largura { get; set; }    
        public Point Ponto { get; set; }

        int MargemCartas = 10;

        public Posicionamento(int x, int y, char orientacao) 
        { 

            if(orientacao == 'V')
            {
                this.Altura = 38;
                this.Largura = 56;
            }
            else
            {
                this.Altura = 56;
                this.Largura = 38;
            } 

            this.Ponto = new Point(x, y);  
        }

        public Posicionamento(int x, int y, char orientacao, int iterador)
        {
            int xFinal = x;
            int yFinal = y;

            this.Altura = 56;
            this.Largura = 38;

            if (orientacao == 'V')
            {
                this.Altura = 38;
                this.Largura = 56;
            }

            if(orientacao == 'V')
            {
                if(iterador >= 7)
                {
                    iterador -= 7;
                    xFinal += this.Largura + this.MargemCartas;
                }

                yFinal += this.Altura * iterador;
                yFinal += this.MargemCartas * iterador;
            }

            else
            {
                if(iterador >= 7)
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
