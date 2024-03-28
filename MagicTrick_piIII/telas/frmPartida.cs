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
        Carta Aposta = new Carta("A");
        int IndexSelecao;
        char StatusRodada;

        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Jogadores = adversarios;
            this.Player = player;

            List<Jogador> jogadoresTmp = adversarios.ToList();
            jogadoresTmp.Add(player);
            dgvJogadores.DataSource = jogadoresTmp;

            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;    

            char status = this.Partida.Status;

            if(status != 'A')
                btnIniciarPartida.Enabled = false;

            this.Aposta.ValorReal = 0;

            lblVersao.Text += Jogo.Versao;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            int idJogador = this.Player.IdJogador;
            string senhaJogador = this.Player.Senha;

            string retorno = Jogo.IniciarPartida(idJogador, senhaJogador);

            if (Auxiliar.VerificaErro(retorno))
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

            string statusNovo = $"Vez do jogador: {nomeJogadorTmp}   -   ID: {idJogadorTmp}";

            lblStatusPartida.Text = statusNovo;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int idPartida = this.Partida.IdPartida;

            string retornoVerificacao = Jogo.VerificarVez(idPartida);

            if (retornoVerificacao.StartsWith("ERRO"))
                return;

            string[] linhasVerificacao = retornoVerificacao.Split('\n');

            
            string[] dadosVerificacao = linhasVerificacao[0].Split(',');

            int indexCr = dadosVerificacao[3].IndexOf('\r');
            dadosVerificacao[3] = dadosVerificacao[3].Remove(indexCr, 1);

            Jogador jogadorTmp;

            this.Partida.Status = Convert.ToChar(dadosVerificacao[0]);

            int idRetornado = Convert.ToInt32(dadosVerificacao[1]);

            if (this.Player.IdJogador == idRetornado)
                jogadorTmp = this.Player;

            else
                jogadorTmp = this.Jogadores.Find(j => j.IdJogador == idRetornado);

            string nomeJogadorTmp = jogadorTmp.Nome;

            string statusRodada = "Jogar carta";

            if (dadosVerificacao[3] == "A")
                statusRodada = "Apostar";

            this.StatusRodada = Convert.ToChar(dadosVerificacao[3]);

            string statusNovo = $"Vez do jogador: {nomeJogadorTmp}   -   ID: {idRetornado} : {statusRodada}";
            lblStatusPartida.Text = statusNovo;


            if (this.Player.Deck.Count != 0)
                return;

            string retornoCartas = Jogo.ConsultarMao(idPartida);

            if (Auxiliar.VerificaErro(retornoCartas))
                return;

            string[] linhas = retornoCartas.Split('\n');

            foreach(string linha in linhas)
            {
                if (linha == "") continue;

                string[] dados = linha.Split(',');

                indexCr = dados[2].IndexOf('\r');
                dados[2] = dados[2].Remove(indexCr, 1);

                int idJogador = Convert.ToInt32(dados[0]);
                int indexCarta = Convert.ToInt32(dados[1]) - 1;

                if(this.Player.IdJogador == idJogador)
                    this.Player.Deck.Add(new Carta(dados[2]));
                                      
                else
                {
                    int indexJogador = this.Jogadores.FindIndex(j => j.IdJogador == idJogador);         
                    this.Jogadores[indexJogador].Deck.Add(new Carta(dados[2]));             
                }             
            }

            Panel panelAposta = new Panel();
            panelAposta.Width = 38;
            panelAposta.Height = 56;
            panelAposta.BackgroundImage = Properties.Resources.aposta;
            panelAposta.Location = new Point(561, 522);
            panelAposta.Click += ApostaCardPanel_Click;

            List<Panel> panels = new List<Panel>();           

            List<Panel> playerPanels = Auxiliar.CriaPanels(this.Player.Deck, 212, 481, 'H'); ;

            for(int i = 0; i < playerPanels.Count; i++)
            {
                this.Player.Deck[i].PanelCarta = playerPanels[i];
                playerPanels[i].Click += CardPanel_Click;
            }

            panels.AddRange(playerPanels);

            if (this.Jogadores.Count == 1)
            {
                List<Panel> panelsTmp = Auxiliar.CriaPanels(this.Jogadores[0].Deck, 212, 84,'H');
                panels.AddRange(panelsTmp);
            }

            panels.Add(panelAposta);

            foreach (Panel panel in panels)
            {
                this.Controls.Add(panel);
                panel.BringToFront();

                //Control.ControlCollection controle = this.Controls;                
                
            }

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

                if (Auxiliar.VerificaErro(retorno))
                    return;

                lblValorCarta.Text = "Valor da carta jogada: " + retorno;
            }
            else
            {
                string retorno = Jogo.Apostar(idJogador, senha, this.IndexSelecao);

                if (Auxiliar.VerificaErro(retorno))
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
