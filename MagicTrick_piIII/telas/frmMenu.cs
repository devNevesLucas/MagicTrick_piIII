using MagicTrick_piIII.telas;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII
{
    public partial class frmMenu : Form
    {
        List<Partida> Partidas = new List<Partida>();
        Partida PartidaSelecionada = null;
        List<Jogador> JogadoresPartidaSelecionada = new List<Jogador>();

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
            if (Application.OpenForms["Form1"] != null)
            {
                Form1 inicio = (Form1)Application.OpenForms["Form1"];
                inicio.Show();
            }
            else
            {
                Form1 inicio = new Form1();
                inicio.Show();
            }

            this.Close();
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            string result; 

            try
            {

                result = Jogo.ListarPartidas("T");

            } catch(Exception exception)
            {
                MessageBox.Show("Ops...", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Auxiliar.VerificarErro(result))
                return;

            string[] partidasBrutas = result.Split('\n');

            List<Partida> partidasTmp = new List<Partida>();

            foreach(string partida in partidasBrutas)
                if(partida.Length > 0)
                    partidasTmp.Add(new Partida(partida));

            this.Partidas = partidasTmp;
            dgvPartidas.DataSource = partidasTmp;

            dgvPartidas.Columns.Remove("Round");
            dgvPartidas.Columns.Remove("Senha");
            dgvPartidas.Columns.Remove("NaipeRodada");
            dgvPartidas.Columns.Remove("StatusRodada");
            dgvPartidas.Columns.Remove("DadosRodada");
        }

        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaSelecionada = e.RowIndex;

            if (linhaSelecionada < 0)
                return;

            this.PartidaSelecionada = this.Partidas[linhaSelecionada];

            int idPartida = this.PartidaSelecionada.IdPartida;
                  
            List<Jogador> jogadoresTmp = Jogador.RetornarJogadoresPartida(idPartida);
            dgvJogadores.DataSource = jogadoresTmp;
            this.JogadoresPartidaSelecionada = jogadoresTmp;

            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;
            dgvJogadores.Columns[5].Visible = false;
            dgvJogadores.Columns[6].Visible = false;
            dgvJogadores.Columns[7].Visible = false;
            dgvJogadores.Columns[8].Visible = false;
            dgvJogadores.Columns[9].Visible = false;
            dgvJogadores.Columns[10].Visible = false;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            frmCriancaoPartida frmNovaPartida = new frmCriancaoPartida();
            frmNovaPartida.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            frmEntrarPartida frmPartida = new frmEntrarPartida(this.PartidaSelecionada, this.JogadoresPartidaSelecionada);
            frmPartida.Show();
        }

        private void dgvJogadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
