using MagicTrick_piIII.classes;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII
{
    /*
        Classe criada com o objetivo de conter métodos e trechos de código que podem ser
        reutilizados em mais de um arquivo ou local.
    */
    public class Auxiliar
    {
        /*         
            Método para verificação de erros, recebe o retorno de métodos do jogo,
            verifica se a string contém a palavra 'ERRO', caso contenha, exibe uma 
            mensagem de erro e retorna true, caso contrário, retorna false.
         */
        public static bool VerificaErro(string texto)
        {

            if (texto.StartsWith("ERRO"))
            {
                MessageBox.Show(texto, "Houve um erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        /*
            Retorna jogadores numa partida,
            recebe por parametro o id da partida.
         */
        public static List<Jogador> RetornaJogadoresPartida(int idPartida)
        {
            List<Jogador> jogadoresTmp = new List<Jogador>();

            string result = Jogo.ListarJogadores(idPartida);

            if (!VerificaErro(result))
            {
                string[] jogadoresBrutos = result.Split('\n');

                foreach (string jogador in jogadoresBrutos)
                    if (jogador.Length > 0)
                        jogadoresTmp.Add(new Jogador(jogador));
            }

            return jogadoresTmp;
        }

        /*
            Retorna imagem do naipe, para ser utilizado nas partidas. 
            Recebe como parametro o naipe da carta, como char.
         */
        public static Bitmap RetornaNaipeBitmap(char naipe)
        {
            switch(naipe)
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
        }

        /*
            Crias os panels das cartas, para posteriormente serem impressos em tela
            Recebe como parâmetro: o deck de cartas, sendo usado para buscar os bitmaps
            dos naipes; A posição X e Y iniciais do deck; E, um char posicao, que receberá
            'H' ou 'V', para horizontal e vertical, indicando se as cartas devem ser impressas
            nas laterais esquerda e direita da tela, como verticais, ou, nos cantos superior e inferior
            da tela, sendo horizontais.
         */
        public static List<Panel> CriaPanels(List<Carta> deck, int xInicial, int yInicial, char posicao)
        {
            List<Panel> panels = new List<Panel>();

            int altura = 56;
            int largura = 38;
            int panelMargin = 10;

            if(posicao == 'V')
            {
                altura = 38;
                largura = 56;
            }

            for(int i = 0; i < deck.Count; i++)
            {
                int x = xInicial;
                int y = yInicial;

                if(posicao == 'H')
                {
                    int j;

                    if(i < 7)               
                        j = i;
                    
                    else
                    {
                        j = i - 7;                      
                        y += altura + panelMargin;
                    }

                    x += largura * j;
                    x += panelMargin * j;
                }
                else
                {
                    int j;

                    if(i < 7)                    
                        j = i;

                    else
                    {
                        j = i - 7;
                        x += largura + panelMargin;
                    }

                    y += largura * j;
                    y += panelMargin * j;
                }

                Panel panel = new Panel();

                panel.Height = altura;
                panel.Width = largura;
                panel.Location = new Point(x, y);

                panel.BackgroundImage = RetornaNaipeBitmap(deck[i].Naipe);
                panels.Add(panel);
            }
            return panels;
        }
    }
}
