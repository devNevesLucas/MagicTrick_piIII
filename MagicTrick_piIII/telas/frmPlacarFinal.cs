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

        public frmPlacarFinal(int idPartida, char status)
        {
            InitializeComponent();

            this.Jogadores = Jogador.RetornarJogadoresPartida(idPartida);
            this.Jogadores = this.Jogadores.OrderByDescending(j => j.Pontuacao).ToList();

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

            dgvJogadores.Columns[0].Visible = false;
            dgvJogadores.Columns[3].Visible = false;
            dgvJogadores.Columns[4].Visible = false;
            dgvJogadores.Columns[5].Visible = false;
            dgvJogadores.Columns[6].Visible = false;
            dgvJogadores.Columns[7].Visible = false;
        }

        private void btnFecharPartida_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
