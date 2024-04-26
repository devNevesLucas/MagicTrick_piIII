using MagicTrick_piIII.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public abstract class Posicionamento
    {
        public int Altura {  get; set; }    
        public int Largura { get; set; }    
        public Point Ponto { get; set; }
             
        public Posicionamento(int x, int y)
        {
            this.Ponto = new Point(x, y);
        }

        public Posicionamento(int tamanho)
        {
            this.Largura = tamanho;
            this.Altura = tamanho;
        }

        public Posicionamento(int dimensaoA, int dimensaoB, Orientacao orientacao)
        {            
            if (orientacao == Orientacao.Vertical)
            {
                this.Altura = dimensaoA;
                this.Largura = dimensaoB;
            }
            else
            {
                this.Altura = dimensaoB;
                this.Largura = dimensaoA;
            }
        }   
    }
}
