using MagicTrick_piIII.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII
{
    public class Jogador
    {
        public int IdJogador { get; set; }  
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public List<Carta> Deck { get; set; }
        public int ValorAposta { get; set; }
        public char[] NaipeVitorias { get; set; }


        public Jogador(string linha)
        {
            string[] dados = linha.Split(',');

            int posicaoCR = dados[2].IndexOf('\r');         
            dados[2] = dados[2].Remove(posicaoCR, 1);

            this.IdJogador = Convert.ToInt32(dados[0]);
            this.Nome = dados[1];
            this.Pontuacao = Convert.ToInt32(dados[2]);
        }
    }
}
