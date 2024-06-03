using MagicTrick_piIII.Telas;
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
    public partial class frmPlacarFinal : Form
    {
        List<Jogador> Jogadores = new List<Jogador>();

        Jogador Vencedor;

        frmPartida Partida;
        frmNarrador Narrador;
        frmStatus StatusForm;

        public frmPlacarFinal(int idPartida, char status, frmPartida partida, frmNarrador narrador, frmStatus statusForm)
        {
            InitializeComponent();

            this.Jogadores = Jogador.RetornarJogadoresPartida(idPartida);
            this.Jogadores = this.Jogadores.OrderByDescending(j => j.Pontuacao).ToList();

            this.Partida = partida;
            this.Narrador = narrador;
            this.StatusForm = statusForm;

            if (this.Jogadores.Count == 0)
                return;

            if(status == 'F')
            {
                this.Vencedor = this.Jogadores[0];

                lblVitoria.Text = "Vitória de " + this.Vencedor.Nome;
                lblPontuacao.Text = this.Vencedor.Pontuacao.ToString() + " pontos";
            }

            else            
                lblVitoria.Text = "Houve empate!";
            
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

        private void btnFecharPartida_Click(object sender, EventArgs e)
        {
            this.Partida.Close();
            this.Narrador.Close();
            this.StatusForm.Close();

            this.Close();
        }
    }
}
