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
        Automato Automato;
        bool CartasImpressas = false;
        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Jogadores = adversarios;
            this.Jogadores.Add(player);
            this.Player = player;

            this.Automato = new Automato(this.Player);

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

        private void AtualizarStatus(DadosVerificacao dadosVerificacao)
        {
            
            if(this.Partida.Round == 1 && this.Partida.Rodada == 1)
                AtualizarDataGridView();
          
            this.Partida.Status = dadosVerificacao.StatusPartida;

            int idRetornado = dadosVerificacao.IdJogador;

            Jogador jogadorTmp;

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);

            int rodadaAtual = dadosVerificacao.RodadaAtual;
           
            if (this.Partida.Rodada > rodadaAtual)
            {
                this.CartasImpressas = false;
                this.Partida.Round++;
            }

            this.Partida.Rodada = rodadaAtual;

            string nomeJogador = jogadorTmp.Nome;
            string tipoJogada = "Jogar carta";

            char statusRodada = dadosVerificacao.StatusRodada;
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

        private bool HandleVerificarVez()
        {
            int idPartida = this.Partida.IdPartida;
            int idJogador = this.Player.IdJogador;

            bool flagNovaRodada = false;

            DadosVerificacao verificacao = DadosVerificacao.RetornarDadosVerificacao(idPartida);

            if (verificacao == null)
            {                
                AtualizarDataGridView();
                return false;
            }

            if (this.Partida.Rodada != verificacao.RodadaAtual)
            {
                Jogador.EsconderCartasJogadas(this.Jogadores);
                flagNovaRodada = true;
            }

            AtualizarStatus(verificacao);

            if (!this.CartasImpressas)
            {
                if(this.Partida.Round == 1)
                {                    
                    AtualizarDataGridView();
                    Jogador.OrganizarJogadores(ref this.Jogadores, idJogador);
                }
                ConsultarMao();

                this.CartasImpressas = true;
                flagNovaRodada = false;                
            }

            Jogador.AtualizarJogadas(this.Jogadores, verificacao);

            if (flagNovaRodada)
                Jogador.VerificarHistorico(this.Jogadores, this.Partida);
            
            this.Partida.NaipeRodada = verificacao.NaipeRodada;

            if (verificacao.IdJogador == this.Player.IdJogador)
                return true;

            else
                return false;
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
            } 
            else
            {               
                string retorno = Jogo.Apostar(idJogador, senha, indexSelecao);

                if (Auxiliar.VerificarErro(retorno))
                    return;
            }
        }

        private bool Jogar(int posicao)
        {
            int idJogador = this.Player.IdJogador;
            string senha = this.Player.Senha;

            if (this.Partida.StatusRodada == 'C')
            {
                string retorno = Jogo.Jogar(idJogador, senha, posicao);

                if (Auxiliar.VerificarErro(retorno))
                    return false;
            }
            else
            {
                string retorno = Jogo.Apostar(idJogador, senha, posicao);

                if (Auxiliar.VerificarErro(retorno))
                    return false;
            }

            return true;
        }

        private void tmrAtualizarEstado_Tick(object sender, EventArgs e)
        {
            int posicao;
            tmrAtualizarEstado.Enabled = false;

            bool vezDoPlayer = HandleVerificarVez();

            if (vezDoPlayer)
            {
                posicao = this.Automato.JogarPrimeiraCartaPossivel(this.Partida.NaipeRodada);
                this.Jogar(posicao);
            }                                                   
            tmrAtualizarEstado.Enabled = true;
        }
    }
}