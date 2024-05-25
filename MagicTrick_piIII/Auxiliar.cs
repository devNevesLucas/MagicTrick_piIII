using MagicTrick_piIII.classes;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII
{
    /*
        Classe criada com o objetivo de conter métodos e trechos de código que podem ser
        reutilizados em mais de um arquivo ou local.
    */
    public class Auxiliar
    {
        public static Font fontePrincipal = new Font("Microsoft YaHei", 10, FontStyle.Bold);

        /*         
            Método para verificação de erros, recebe o retorno de métodos do jogo,
            verifica se a string contém a palavra 'ERRO', caso contenha, exibe uma 
            mensagem de erro e retorna true, caso contrário, retorna false.
         */
        public static bool VerificarErro(string texto)
        {

            if (texto.StartsWith("ERRO"))
            {
                MessageBox.Show(texto, "Houve um erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
