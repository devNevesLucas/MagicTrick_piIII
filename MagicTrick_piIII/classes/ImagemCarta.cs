using MagicTrick_piIII.telas;
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
        public Panel PnlImgNaipe { get; set; }
        public Label LblValorCarta { get; set; }
        public Posicionamento Posicionamento { get; set; }

        public static int[,] posicoes = new int[,] { { 41, 178 }, { 212, 83 }, { 592, 178 }, { 212, 481 } };

        public static int[,] posicoesJogadas = new int[,] { { 288, 326 }, { 359, 270 }, { 411, 326 }, { 359, 364 } };

        public static int[,] posicoesApostas = new int[,] { { 41, 117 }, { 559, 83 }, { 592, 529 }, { 156, 547 } };


        public ImagemCarta(int x, int y, char orientacao, char naipe)
        {
            this.Posicionamento = new Posicionamento(x, y, orientacao);
            this.InicializarPropriedades(orientacao, naipe);
        }

        public ImagemCarta(int x, int y, char orientacao, char naipe, int iterador)
        {
            this.Posicionamento = new Posicionamento(x, y, orientacao, iterador);
            this.InicializarPropriedades(orientacao, naipe);
        }

        private void InicializarPropriedades(char orientacao, char naipe)
        {
            this.PnlImgNaipe = new Panel();
            this.LblValorCarta = new Label();
           
            this.PosicionarPanel();

            this.PnlImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacao);

            this.InicializarLabel();
        }
       
        private void PosicionarPanel()
        {
            this.PnlImgNaipe.Width = this.Posicionamento.Largura;
            this.PnlImgNaipe.Height = this.Posicionamento.Altura;
            this.PnlImgNaipe.Location = this.Posicionamento.Ponto;
        }

        public void InicializarLabel()
        {
            this.LblValorCarta = new Label();

            Font fonteLabel = new Font("Microsoft YaHei", 10, FontStyle.Bold);

            Point ponto = this.Posicionamento.Ponto;
            ponto.X += this.Posicionamento.Largura / 2 - 14;
            ponto.Y += this.Posicionamento.Altura / 2 - 14;

            this.LblValorCarta.Location = ponto;
            this.LblValorCarta.ForeColor = Color.Black;
            this.LblValorCarta.BackColor = System.Drawing.Color.Transparent;

            this.LblValorCarta.TextAlign = ContentAlignment.MiddleCenter;
            this.LblValorCarta.Font = fonteLabel;
           
            this.LblValorCarta.Size = new Size(28, 28);
            this.LblValorCarta.Visible = false;
        }

        public static Bitmap RetornarNaipeBitmap(char naipe, char orientacao)
        {
            if(orientacao == 'H')
                switch (naipe)
                {
                    case 'A':
                        return Properties.Resources.aposta;

                    case 'C':
                        return Properties.Resources.coracao;

                    case 'E':
                        return Properties.Resources.espadas;

                    case 'L':
                        return Properties.Resources.lua;

                    case 'M':
                        return Properties.Resources.mascara;

                    case 'O':
                        return Properties.Resources.ouros;

                    case 'P':
                        return Properties.Resources.paus;

                    case 'S':
                        return Properties.Resources.estrelas;

                    case 'T':
                        return Properties.Resources.triangulo;

                    default:
                        return Properties.Resources.ouros;
                }

            else 
                switch(naipe)
                {
                    case 'C':
                        return Properties.Resources.coracaoHorizontal;

                    case 'E':
                        return Properties.Resources.espadasHorizontal;

                    case 'L':
                        return Properties.Resources.luaHorizontal;

                    case 'M':
                        return Properties.Resources.mascaraHorizontal;

                    case 'O':
                        return Properties.Resources.ourosHorizontal;

                    case 'P':
                        return Properties.Resources.pausHorizontal;

                    case 'S':
                        return Properties.Resources.estrelasHorizontal;

                    case 'T':
                        return Properties.Resources.trianguloHorizontal;

                    default:
                        return Properties.Resources.ourosHorizontal;
                }
        }

        public static void CriarImagemCartas(List<Jogador> jogadores, Control.ControlCollection controle)
        {
            if(jogadores.Count == 4)
                for(int i = 0; i <  jogadores.Count; i++)
                {
                    char orientacao = 'H';
                    int x, y;

                    if (i % 2 == 0)
                        orientacao = 'V';
            
                    for(int j = 0; j < jogadores[i].Deck.Count; j++)
                    {                                      
                        char naipe = jogadores[i].Deck[j].Naipe;
                        x = posicoes[i, 0];
                        y = posicoes[i, 1];

                        jogadores[i].Deck[j].ImagemCarta = new ImagemCarta(x, y, orientacao, naipe, j);

                        controle.Add(jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe);                       
                        controle.Add(jogadores[i].Deck[j].ImagemCarta.LblValorCarta);

                        jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe.BringToFront();
                        jogadores[i].Deck[j].ImagemCarta.LblValorCarta.BringToFront();
                    }

                    x = posicoesJogadas[i, 0];
                    y = posicoesJogadas[i, 1];

                    jogadores[i].CartaJogada.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');
                    
                    controle.Add(jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe);
                    controle.Add(jogadores[i].CartaJogada.ImagemCarta.LblValorCarta);

                    jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe.Visible = false;
                    jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe.BringToFront();
                    jogadores[i].CartaJogada.ImagemCarta.LblValorCarta.BringToFront();


                    x = posicoesApostas[i, 0];
                    y = posicoesApostas[i, 1];

                    jogadores[i].CartaAposta.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');

                    controle.Add(jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe);
                    controle.Add(jogadores[i].CartaAposta.ImagemCarta.LblValorCarta);

                    jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe.Visible = false;
                    jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe.BringToFront();
                    jogadores[i].CartaAposta.ImagemCarta.LblValorCarta.BringToFront();
                }

            else 
            {
                char orientacao = 'H';
                int contador = 1;

                for(int i = 0; i < jogadores.Count; i++)
                {
                    int x, y;

                    for(int j = 0; j < jogadores[i].Deck.Count(); j++)
                    {
                        char naipe = jogadores[i].Deck[j].Naipe;
                        x = posicoes[contador, 0];
                        y = posicoes[contador, 1];

                        jogadores[i].Deck[j].ImagemCarta = new ImagemCarta(x, y, orientacao, naipe, j);

                        controle.Add(jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe);
                        controle.Add(jogadores[i].Deck[j].ImagemCarta.LblValorCarta);

                        jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe.BringToFront();
                        jogadores[i].Deck[j].ImagemCarta.LblValorCarta.BringToFront();

                    }
                    x = posicoesJogadas[contador, 0];
                    y = posicoesJogadas[contador, 1];

                    jogadores[i].CartaJogada.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');

                    x = posicoesApostas[contador, 0];
                    y = posicoesApostas[contador, 1];

                    jogadores[i].CartaAposta.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');

                    controle.Add(jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe);
                    controle.Add(jogadores[i].CartaJogada.ImagemCarta.LblValorCarta);

                    jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe.Visible = false;
                    jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe.BringToFront();
                    jogadores[i].CartaJogada.ImagemCarta.LblValorCarta.BringToFront();


                    controle.Add(jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe);
                    controle.Add(jogadores[i].CartaAposta.ImagemCarta.LblValorCarta);

                    jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe.Visible = false;
                    jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe.BringToFront();
                    jogadores[i].CartaAposta.ImagemCarta.LblValorCarta.BringToFront();

                    contador = 3;
                }
            }
        }

        public static void AtualizarCartas(List<Jogador> jogadores)
        {
            char orientacao;  

            for(int i = 0; i < jogadores.Count; i++)
            {
                orientacao = 'H';

                if (i % 2 == 0 && jogadores.Count == 4)                
                    orientacao = 'V';
                                                  
                for(int j = 0; j < jogadores[i].Deck.Count; j++)
                {
                    char naipe = jogadores[i].Deck[j].Naipe;
                    jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacao);
                    jogadores[i].Deck[j].ImagemCarta.EsconderLabel();
                }

                jogadores[i].CartaJogada.ImagemCarta.TornarInvisivel();
                jogadores[i].CartaAposta.ImagemCarta.TornarInvisivel();
            }
        }

        public void ExibirLabelNumero(int numeroCarta)
        {
            this.LblValorCarta.Text = numeroCarta.ToString();
            this.LblValorCarta.Visible = true;
        }

        public void AtualizarImagemCarta(char naipe, int contador)
        {
            char orientacao = 'H';

            if (contador % 2 == 0)
                orientacao = 'V';

            this.PnlImgNaipe.Visible = true;
            this.PnlImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacao);
        }

        public void TornarInvisivel()
        {
            this.PnlImgNaipe.Visible = false;
            this.EsconderLabel();
        }

        public void EsconderLabel()
        {
            this.LblValorCarta.Visible = false;
        }
    }
}
