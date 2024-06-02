using MagicTrick_piIII.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.Telas
{
    public partial class frmNarrador : Form
    {
        List<Jogador> Jogadores {  get; set; }

        private Dictionary<char, string> NaipesString = new Dictionary<char, string>
        {
            { 'C', "Copas" },
            { 'E', "Espadas" },
            { 'S', "Estrelas" },
            { 'L', "Lua" },
            { 'O', "Ouros" },
            { 'P', "Paus" },
            { 'T', "Triângulo" }
        };

        private Dictionary<char, Color> NaipeCores = new Dictionary<char, Color>
        {
            { 'C', Color.FromArgb(232, 29, 29) },
            { 'E', Color.FromArgb(132, 132, 132) },
            { 'S', Color.FromArgb(255, 199, 54) },
            { 'L', Color.FromArgb(132, 34, 255) },
            { 'O', Color.FromArgb(87, 174, 255) },
            { 'P', Color.FromArgb(2, 115, 51) },
            { 'T', Color.FromArgb(255, 108, 26) }
        };

        public frmNarrador()
        {
            InitializeComponent();
        }

        private void frmNarrador_Load(object sender, EventArgs e)
        {

        }

        public void AtualizarJogadores(List<Jogador> jogadores)
        {
            this.Jogadores = jogadores;            
            dgvJogadores.DataSource = this.Jogadores;

            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;
            dgvJogadores.Columns[5].Visible = false;
            dgvJogadores.Columns[6].Visible = false;
            dgvJogadores.Columns[7].Visible = false;
            dgvJogadores.Columns[8].Visible = false;
            dgvJogadores.Columns[9].Visible = false;
            dgvJogadores.Columns[10].Visible = false;
        }

        private void NarrarTextoColorido(string texto, char naipe)
        {
            rtbJogadas.SelectionStart = rtbJogadas.TextLength;
            rtbJogadas.SelectionLength = 0;

            rtbJogadas.SelectionColor = NaipeCores[naipe];
            rtbJogadas.AppendText(texto);
            rtbJogadas.SelectionColor = rtbJogadas.ForeColor;
        }

        public void NarrarPartidaNaoIniciada()
        {
            rtbJogadas.AppendText("Aguardando o início da partida...\r\n");
        }

        public void NarrarComecoDePartida()
        {
            rtbJogadas.AppendText("Partida iniciada!!!\r\n");
        }

        public void NarrarNovoRound(int round)
        {
            rtbJogadas.AppendText($"\nRound {round} começando agora!\r\n");
        }

        public void NarrarNovaRodada(int rodada)
        {
            rtbJogadas.AppendText($"Rodada {rodada} começando agora!\r\n");
        }

        public void NarrarCartaJogada(Jogador jogador, CartaComValor carta)
        {
            int idJogador = jogador.IdJogador;
            string nome = jogador.Nome;
            int valorCarta = carta.ValorReal;
            char naipeChar = carta.Naipe;
            string naipe = NaipesString[naipeChar];

            rtbJogadas.AppendText($"O jogador {idJogador}.{nome} jogou um");
            this.NarrarTextoColorido($" {valorCarta} ", naipeChar);
            rtbJogadas.AppendText("de");
            this.NarrarTextoColorido($" {naipe}", naipeChar);

            rtbJogadas.AppendText("!\r\n");
        }

        public void NarrarCartaApostada(Jogador jogador, CartaComValor carta)
        {
            int idJogador = jogador.IdJogador;
            string nome = jogador.Nome;
            int valorCarta = carta.ValorReal;
            char naipeChar = carta.Naipe;
            string naipe = NaipesString[naipeChar];

            rtbJogadas.AppendText($"O jogador {idJogador}.{nome} apostou um");
            this.NarrarTextoColorido($" {valorCarta} ", naipeChar);
            rtbJogadas.AppendText("de");
            this.NarrarTextoColorido($" {naipe}", naipeChar);

            rtbJogadas.AppendText("!\r\n");
        }

        public void NarrarPontuacaoCalculada(int idJogador, int diferenca)
        {
            Jogador jogador = this.Jogadores.Find(j => j.IdJogador == idJogador);
            string nome = jogador.Nome;

            if(diferenca != 0)
            {
                diferenca = diferenca * (diferenca > 0 ? -1 : 1);
                rtbJogadas.AppendText($"O jogador {idJogador}.{nome} finalizou o round com {diferenca} pontos!\r\n");
            }
            
            else            
                rtbJogadas.AppendText($"O jogador {idJogador}.{nome} acertou a sua aposta, ganhando 3 pontos!\r\n");
            
        }

        public void NarrarPrestigioGanho(int idJogador)
        {
            Jogador jogador = this.Jogadores.Find(j => j.IdJogador == idJogador);
            string nome = jogador.Nome;

            rtbJogadas.AppendText($"O jogador {idJogador}.{nome} ganhou 2 pontos de prestígio!!\r\n");
        }

        public void NarrarNovaPontuacao(Jogador jogador)
        {
            int idJogador = jogador.IdJogador;
            string nome = jogador.Nome;
            int pontos = jogador.Pontuacao;

            int index = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);
            this.Jogadores[index].Pontuacao = pontos;

            rtbJogadas.AppendText($"O jogador {idJogador}.{nome} está com {pontos} pontos!\r\n");
        }

        public void NarrarCartaDescoberta()
        {
            rtbJogadas.AppendText($"Descobri a 7ª carta do 1234.Luxemburgo... É um 5 de Paus!\r\n");
        }

        public void NarrarFimDeJogo()
        {
            rtbJogadas.AppendText("Fim de jogo!\r\n");
        }
    }
}
