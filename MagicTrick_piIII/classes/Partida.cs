using MagicTrick_piIII.classes;
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
        public string Senha { get; set; }
        public int Rodada { get ; set; }   
        public char? NaipeRodada { get; set; }   
        public char StatusRodada { get; set; } 
        public int Round { get; set; }
        public string DataCriacao { get; set; }
        public char Status { get; set; }
        public DadosVerificacao DadosRodada { get; set; }

        public Partida(string linha)
        {
            string[] dados = linha.Split(',');

            int posicaoCr = dados[3].IndexOf('\r');
            dados[3] = dados[3].Remove(posicaoCr, 1);

            this.IdPartida = Convert.ToInt32(dados[0]);
            this.NomePartida = dados[1];
            this.DataCriacao = dados[2];
            this.Status = Convert.ToChar(dados[3]);

            this.Rodada = 1;
            this.Round = 1;
        }

        public Partida(int id, string nome, string data, char status) {
            this.IdPartida = id;
            this.NomePartida = nome;
            this.DataCriacao = data;
            this.Status = status;
        }
    }
}
