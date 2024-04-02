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
    public partial class frmCriancaoPartida : Form
    {
        public frmCriancaoPartida()
        {
            InitializeComponent();
        }

        private void CriancaoPartida_Load(object sender, EventArgs e)
        {

        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            string nomePartida = txtNomePartida.Text;
            string senhaPartida = txtSenha.Text;

            if (nomePartida.Length <= 0 || senhaPartida.Length <= 0)
                return;

            string resultado = Jogo.CriarPartida(nomePartida, senhaPartida, "luxemburgo");

            if (!Auxiliar.VerificarErro(resultado))
            { 
                MessageBox.Show(
                        $"Partida Criada! :D\r\nO ID da partida foi: {resultado}",
                        "Parabéns!",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Asterisk
                    );

                this.Close();
            }
        }
    }
}
