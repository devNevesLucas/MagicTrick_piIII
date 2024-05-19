using MagicTrick_piIII.classes;
using MagicTrick_piIII.Interfaces;
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

            this.Automato = new Automato(this.Player, this.Jogadores);

            AtualizarListaDeJogadores();
                               
            lblVersao.Text += Jogo.Versao;
        }

        private void AtualizarListaDeJogadores()
        {
            int idPartida = this.Partida.IdPartida;
            int idJogador = this.Player.IdJogador;

            List<Jogador> jogadoresTmp = Jogador.RetornarJogadoresPartida(idPartida);

            if (jogadoresTmp.Count == 0)
                return;

            if(this.Jogadores.Count != jogadoresTmp.Count)
            {
                this.Jogadores = jogadoresTmp;
                int indexJogador = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);
                this.Jogadores[indexJogador] = this.Player;
            }                   
        }

        private void AtualizarStatus(DadosVerificacao dadosVerificacao)
        {
            
            if(this.Partida.Round == 1 && this.Partida.Rodada == 1)
                AtualizarListaDeJogadores();
          
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

        private bool ConsultarMao()
        {
            int idPartida = this.Partida.IdPartida;

            BaralhoConsulta cartas = BaralhoConsulta.HandleConsultarMao(idPartida);

            if (cartas.Baralho.Count == 0)
                return false;

            Control.ControlCollection controle = this.Controls;

            if (this.Partida.Round == 1)
            {
                Jogador.PreencherDeck(this.Jogadores, cartas, controle);
                this.Automato.InicializarDecks(ref this.Jogadores);
            }

            else
            {
                Jogador.AtualizarDeck(this.Jogadores, cartas);
                this.Automato.ReiniciarDecks(ref this.Jogadores);
            }

            return true;
        }

        private bool HandleVerificarVez()
        {
            int idPartida = this.Partida.IdPartida;
            int idJogador = this.Player.IdJogador;

            bool flagNovaRodada = false;

            DadosVerificacao verificacao = DadosVerificacao.RetornarDadosVerificacao(idPartida);

            this.Partida.DadosRodada = verificacao;

            if (verificacao == null)
            {                
                AtualizarListaDeJogadores();
                return false;
            }

            BaralhoVerificacao cartasRodada = verificacao.CartasRodada;

            //Verificações que demonstram que a partida finalizou:
            if (verificacao.StatusPartida == 'E' || verificacao.StatusPartida == 'F')
            {
                this.Partida.Status = verificacao.StatusPartida;

                this.ExibirPlacarFinal(verificacao.StatusPartida);
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
                    AtualizarListaDeJogadores();
                    Jogador.OrganizarJogadores(ref this.Jogadores, idJogador);
                }

                if (!ConsultarMao())
                    return false;

                this.CartasImpressas = true;
                flagNovaRodada = false;                
            }

            Jogador.AtualizarJogadas(this.Jogadores, verificacao, this.Automato, this.Controls);

            if (flagNovaRodada)
                Jogador.VerificarHistorico(this.Jogadores, this.Partida, this.Automato, this.Controls);
            
            this.Partida.NaipeRodada = verificacao.NaipeRodada;

            this.Automato.LimitarCartas(cartasRodada);

            
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

        private bool Jogar(int posicao)
        {
            int idJogador = this.Player.IdJogador;
            string senha = this.Player.Senha;

            string retorno = "";

            if (this.Partida.StatusRodada == 'C')
            {
                try
                {
                    retorno = Jogo.Jogar(idJogador, senha, posicao);
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return this.Jogar(posicao);
                }

                if (Auxiliar.VerificarErro(retorno))
                    return false;
            }
            else
            {
                try
                {
                    retorno = Jogo.Apostar(idJogador, senha, posicao);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return this.Jogar(posicao);
                }

                if (Auxiliar.VerificarErro(retorno))
                    return false;
            }
            return true;
        }

        private void ExibirPlacarFinal(char statusPartida)
        {
            int idPartida = this.Partida.IdPartida;
            frmPlacarFinal placarFinal = new frmPlacarFinal(idPartida, statusPartida);

            tmrAtualizarEstado.Stop();

            placarFinal.ShowDialog();

            this.Close();
        }

        private void tmrAtualizarEstado_Tick(object sender, EventArgs e)
        {
            int posicao;
            tmrAtualizarEstado.Enabled = false;

            bool vezDoPlayer = HandleVerificarVez();

            if (vezDoPlayer)
            {
                posicao = this.Automato.RetornarPosicaoEscolhida(this.Partida.DadosRodada);
                this.Jogar(posicao);
            }                                         
            
            if(this.Partida.Status != 'F' && this.Partida.Status != 'E')
                tmrAtualizarEstado.Enabled = true;
        }       
    }
}