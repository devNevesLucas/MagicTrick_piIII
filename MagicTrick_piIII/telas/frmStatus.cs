using MagicTrick_piIII.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII.Telas
{
    public partial class frmStatus : Form
    {
        private Dictionary<char, Bitmap> NaipeRodada = new Dictionary<char, Bitmap>
        {
            {'C', Properties.Resources.coracaoNaipe },
            {'E', Properties.Resources.espadasNaipe },
            {'S', Properties.Resources.estrelasNaipe },
            {'L', Properties.Resources.luaNaipe },
            {'O', Properties.Resources.ourosNaipe },
            {'P', Properties.Resources.pausNaipe },
            {'T', Properties.Resources.trianguloNaipe }
        };

        public frmStatus()
        {
            InitializeComponent();

            string[] nomesDeLuxemburgo =
            {
                "Luxembot", "botBurgo", "Luxemburgo-2000", "LuxemburgoAI", "byteBurgo", "CyberBurgo", 
                "LuxemMech", "Mechburgo", "LuxemburgoTron", "Unit-Luxemburgo", "LUX3MBURG0", 
                "Serial-Luxemburgo", "aimBurgo", "BeepBeepBurgo", "Prototype Luxemburgo", 
                "(ERROR: 'Name divided by zero')", "Luxemburgo totalmente não tribulado"
            };

            Random random = new Random();

            int posicaoEscolhida = random.Next(0, nomesDeLuxemburgo.Count());

            string nomeEscolhido = nomesDeLuxemburgo[posicaoEscolhida];

            Text += nomeEscolhido;
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {

        }

        public void LimparStatus()
        {
            pnlNaipe.Visible = false;
            pnlReserva1.Visible = false;
            pnlReserva2.Visible = false;
            pnlCartaCampea.Visible = false;

            lblEstrategia.Text = " ";
        }

        public void AtualizarNaipeRodada(char? naipe)
        {
            if (naipe != null)
            {
                pnlNaipe.Visible = true;
                pnlNaipe.BackgroundImage = NaipeRodada[(char)naipe];
            }
            else
                pnlNaipe.Visible = false;
        }

        public void AtualizarEstrategia(string estrategia)
        {
            lblEstrategia.Text = estrategia;
        }

        public void AtualizarCartaCampea(CartaComValor carta)
        {
            if (carta != null)
            {
                string valor = carta.ValorReal.ToString();
                char naipe = carta.Naipe;
                Bitmap imagemCarta = ImagemCarta.RetornarNaipeDescobertoBitmap(naipe, Enums.Orientacao.Vertical);

                pnlCartaCampea.BackgroundImage = imagemCarta;
                lblCartaCampea.Text = valor;
                lblCartaCampea.BackColor = Color.Transparent;
                pnlCartaCampea.Visible = true;
            }
            else
                pnlCartaCampea.Visible = false;
        }

        public void AtualizarCartasReservadas(CartaJogador cartaReserva1, CartaJogador cartaReserva2)
        {
            string valor;
            char naipe;
            Bitmap imagemCarta;

            if (cartaReserva1 != null)
            {
                valor = cartaReserva1.ValorReal.ToString();
                naipe = cartaReserva1.Naipe;
                imagemCarta = ImagemCarta.RetornarNaipeDescobertoBitmap(naipe, Enums.Orientacao.Vertical);

                pnlReserva1.BackgroundImage = imagemCarta;
                lblReserva1.Text = valor;
                pnlReserva1.Visible = true;
                lblReserva1.BackColor = Color.Transparent;
            }
            else
                pnlReserva1.Visible = false;

            if (cartaReserva2 != null)
            {
                valor = cartaReserva2.ValorReal.ToString();
                naipe = cartaReserva2.Naipe;
                imagemCarta = ImagemCarta.RetornarNaipeDescobertoBitmap(naipe, Enums.Orientacao.Vertical);

                pnlReserva2.BackgroundImage = imagemCarta;
                lblReserva2.Text = valor;
                pnlReserva2.Visible = true;
                lblReserva2.BackColor = Color.Transparent;
            }
            else
                pnlReserva2.Visible = false;
        }
    }
}
