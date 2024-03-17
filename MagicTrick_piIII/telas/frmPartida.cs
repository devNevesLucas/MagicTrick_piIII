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

        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Jogadores = adversarios;
            this.Player = player;

            this.Jogadores.Add(Player);
            dgvJogadores.DataSource = this.Jogadores;

            char status = this.Partida.Status;

            if(status != 'A')
                btnIniciarPartida.Enabled = false;

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

            int idRetornado = Convert.ToInt32(retorno);

            Jogador jogadorTmp = Jogadores.Find(j => j.IdJogador == idRetornado);

            string nomeJogadorTmp = jogadorTmp.Nome;
            int idJogadorTmp = jogadorTmp.IdJogador;

            string statusNovo = $"Vez do jogador: {nomeJogadorTmp}   -   ID: {idJogadorTmp}";

            lblStatusPartida.Text = statusNovo;
        }
    }
}
