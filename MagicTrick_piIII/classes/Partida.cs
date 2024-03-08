using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public string NomePartida { get; set; }
        public string DataCriacao { get; set; }
        public char Status { get; set; }

        public Partida(string linha)
        {
            string[] dados = linha.Split(',');    
            dados[3] = dados[3].Remove(1, 1);

            this.IdPartida = Convert.ToInt32(dados[0]);
            this.NomePartida = dados[1];
            this.DataCriacao = dados[2];
            this.Status = Convert.ToChar(dados[3]);    
        }
    }
}
