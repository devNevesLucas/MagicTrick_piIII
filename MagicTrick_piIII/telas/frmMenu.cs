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

            dgvPartidas.DataSource = partidasTmp;
        }
    }
}
