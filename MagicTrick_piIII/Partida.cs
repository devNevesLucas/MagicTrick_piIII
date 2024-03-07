using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII
{
    public class Partida
    {
        int IdPartida { get; set; }
        string NomePartida { get; set; }
        string DataCriacao { get; set; }
        char Status { get; set; }


        public Partida(string linha)
        {
            /*
            this.IdPartida = Convert.ToInt32(id);
            this.NomePartida = nome;
            this.DataCriacao = dataCriacao;
            this.Status = status;
             */

        }
    }
}
