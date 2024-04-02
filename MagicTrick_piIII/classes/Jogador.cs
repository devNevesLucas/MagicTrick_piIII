using MagicTrick_piIII.classes;
using MagicTrickServer;
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
        public List<char> NaipeVitorias { get; set; }
        public string Senha { get; set; }

        public Jogador(string linha)
        {
            string[] dados = linha.Split(',');

            int posicaoCR = dados[2].IndexOf('\r');         
            dados[2] = dados[2].Remove(posicaoCR, 1);

            this.IdJogador = Convert.ToInt32(dados[0]);
            this.Nome = dados[1];
            this.Pontuacao = Convert.ToInt32(dados[2]);

            this.Deck = new List<Carta>();
            this.NaipeVitorias = new List<char>();
        }
        
        public Jogador(int idJogador, string nome, string senha)
        {
            this.IdJogador = idJogador;
            this.Nome = nome;
            this.Senha = senha;
            this.Pontuacao = 0;

            this.Deck = new List<Carta>();
            this.NaipeVitorias = new List<char>();
        }

        public static List<Jogador> RetornarJogadoresPartida(int idPartida)
        {
            List<Jogador> jogadoresTmp = new List<Jogador>();

            string result = Jogo.ListarJogadores(idPartida);

            if (!Auxiliar.VerificarErro(result))
            {
                string[] jogadoresBrutos = result.Split('\n');

                foreach (string jogador in jogadoresBrutos)
                    if (jogador.Length > 0)
                        jogadoresTmp.Add(new Jogador(jogador));
            }
            return jogadoresTmp;
        }

        public static List<Jogador> OrganizarJogadores(List<Jogador> jogadores, int idPlayer)
        {
            List<Jogador> jogadoresTmp = new List<Jogador>();

            int indexPlayer = jogadores.FindIndex(j => j.IdJogador == idPlayer);
            indexPlayer += 1;

            int posicao;

            for(int i = 0; i < 3; i++)
            {
                posicao = indexPlayer++ % 4;
                jogadoresTmp.Add(jogadores[posicao]);
            }

            return jogadoresTmp;
        }
    }
}
