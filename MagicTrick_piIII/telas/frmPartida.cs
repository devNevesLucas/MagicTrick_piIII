using MagicTrick_piIII.classes;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.telas
{
    public partial class frmPartida : Form
    {
        List<Jogador> Jogadores = new List<Jogador>();
        Jogador Player;
        Partida Partida;
        bool CartasImpressas = false;

        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Jogadores = adversarios;
            this.Jogadores.Add(player);
            this.Player = player;
           
            AtualizarDataGridView();
                               
            lblVersao.Text += Jogo.Versao;
        }

        private void AtualizarDataGridView()
        {
            int idPartida = this.Partida.IdPartida;
            int idJogador = this.Player.IdJogador;

            List<Jogador> jogadoresTmp = Jogador.RetornarJogadoresPartida(idPartida);

            List<Jogador> jogadoresDgv = jogadoresTmp.ToList();         

            if(this.Jogadores.Count != jogadoresTmp.Count)
            {
                this.Jogadores = jogadoresTmp;
                int indexJogador = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);
                this.Jogadores[indexJogador] = this.Player;
            }
          
            dgvJogadores.DataSource = jogadoresDgv;

            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;
            dgvJogadores.Columns[5].Visible = false;
        }

        private void AtualizarStatus(string status)
        {

            if(this.Partida.Round == 1 && this.Partida.Rodada == 1)
                AtualizarDataGridView();

            string[] dadosPartida = status.Split(',');

            this.Partida.Status = Convert.ToChar(dadosPartida[0]);

            int idRetornado = Convert.ToInt32(dadosPartida[1]);
            Jogador jogadorTmp;

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);


            int rodadaAtual = Convert.ToInt32(dadosPartida[2]);

           
            if (this.Partida.Rodada > rodadaAtual)
            {
                this.CartasImpressas = false;
                this.Partida.Round++;
            }

            this.Partida.Rodada = rodadaAtual;

            string nomeJogador = jogadorTmp.Nome;
            string tipoJogada = "Jogar carta";

            char statusRodada = Convert.ToChar(dadosPartida[3]);
            this.Partida.StatusRodada = statusRodada;

            if (statusRodada == 'A')
                tipoJogada = "Apostar";

            string statusNovo = $"Vez do jogador: {nomeJogador}   -   ID: {idRetornado} : {tipoJogada}";
            lblStatusPartida.Text = statusNovo;
        }

        private void ConsultarMao()
        {
            int idPartida = this.Partida.IdPartida;

            List<CartasConsulta> cartas = CartasConsulta.HandleConsultarMao(idPartida);

            Control.ControlCollection controle = this.Controls;

            if (this.Partida.Round == 1)
                Jogador.PreencherDeck(this.Jogadores, cartas, controle);

            else
                Jogador.AtualizarDeck(this.Jogadores, cartas);
        }


        private void HandleVerificarVez()
        {
            int idPartida = this.Partida.IdPartida;
            int idJogador = this.Player.IdJogador;

            string retornoVerificacao = Jogo.VerificarVez(idPartida);

            List<Jogador> jogadoresPartida = new List<Jogador>();

            if (retornoVerificacao.StartsWith("ERRO"))
            {                
                AtualizarDataGridView();
                return;
            }

            retornoVerificacao = retornoVerificacao.Replace("\r", "");

            string[] dadosVerificacao = retornoVerificacao.Split('\n');

            string dadosPartida = dadosVerificacao[0];
            AtualizarStatus(dadosPartida);

            if (!this.CartasImpressas)
            {
                if(this.Partida.Round == 1)
                {                    
                    AtualizarDataGridView();
                    Jogador.OrganizarJogadores(ref this.Jogadores, idJogador);
                }
                ConsultarMao();

                this.CartasImpressas = true;
            }

            dadosVerificacao = dadosVerificacao.Skip(1).ToArray();

            Jogador.EsconderCartas(this.Jogadores);

            if (dadosVerificacao.Length == 0)
                return;

            string[] dadosJogada;
            char naipe;
            int numeroCarta;
            bool flagCarta; 

            Jogador jogadorAtual;
            int indexJogador;

            int contador;

            for(int i = 0; i < dadosVerificacao.Length; i++)
            {
                if (dadosVerificacao[i].Length == 0) continue;

                if (dadosVerificacao[i].StartsWith("C"))
                {
                    dadosVerificacao[i] = dadosVerificacao[i].Replace("C:", "");
                    flagCarta = true;
                }
                else
                {
                    dadosVerificacao[i] = dadosVerificacao[i].Replace("A:", "");
                    flagCarta = false;
                }

                dadosJogada = dadosVerificacao[i].Split(',');
                idJogador = Convert.ToInt32(dadosJogada[0]);
                naipe = Convert.ToChar(dadosJogada[1]);
                numeroCarta = Convert.ToInt32(dadosJogada[2]);

                jogadorAtual = this.Jogadores.Find(j => j.IdJogador == idJogador);
                indexJogador = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);

                if (this.Jogadores.Count == 4)
                {
                    if (flagCarta)
                        jogadorAtual.CartaJogada.AtualizarCarta(naipe, numeroCarta, indexJogador);

                    else
                        jogadorAtual.CartaAposta.AtualizarCarta(naipe, numeroCarta, indexJogador);
                }
                else
                {
                    if (jogadorAtual == this.Player)
                        contador = 3;

                    else
                        contador = 1;

                    if (flagCarta)
                        jogadorAtual.CartaJogada.AtualizarCarta(naipe, numeroCarta, contador);

                    else
                        jogadorAtual.CartaAposta.AtualizarCarta(naipe, numeroCarta, contador);
                }              
            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            int idJogador = this.Player.IdJogador;
            string senhaJogador = this.Player.Senha;

            string retorno = Jogo.IniciarPartida(idJogador, senhaJogador);

            if (Auxiliar.VerificarErro(retorno))
                return;

            btnIniciarPartida.Enabled = false;
            this.Partida.Status = 'J';

            int idRetornado = Convert.ToInt32(retorno);

            Jogador jogadorTmp;

            int idPartida = this.Partida.IdPartida;
            this.Jogadores = Jogador.RetornarJogadoresPartida(idPartida);

            int indexPlayer = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);

            this.Jogadores[indexPlayer] = this.Player;

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else                
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);


            if (jogadorTmp == null)
                return;

            string nomeJogadorTmp = jogadorTmp.Nome;
            int idJogadorTmp = jogadorTmp.IdJogador;

            string statusNovo = $"Vez do jogador: {nomeJogadorTmp}   -   ID: {idJogadorTmp} : Jogar Carta";

            lblStatusPartida.Text = statusNovo;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            HandleVerificarVez();
        }  

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int idJogador = this.Player.IdJogador;
            string senha = this.Player.Senha;

            int indexSelecao;

            if (!int.TryParse(txtCarta.Text, out indexSelecao))
                return;

            if(this.Partida.StatusRodada == 'C')
            {
                string retorno = Jogo.Jogar(idJogador, senha, indexSelecao);

                if (Auxiliar.VerificarErro(retorno))
                    return;

                int id = this.Jogadores[0].IdJogador;

                int numeroRetornado = Convert.ToInt32(retorno);
                this.Player.Deck[indexSelecao - 1].TornarIndisponivel(numeroRetornado);
            }
            else
            {               
                string retorno = Jogo.Apostar(idJogador, senha, indexSelecao);

                if (Auxiliar.VerificarErro(retorno))
                    return;

                if (indexSelecao == 0) return;

                int numeroRetornado = Convert.ToInt32(retorno);
                this.Player.Deck[indexSelecao - 1].TornarIndisponivel(numeroRetornado);
            }
        }
    }
}
