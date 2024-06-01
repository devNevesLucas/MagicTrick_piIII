using MagicTrick_piIII.Enums;
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
        public PosicionamentoCarta Posicionamento { get; set; }
        public Orientacao OrientacaoCarta { get; set; }

        public static int[,] posicoes = new int[,] { { 43, 180 }, { 419, 85 }, { 1011, 180 }, { 419, 483 } };

        public static int[,] posicoesJogadas = new int[,] { { 498, 328 }, { 560, 275 }, { 604, 328 }, { 560, 363 } };

        public static int[,] posicoesApostas = new int[,] { { 76, 536 }, { 351, 118 }, { 1044, 117 }, { 778, 516 } };

        private static Dictionary<char, Bitmap> BitmapsBaralhoDisponivel_Vertical = new Dictionary<char, Bitmap>
        {
            { 'C' , Properties.Resources.coracao },
            { 'E' , Properties.Resources.espadas },
            { 'S' , Properties.Resources.estrelas },
            { 'L' , Properties.Resources.lua },
            { 'O' , Properties.Resources.ouros },
            { 'P' , Properties.Resources.paus },
            { 'T' , Properties.Resources.triangulo }
        };

        private static Dictionary<char, Bitmap> BitmapsBaralhoDisponivel_Horizontal = new Dictionary<char, Bitmap>
        {
            { 'C' , Properties.Resources.coracaoHorizontal },
            { 'E' , Properties.Resources.espadasHorizontal },
            { 'S' , Properties.Resources.estrelasHorizontal },
            { 'L' , Properties.Resources.luaHorizontal },
            { 'O' , Properties.Resources.ourosHorizontal },
            { 'P' , Properties.Resources.pausHorizontal },
            { 'T' , Properties.Resources.trianguloHorizontal }
        };

        private static Dictionary<char, Bitmap> BitmapsBaralhoDescoberto_Vertical = new Dictionary<char, Bitmap>
        {
            { 'C', Properties.Resources.coracaoDescoberto },
            { 'E', Properties.Resources.espadasDescoberta },
            { 'S', Properties.Resources.estrelasDescoberta },
            { 'L', Properties.Resources.luaDescoberta },
            { 'O', Properties.Resources.ourosDescoberto },
            { 'P', Properties.Resources.pausDescoberto },
            { 'T', Properties.Resources.trianguloDescoberto }
        };

        private static Dictionary<char, Bitmap> BitmapsBaralhoDescoberto_Horizontal = new Dictionary<char, Bitmap>
        {
            { 'C', Properties.Resources.coracaoDescobertoHorizontal },
            { 'E', Properties.Resources.espadasDescobertaHorizontal },
            { 'S', Properties.Resources.estrelasDescobertaHorizontal },
            { 'L', Properties.Resources.luaDescobertaHorizontal },
            { 'O', Properties.Resources.ourosDescobertoHorizontal },
            { 'P', Properties.Resources.pausDescobertoHorizontal },
            { 'T', Properties.Resources.trianguloDescobertoHorizontal }
        };

        private static Dictionary<char, Bitmap> BitmapsBaralhoIndisponivel_Vertical = new Dictionary<char, Bitmap>
        {
            { 'C' , Properties.Resources.coracaoIndisponivel },
            { 'E' , Properties.Resources.espadasIndisponivel },
            { 'S' , Properties.Resources.estrelasIndisponivel },
            { 'L' , Properties.Resources.luaIndisponivel },
            { 'O' , Properties.Resources.ourosIndisponivel },
            { 'P' , Properties.Resources.pausIndisponivel },
            { 'T' , Properties.Resources.trianguloIndisponivel }
        };

        private static Dictionary<char, Bitmap> BitmapsBaralhoIndisponivel_Horizontal = new Dictionary<char, Bitmap>
        {
            { 'C' , Properties.Resources.coracaoIndisponivelHorizontal },
            { 'E' , Properties.Resources.espadasIndisponivelHorizontal },
            { 'S' , Properties.Resources.estrelasIndisponivelHorizontal },
            { 'L' , Properties.Resources.luaIndisponivelHorizontal },
            { 'O' , Properties.Resources.ourosIndisponivelHorizontal },
            { 'P' , Properties.Resources.pausIndisponivelHorizontal },
            { 'T' , Properties.Resources.trianguloIndisponivelHorizontal }
        };

        public ImagemCarta(int x, int y, Orientacao orientacaoDeckJogador, char naipe)
        {
            if (orientacaoDeckJogador == Orientacao.Vertical)
                this.OrientacaoCarta = Orientacao.Horizontal;

            else
                this.OrientacaoCarta = Orientacao.Vertical;

            this.Posicionamento = new PosicionamentoCarta(x, y, orientacaoDeckJogador);
            this.InicializarPropriedades(orientacaoDeckJogador, naipe);
        }

        public ImagemCarta(int x, int y, Orientacao orientacaoDeckJogador, char naipe, int iterador)
        {
            if (orientacaoDeckJogador == Orientacao.Vertical)
                this.OrientacaoCarta = Orientacao.Horizontal;

            else
                this.OrientacaoCarta = Orientacao.Vertical;

            this.Posicionamento = new PosicionamentoCarta(x, y, orientacaoDeckJogador, iterador);
            this.InicializarPropriedades(orientacaoDeckJogador, naipe);
        }

        private void InicializarPropriedades(Orientacao orientacao, char naipe)
        {
            this.PnlImgNaipe = new Panel();
            this.LblValorCarta = new Label();
           
            this.PosicionarPanel();

            this.PnlImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, this.OrientacaoCarta);

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

            Point ponto = new Point(0, 0);
            ponto.X += this.Posicionamento.Largura / 2 - 14;
            ponto.Y += this.Posicionamento.Altura / 2 - 14;

            this.LblValorCarta.Location = ponto;
            this.LblValorCarta.ForeColor = Color.White;

            this.LblValorCarta.TextAlign = ContentAlignment.MiddleCenter;
            this.LblValorCarta.Font = fonteLabel;
           
            this.LblValorCarta.Size = new Size(28, 28);
            this.LblValorCarta.Visible = false;

            this.PnlImgNaipe.Controls.Add(this.LblValorCarta);
        }
       
        public static Bitmap RetornarNaipeBitmap(char naipe, Orientacao orientacaoCarta)
        {
            if (orientacaoCarta == Orientacao.Vertical)
                return BitmapsBaralhoDisponivel_Vertical[naipe];

            else
                return BitmapsBaralhoDisponivel_Horizontal[naipe];
        }

        public static Bitmap RetornarNaipeDescobertoBitmap(char naipe, Orientacao orientacaoCarta)
        {
            if (orientacaoCarta == Orientacao.Vertical)
                return BitmapsBaralhoDescoberto_Vertical[naipe];

            else
                return BitmapsBaralhoDescoberto_Horizontal[naipe];
        }

        public static Bitmap RetornarNaipeIndisponivelBitmap(char naipe, Orientacao orientacaoCarta)
        {
            if (orientacaoCarta == Orientacao.Vertical)
                return BitmapsBaralhoIndisponivel_Vertical[naipe];

            else
                return BitmapsBaralhoIndisponivel_Horizontal[naipe];
        }

        private static void TrazerParaFrente(CartaJogador carta)
        {
            carta.ImagemCarta.PnlImgNaipe.BringToFront();
            carta.ImagemCarta.LblValorCarta.BringToFront();
        }

        public static void CriarImagensCartas(List<Jogador> jogadores, Control.ControlCollection controle)
        {
            int x, y, posicaoTela, posicaoCarta;
            char naipe;
            Orientacao orientacao;
           
            for(int i = 0; i < jogadores.Count; i++)
            {                                      
                orientacao = jogadores[i].Orientacao;
                posicaoTela = (int)jogadores[i].Posicao;
                x = posicoes[posicaoTela, 0];
                y = posicoes[posicaoTela, 1];

                for (int j = 0; j < jogadores[i].Deck.Count; j++)
                {                                      
                    naipe = jogadores[i].Deck[j].Naipe;

                    posicaoCarta = jogadores[i].Deck[j].Posicao - 1;
                    jogadores[i].Deck[j].ImagemCarta = new ImagemCarta(x, y, orientacao, naipe, posicaoCarta);

                    controle.Add(jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe);                                                             
                    TrazerParaFrente(jogadores[i].Deck[j]);
                }

                x = posicoesJogadas[posicaoTela, 0];
                y = posicoesJogadas[posicaoTela, 1];

                jogadores[i].CartaJogada.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');
                    
                controle.Add(jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe);

                jogadores[i].CartaJogada.ImagemCarta.PnlImgNaipe.Visible = false;
                TrazerParaFrente(jogadores[i].CartaJogada);
                
                x = posicoesApostas[posicaoTela, 0];
                y = posicoesApostas[posicaoTela, 1];

                jogadores[i].CartaAposta.ImagemCarta = new ImagemCarta(x, y, orientacao, 'C');

                controle.Add(jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe);

                jogadores[i].CartaAposta.ImagemCarta.PnlImgNaipe.Visible = false;
                TrazerParaFrente(jogadores[i].CartaAposta);
            }           
        }

        public static void CriarImagemCarta(Jogador jogador, Control.ControlCollection controle, CartaJogador carta)
        {
            int posicaoTela = (int)jogador.Posicao;
            int x = posicoes[posicaoTela, 0];
            int y = posicoes[posicaoTela, 1];
            int posicaoCarta = carta.Posicao - 1;
            char naipe = carta.Naipe;
            Orientacao orientacao = jogador.Orientacao;

            carta.ImagemCarta = new ImagemCarta(x, y, orientacao, naipe, posicaoCarta);

            controle.Add(carta.ImagemCarta.PnlImgNaipe);
            TrazerParaFrente(carta);
        }

        public static void AtualizarCartas(List<Jogador> jogadores)
        {
            Orientacao orientacaoDeckJogador;  

            for(int i = 0; i < jogadores.Count; i++)
            {         
                orientacaoDeckJogador = jogadores[i].Deck[0].ImagemCarta.OrientacaoCarta;
             
                for(int j = 0; j < jogadores[i].Deck.Count; j++)
                {                    
                    char naipe = jogadores[i].Deck[j].Naipe;
                    jogadores[i].Deck[j].ImagemCarta.PnlImgNaipe.BackgroundImage = RetornarNaipeBitmap(naipe, orientacaoDeckJogador);
                    jogadores[i].Deck[j].ImagemCarta.EsconderLabel();
                }

                jogadores[i].CartaJogada.ImagemCarta.TornarInvisivel();
                jogadores[i].CartaAposta.ImagemCarta.TornarInvisivel();
                jogadores[i].CartaAposta.ValorReal = -1;
            }
        }

        public void AtualizarCartaIndisponivel(char naipe, int valor)
        {
            Orientacao orientacaoCarta = this.OrientacaoCarta;
           
            this.LblValorCarta.Text = valor.ToString();
            this.LblValorCarta.ForeColor = Color.White;
            this.LblValorCarta.BackColor = Color.Transparent;

            this.PnlImgNaipe.BackgroundImage = RetornarNaipeIndisponivelBitmap(naipe, orientacaoCarta);
           
            this.LblValorCarta.Visible = true;
        }

        public void AtualizarImagemCarta(char naipe)
        {           
            this.PnlImgNaipe.Visible = true;
            this.PnlImgNaipe.BackgroundImage = RetornarNaipeDescobertoBitmap(naipe, this.OrientacaoCarta);
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

        public void ExibirValorDescoberto(char naipe, int valor)
        {
            this.LblValorCarta.Text = valor.ToString();
            this.LblValorCarta.ForeColor = Color.White;
            this.LblValorCarta.BackColor = Color.Transparent;

            this.PnlImgNaipe.BackgroundImage = RetornarNaipeDescobertoBitmap(naipe, this.OrientacaoCarta);
           
            this.LblValorCarta.Visible = true;
        }
    }
}
