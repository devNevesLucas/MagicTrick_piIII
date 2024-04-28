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
using System.Windows.Forms.VisualStyles;

namespace MagicTrick_piIII.telas
{
    public partial class frmEntrarPartida : Form
    {
        public Partida Partida;
        public List<Jogador> JogadoresPartida;

        public frmEntrarPartida(Partida partida, List<Jogador> jogadores)
        {
            InitializeComponent();
            this.Partida = partida;
            this.JogadoresPartida = jogadores;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nomeJogador = txtNomeJogador.Text;
            string senhaPartida = txtSenha.Text;
            int idPartida = this.Partida.IdPartida;
            string retorno;  
                
            try
            {

                retorno = Jogo.EntrarPartida(idPartida, nomeJogador, senhaPartida);

            }   catch(Exception exception)
            {
                MessageBox.Show("Ops...", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            if (Auxiliar.VerificarErro(retorno))
                return;

            int posicaoCR = retorno.IndexOf('\r');
            retorno = retorno.Remove(posicaoCR, 2);
            string[] dados = retorno.Split(',');

            int idJogador = Convert.ToInt32(dados[0]);
            string senhaJogador = dados[1];

            Jogador jogador = new Jogador(idJogador, nomeJogador, senhaJogador);

            frmPartida frmPartida = new frmPartida(this.Partida, this.JogadoresPartida, jogador);
            frmPartida.Show();

            this.Close();
        }
    }
}
