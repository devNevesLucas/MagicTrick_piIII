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

namespace MagicTrick_piIII
{
    public partial class frmMenu : Form
    {
        List<Partida> partidas = new List<Partida>();

        public frmMenu()
        {
            InitializeComponent();
        }

        private void dgvPartidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblVersao.Text = Jogo.Versao;
            dgvPartidas.DataSource = this.partidas;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblVersao_Click(object sender, EventArgs e)
        {

        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            string result = Jogo.ListarPartidas("T");

            string[] partidasBrutas = result.Split('\n');

            List<Partida> partidasTmp = new List<Partida>();

            foreach(string partida in partidasBrutas)
                if(partida.Length > 0)
                    partidasTmp.Add(new Partida(partida));

            this.partidas = partidasTmp;
            dgvPartidas.DataSource = partidasTmp;
        }

        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaSelecionada = e.RowIndex;

            Partida partidaSelecionada = this.partidas[linhaSelecionada];
            int idPartida = partidaSelecionada.IdPartida;
            
            string result = Jogo.ListarJogadores(idPartida);

            string[] jogadoresBrutos = result.Split('\n');

            List<Jogador> jogadoresTmp = new List<Jogador>();
            foreach (string jogador in jogadoresBrutos)
                if (jogador.Length > 0)
                    jogadoresTmp.Add(new Jogador(jogador));

            dgvJogadores.DataSource = jogadoresTmp;
        }
    }
}
