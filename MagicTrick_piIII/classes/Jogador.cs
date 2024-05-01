﻿using MagicTrick_piIII.classes;
using MagicTrick_piIII.Enums;
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
        public List<Ponto> PontosRodada { get; set; }
        public List<Carta> Deck { get; set; }
        public Carta CartaJogada { get; set; }
        public Carta CartaAposta { get; set; }
        public List<char> NaipesDePontosDaRodada { get; set; }
        public string Senha { get; set; }
        public Orientacao Orientacao { get; set; }  
        public Posicao Posicao { get; set; }

        public Jogador(string linha)
        {
            string[] dados = linha.Split(',');

            int posicaoCR = dados[2].IndexOf('\r');         
            dados[2] = dados[2].Remove(posicaoCR, 1);

            this.IdJogador = Convert.ToInt32(dados[0]);
            this.Nome = dados[1];
            this.Pontuacao = Convert.ToInt32(dados[2]);

            this.PontosRodada = new List<Ponto>();
            this.Deck = new List<Carta>();
            this.NaipesDePontosDaRodada = new List<char>();
        }
        
        public Jogador(int idJogador, string nome, string senha)
        {
            this.IdJogador = idJogador;
            this.Nome = nome;
            this.Senha = senha;
            this.Pontuacao = 0;

            this.PontosRodada = new List<Ponto>();
            this.Deck = new List<Carta>();
            this.NaipesDePontosDaRodada = new List<char>();
        }

        public static List<Jogador> RetornarJogadoresPartida(int idPartida)
        {
            List<Jogador> jogadoresTmp = new List<Jogador>();

            string result;

            try
            {
                result = Jogo.ListarJogadores(idPartida);
            }
            catch ( Exception e )
            {
                Console.WriteLine(e.Message);
                return jogadoresTmp;
            }

            if (!Auxiliar.VerificarErro(result))
            {
                string[] jogadoresBrutos = result.Split('\n');

                foreach (string jogador in jogadoresBrutos)
                    if (jogador.Length > 0)
                        jogadoresTmp.Add(new Jogador(jogador));
            }
            return jogadoresTmp;
        }

        public static void OrganizarJogadores(ref List<Jogador> jogadores, int idPlayer)
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

            if(jogadoresTmp.Count == 2)
            {
                jogadoresTmp[0].Posicao = Posicao.Cima;
                jogadoresTmp[0].Orientacao = Orientacao.Horizontal;

                jogadoresTmp[1].Posicao = Posicao.Baixo;
                jogadoresTmp[1].Orientacao = Orientacao.Horizontal;
            }
            else
            {
                for(int i = 0; i < jogadoresTmp.Count; i++)
                {
                    jogadoresTmp[i].Posicao = (Posicao)i;
                    jogadoresTmp[i].Orientacao = i % 2 == 0 ? Orientacao.Vertical : Orientacao.Horizontal;
                }
            }

            jogadores = jogadoresTmp;
        }

        public static void PreencherDeck(List<Jogador> jogadores, List<CartasConsulta> decks, Control.ControlCollection controle)
        {
            int idJogador, posicao;
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
                    posicao = deckJogador.Posicoes[j];

                    jogadores[i].Deck.Add(new Carta(naipe, posicao));
                }

                jogadores[i].CartaJogada = new Carta();
                jogadores[i].CartaAposta = new Carta();
            }
                ImagemCarta.CriarImagensCartas(jogadores, controle);
        }

        public static void AtualizarDeck(List<Jogador> jogadores, List<CartasConsulta> decks)
        {
            int idJogador, posicaoCarta;
            CartasConsulta deckJogador;
            char naipe;

            for(int i = 0; i < jogadores.Count; i++)
            {
                idJogador = jogadores[i].IdJogador;
                deckJogador = decks.Find(d => d.IdJogador == idJogador);

                foreach (Ponto ponto in jogadores[i].PontosRodada)
                    ponto.ImagemPonto.PnlPonto.Visible = false;

                jogadores[i].PontosRodada.Clear();

                if (deckJogador == null) continue;

                for(int j = 0; j < deckJogador.NaipeCartas.Count; j++)
                {
                    posicaoCarta = jogadores[i].Deck[j].Posicao;

                    if(posicaoCarta == deckJogador.Posicoes[j])
                    {
                        naipe = deckJogador.NaipeCartas[j];
                        jogadores[i].Deck[j].ResetarCarta(naipe);
                    }
                    else
                    {
                        jogadores[i].Deck[j].ImagemCarta.TornarInvisivel();
                        jogadores[i].Deck.RemoveAt(j);
                    }
                }
            }
            ImagemCarta.AtualizarCartas(jogadores);
        }

        public static void EsconderCartasJogadas(List<Jogador> jogadores)
        {
            for(int i = 0; i < jogadores.Count; i++)
            {
                jogadores[i].CartaJogada.ImagemCarta.TornarInvisivel();
            }
        }

        public static void AtualizarJogadas(List<Jogador> jogadores, DadosVerificacao dados, Automato automato, Control.ControlCollection controle)
        {
            int valorCarta, posicao, indexCarta;
            char naipe, statusCarta;
            Jogador jogadorAtual;
            Orientacao orientacao;

            foreach(CartasVerificacao cartasJogador in dados.CartasRodada)
            {
                jogadorAtual = jogadores.Find(j => j.IdJogador == cartasJogador.IdJogador);
                orientacao = jogadorAtual.Orientacao;

                for(int i = 0; i < cartasJogador.Posicoes.Count; i++)
                {
                    valorCarta = cartasJogador.Valores[i];
                    posicao = cartasJogador.Posicoes[i];
                    naipe = cartasJogador.NaipeCartas[i];
                    statusCarta = cartasJogador.StatusCartas[i];
                   
                    if (statusCarta == 'C')
                        jogadorAtual.CartaJogada.AtualizarCarta(naipe, valorCarta, orientacao);

                    else
                        jogadorAtual.CartaAposta.AtualizarCarta(naipe, valorCarta, orientacao);
                                                             
                    indexCarta = jogadorAtual.Deck.FindIndex(c => c.Posicao == posicao);

                    if(indexCarta > -1)                       
                        jogadorAtual.Deck[indexCarta].TornarIndisponivel(valorCarta);
                     
                    else
                    {
                        Carta novaCarta = new Carta(naipe, posicao);

                        ImagemCarta.CriarImagemCarta(jogadorAtual, controle, novaCarta);

                        jogadorAtual.Deck.Add(novaCarta);

                        jogadorAtual.Deck = jogadorAtual.Deck.OrderBy(c => c.Posicao).ToList();

                        novaCarta.TornarIndisponivel(valorCarta);

                        automato.InserirCarta(ref novaCarta);
                    }

                    for(int j = 0; j < posicao - 1; j++)
                        if (jogadorAtual.Deck[j].Disponivel || jogadorAtual.Deck[j].PossiveisValores.Count > 1)
                            jogadorAtual.Deck[j].LimitarAcima(valorCarta);
                    
                    for(int j = posicao; j < jogadorAtual.Deck.Count; j++)
                        if (jogadorAtual.Deck[j].Disponivel || jogadorAtual.Deck[j].PossiveisValores.Count > 1)
                            jogadorAtual.Deck[j].LimitarAbaixo(valorCarta);                     
                }
            }
        }

        public static void VerificarHistorico(List<Jogador> jogadores, Partida partida, Control.ControlCollection controle)
        {
            List<CartasHistorico> historicoJogadas = CartasHistorico.HandleHistoricoJogadas(partida);
            int idJogador, posicao, valorCarta;
            Jogador jogadorAtual;

            foreach(CartasHistorico cartasPorJogador in historicoJogadas)
            {
                idJogador = cartasPorJogador.IdJogador;
                jogadorAtual = jogadores.Find(j => j.IdJogador == idJogador);

                for(int i = 0; i < cartasPorJogador.NaipeCartas.Count; i++)
                {
                    posicao = cartasPorJogador.Posicoes[i];
                    valorCarta = cartasPorJogador.Valores[i];

                    if (jogadorAtual.Deck[posicao - 1].Disponivel)
                        jogadorAtual.Deck[posicao - 1].TornarIndisponivel(valorCarta);
                }
            }

            Ponto ponto = new Ponto(historicoJogadas, partida.Rodada);            
            Jogador jogadorTmp = jogadores.Find(j => j.IdJogador == ponto.IdJogador);

            Ponto.AtribuirPonto(jogadorTmp, ponto, controle);
        }
    }
}
