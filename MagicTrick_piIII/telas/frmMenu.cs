using MagicTrick_piIII.telas;
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
        
        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblVersao.Text += Jogo.Versao;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            string result = Jogo.ListarPartidas("T");

            if (Auxiliar.VerificaErro(result))
                return;

            string[] partidasBrutas = result.Split('\n');

            List<Partida> partidasTmp = new List<Partida>();

            foreach(string partida in partidasBrutas)
                if(partida.Length > 0)
                    partidasTmp.Add(new Partida(partida));

            this.partidas = partidasTmp;
            dgvPartidas.DataSource = partidasTmp;

            dgvPartidas.Columns.Remove("Round");
            dgvPartidas.Columns.Remove("Senha");
        }

        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaSelecionada = e.RowIndex;

            if (linhaSelecionada < 0)
                return;

            Partida partidaSelecionada = this.partidas[linhaSelecionada];
            int idPartida = partidaSelecionada.IdPartida;
            
            string result = Jogo.ListarJogadores(idPartida);

            if (Auxiliar.VerificaErro(result))
                return;

            string[] jogadoresBrutos = result.Split('\n');

            List<Jogador> jogadoresTmp = new List<Jogador>();
            foreach (string jogador in jogadoresBrutos)
                if (jogador.Length > 0)
                    jogadoresTmp.Add(new Jogador(jogador));

            dgvJogadores.DataSource = jogadoresTmp;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            frmCriancaoPartida frmNovaPartida = new frmCriancaoPartida();
            frmNovaPartida.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }
    }
}
