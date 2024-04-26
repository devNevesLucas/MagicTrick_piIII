using MagicTrick_piIII.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.classes
{
    public class ImagemPonto
    {
        public Panel PnlPonto;
        public PosicionamentoPonto Posicionamento { get; set; }

        public static int[,] posicoes = { { 35, 119 }, { 769, 77 }, { 1003, 529 }, { 366, 475 } };


        public ImagemPonto(Posicao posicao, int qtdPontos, char naipe)
        {
            int posicaoTela = (int)posicao;
            Orientacao orientacao = Orientacao.Horizontal;

            if (posicao == Posicao.Cima || posicao == Posicao.Baixo)
                orientacao = Orientacao.Vertical;

            int x = posicoes[posicaoTela, 0];
            int y = posicoes[posicaoTela, 1];

            this.Posicionamento = new PosicionamentoPonto(x, y, orientacao, qtdPontos);
            this.PnlPonto = new Panel();

            this.PnlPonto.Width = this.Posicionamento.Largura;
            this.PnlPonto.Height = this.Posicionamento.Altura;
            this.PnlPonto.Location = this.Posicionamento.Ponto;
            this.PnlPonto.BackgroundImage = RetornarPontoBitmap(naipe);
        }

        public static Bitmap RetornarPontoBitmap(char naipe)
        {
            switch(naipe)
            {              
                case 'C':
                    return Properties.Resources.coracao_vitoria;

                case 'E':
                    return Properties.Resources.espadas_vitoria;

                case 'L':
                    return Properties.Resources.lua_vitoria;

                case 'O':
                    return Properties.Resources.ouros_vitoria;

                case 'P':
                    return Properties.Resources.paus_vitoria;

                case 'S':
                    return Properties.Resources.estrela_vitoria;

                case 'T':
                    return Properties.Resources.triangulo_vitoria;

                default:
                    return Properties.Resources.ouros_vitoria;
            }
        }
    }
}
