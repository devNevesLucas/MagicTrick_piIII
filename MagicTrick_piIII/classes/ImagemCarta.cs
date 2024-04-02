using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.classes
{
    public class ImagemCarta
    {
        public Panel ImgNaipe { get; set; }
        public Label ValorCarta { get; set; }
        public Posicionamento Posicionamento { get; set; }

        public static int[,] posicoes = new int[,] { { 41, 178 }, { 212, 84 }, { 592, 178 }, { 212, 481 } };

        public ImagemCarta(int x, int y, char orientacao, char naipe)
        {

            this.Posicionamento = new Posicionamento(x, y, orientacao);

            this.ImgNaipe = new Panel();

            this.ImgNaipe.Width = this.Posicionamento.Largura;
            this.ImgNaipe.Height = this.Posicionamento.Altura;
            this.ImgNaipe.Location = this.Posicionamento.Ponto;

            this.ImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacao);
        }

        public ImagemCarta(int x, int y, char orientacao, char naipe, int iterador)
        {
            this.Posicionamento = new Posicionamento(x, y, orientacao, iterador);

            this.ImgNaipe = new Panel();

            this.ImgNaipe.Width = this.Posicionamento.Largura;
            this.ImgNaipe.Height = this.Posicionamento.Altura;
            this.ImgNaipe.Location = this.Posicionamento.Ponto;

            this.ImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacao);
        }

        public static Bitmap RetornarNaipeBitmap(char naipe, char orientacao)
        {
            if(orientacao == 'H')
                switch (naipe)
                {
                    case 'C':
                        return Properties.Resources.coracao;

                    case 'O':
                        return Properties.Resources.ouros;

                    case 'E':
                        return Properties.Resources.espadas;

                    case 'P':
                        return Properties.Resources.paus;

                    case 'S':
                        return Properties.Resources.estrelas;

                    case 'T':
                        return Properties.Resources.triangulo;

                    case 'L':
                        return Properties.Resources.lua;

                    default:
                        return Properties.Resources.ouros;
                }

            else 
                switch(naipe)
                {
                    case 'C':
                        return Properties.Resources.coracaoHorizontal;

                    case 'O':
                        return Properties.Resources.ourosHorizontal;

                    case 'E':
                        return Properties.Resources.espadasHorizontal;

                    case 'P':
                        return Properties.Resources.pausHorizontal;

                    case 'S':
                        return Properties.Resources.estrelasHorizontal;

                    case 'T':
                        return Properties.Resources.trianguloHorizontal;

                    case 'L':
                        return Properties.Resources.luaHorizontal;

                    default:
                        return Properties.Resources.ourosHorizontal;
                }

        }

        public static void ExibirCartas(List<Jogador> jogadores, Control.ControlCollection controle)
        {
            for(int i = 0; i <  jogadores.Count; i++)
            {
                char orientacao = 'H';

                if (i % 2 == 0)
                    orientacao = 'V';
            
                for(int j = 0; j < jogadores[i].Deck.Count; j++)
                {                                      
                    char naipe = jogadores[i].Deck[j].Naipe;
                    int x = posicoes[i, 0];
                    int y = posicoes[i, 1];

                    jogadores[i].Deck[j].ImagemCarta = new ImagemCarta(x, y, orientacao, naipe, j);

                    controle.Add(jogadores[i].Deck[j].ImagemCarta.ImgNaipe);
                    jogadores[i].Deck[j].ImagemCarta.ImgNaipe.BringToFront();
                }            
            }
        }
    }
}
