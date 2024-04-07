﻿using MagicTrick_piIII.classes;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick_piIII
{
    public class Jogador
    {
        public int IdJogador { get; set; }  
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public List<Carta> Deck { get; set; }
        public Carta CartaJogada { get; set; }
        public Carta CartaAposta { get; set; }
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

        public static void OrganizarJogadores(List<Jogador> jogadores, int idPlayer)
        {
            List<Jogador> jogadoresTmp = new List<Jogador>();

            int indexPlayer = jogadores.FindIndex(j => j.IdJogador == idPlayer);
            int contador = indexPlayer + 1;

            int qtdJogadores = jogadores.Count();
            int posicao;

            for(int i = 0; i < qtdJogadores - 1; i++)
            {
                posicao = contador++ % qtdJogadores;
                jogadoresTmp.Add(jogadores[posicao]);
            }

            jogadoresTmp.Add(jogadores[indexPlayer]);

            jogadores = jogadoresTmp;
        }

        public static void PreencherDeck(List<Jogador> jogadores, List<CartasConsulta> decks, Control.ControlCollection controle)
        {
            int idJogador;
            CartasConsulta deckJogador;
            char naipe;

            for(int i = 0; i < jogadores.Count; i++)
            {
                idJogador = jogadores[i].IdJogador;
                deckJogador = decks.Find(c => c.IdJogador == idJogador);

                if (deckJogador == null) continue;

                for(int j = 0; j < deckJogador.NaipeCartas.Count; j++)
                {
                    naipe = deckJogador.NaipeCartas[j];
                    jogadores[i].Deck.Add(new Carta(naipe));
                }

                jogadores[i].CartaJogada = new Carta('C');
                jogadores[i].CartaAposta = new Carta('C');
            }
                ImagemCarta.CriarImagemCartas(jogadores, controle);
        }

        public static void AtualizarDeck(List<Jogador> jogadores, List<CartasConsulta> decks)
        {
            int idJogador;
            CartasConsulta deckJogador;
            char naipe;

            for(int i = 0; i < jogadores.Count; i++)
            {
                idJogador = jogadores[i].IdJogador;
                deckJogador = decks.Find(d => d.IdJogador == idJogador);

                if (deckJogador == null) continue;

                for(int j = 0; j < deckJogador.NaipeCartas.Count; j++)
                {
                    naipe = deckJogador.NaipeCartas[j];
                    jogadores[i].Deck[j].ResetarCarta(naipe);
                }
            }
            ImagemCarta.AtualizarCartas(jogadores);
        }

        public static void EsconderCartas(List<Jogador> jogadores)
        {
            for(int i = 0; i < jogadores.Count; i++)
            {
                jogadores[i].CartaJogada.ImagemCarta.TornarInvisivel();
                jogadores[i].CartaAposta.ImagemCarta.TornarInvisivel();
            }
        }
    }
}
