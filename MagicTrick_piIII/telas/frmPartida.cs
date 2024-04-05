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
        Carta Aposta = new Carta('A');
        int IndexSelecao;
        char StatusRodada;
        int Rodada;
        bool CartasImpressas = false;

        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Jogadores = adversarios;
            this.Jogadores.Add(player);
            this.Player = player;
           
            AtualizarDataGridView(adversarios);
            
            char status = this.Partida.Status;

            if(status != 'A')
                btnIniciarPartida.Enabled = false;

            this.Aposta.ValorReal = 0;

            lblVersao.Text += Jogo.Versao;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AtualizarDataGridView(List<Jogador> jogadores)
        {
            List<Jogador> jogadoresTmp = jogadores.ToList();         
                       
            dgvJogadores.DataSource = jogadoresTmp;

            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;
        }

        private void AtualizarStatus(string status)
        {
            string[] dadosPartida = status.Split(',');

            this.Partida.Status = Convert.ToChar(dadosPartida[0]);

            int idRetornado = Convert.ToInt32(dadosPartida[1]);
            Jogador jogadorTmp;

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);


            int rodadaAtual = Convert.ToInt32(dadosPartida[2]);

            if (this.Rodada > rodadaAtual)
                this.CartasImpressas = false;

            this.Rodada = rodadaAtual;

            string nomeJogador = jogadorTmp.Nome;
            string statusRodada = "Jogar carta";

            if (dadosPartida[3] == "A")
                statusRodada = "Apostar";

            string statusNovo = $"Vez do jogador: {nomeJogador}   -   ID: {idRetornado} : {statusRodada}";
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
                jogadoresPartida = Jogador.RetornarJogadoresPartida(idPartida);
                AtualizarDataGridView(jogadoresPartida);

                return;
            }

            retornoVerificacao = retornoVerificacao.Replace("\r", "");

            string[] dadosVerificacao = retornoVerificacao.Split('\n');

            string dadosPartida = dadosVerificacao[0];
            AtualizarStatus(dadosPartida);

            if (!this.CartasImpressas)
            {
                jogadoresPartida = Jogador.RetornarJogadoresPartida(idPartida);
                AtualizarDataGridView(jogadoresPartida);

                Jogador.OrganizarJogadores(jogadoresPartida, idJogador);
                ConsultarMao();

                this.CartasImpressas = true;
            }

            dadosVerificacao = dadosVerificacao.Skip(1).ToArray();

            if (dadosVerificacao.Length == 0)
                return;
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

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else                
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);

            string nomeJogadorTmp = jogadorTmp.Nome;
            int idJogadorTmp = jogadorTmp.IdJogador;

            string statusNovo = $"Vez do jogador: {nomeJogadorTmp}   -   ID: {idJogadorTmp} : Jogar Carta";

            lblStatusPartida.Text = statusNovo;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {          
            Panel panelAposta = new Panel();
            panelAposta.Width = 38;
            panelAposta.Height = 56;
            panelAposta.BackgroundImage = Properties.Resources.aposta;
            panelAposta.Location = new Point(561, 522);
            panelAposta.Click += ApostaCardPanel_Click;
        }

         private void CardPanel_Click(object sender, EventArgs e)
        {
            Panel painelClicado = sender as Panel;

            if (painelClicado == null)
                return;

            Carta cartaClicada = this.Player.Deck.Find(c => c.PanelCarta == painelClicado);

            if (cartaClicada == null)
                return;

            int indexCarta = this.Player.Deck.IndexOf(cartaClicada);

            this.IndexSelecao = indexCarta + 1;
        }

        private void ApostaCardPanel_Click(object sender, EventArgs e)
        {
            this.IndexSelecao = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int idJogador = this.Player.IdJogador;
            string senha = this.Player.Senha;

            if(this.StatusRodada == 'C')
            {
                string retorno = Jogo.Jogar(idJogador, senha, this.IndexSelecao);

                if (Auxiliar.VerificarErro(retorno))
                    return;

                lblValorCarta.Text = "Valor da carta jogada: " + retorno;
            }
            else
            {
                string retorno = Jogo.Apostar(idJogador, senha, this.IndexSelecao);

                if (Auxiliar.VerificarErro(retorno))
                    return;

                lblValorAposta.Text = "Valor da aposta: " + retorno;
            }
        }

        private void lblValorCarta_Click(object sender, EventArgs e)
        {

        }

        private void frmPartida_Load(object sender, EventArgs e)
        {

        }
    }
}
