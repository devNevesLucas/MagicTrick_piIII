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

        List<Jogador> Adversarios = new List<Jogador>();
        Jogador Player;
        Partida Partida;

        public frmPartida(Partida partida, List<Jogador> adversarios, Jogador player)
        {
            InitializeComponent();

            this.Partida = partida;
            this.Adversarios = adversarios;
            this.Player = player;

            List<Jogador> jogadorTemp = adversarios;
            jogadorTemp.Add(Player);
            dgvJogadores.DataSource = jogadorTemp;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {

        }
    }
}
