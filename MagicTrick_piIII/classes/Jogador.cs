﻿using MagicTrick_piIII.classes;
using MagicTrick_piIII.Enums;
using MagicTrick_piIII.Interfaces;
using MagicTrick_piIII.Telas;
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
    public class Jogador
    {
        public int IdJogador { get; set; }  
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public List<Ponto> PontosRodada { get; set; }
        public List<CartaJogador> Deck { get; set; }
        public CartaJogador CartaJogada { get; set; }
        public CartaJogador CartaAposta { get; set; }
        public List<char> NaipesDePontosDaRodada { get; set; }
        public Dictionary<char, int> CartasDisponiveisPorNaipe { get; set; }    
        public string Senha { get; set; }
        public Orientacao Orientacao { get; set; }  
        public Posicao Posicao { get; set; }
        public Label lblPontuacao { get; set; }
        public Label lblQtdNaipes { get; set; }

        static int[,] PosicoesPontuacao = { { 183, 478 }, { 732, 227 }, { 980, 478 }, { 732, 457 } };
        
        static int[,] posicoesNaipesVitorias = { { 99, 104 }, { 828, 140 }, { 1068, 575 }, { 344, 540 } };

        public Jogador(string linha)
        {
            string[] dados = linha.Split(',');

            int posicaoCR = dados[2].IndexOf('\r');         
            dados[2] = dados[2].Remove(posicaoCR, 1);

            this.IdJogador = Convert.ToInt32(dados[0]);
            this.Nome = dados[1];
            this.Pontuacao = Convert.ToInt32(dados[2]);

            this.PontosRodada = new List<Ponto>();
            this.Deck = new List<CartaJogador>();
            this.NaipesDePontosDaRodada = new List<char>();

            this.CartasDisponiveisPorNaipe = new Dictionary<char, int>
            {
                {'C', 0},{'L', 0},{'E', 0},{'S', 0},{'O', 0},{'T', 0},{'P', 0}
            };
        }
        
        public Jogador(int idJogador, string nome, string senha)
        {
            this.IdJogador = idJogador;
            this.Nome = nome;
            this.Senha = senha;
            this.Pontuacao = 0;

            this.PontosRodada = new List<Ponto>();
            this.Deck = new List<CartaJogador>();
            this.NaipesDePontosDaRodada = new List<char>();

            this.CartasDisponiveisPorNaipe = new Dictionary<char, int>
            {
                {'C', 0},{'L', 0},{'E', 0},{'S', 0},{'O', 0},{'T', 0},{'P', 0}
            };
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

        private void InstanciarLabels(Control.ControlCollection controle)
        {
            int posicao = (int)this.Posicao;

            Point ponto = new Point(PosicoesPontuacao[posicao, 0], PosicoesPontuacao[posicao, 1]);
            
            this.lblPontuacao = new Label();
            this.lblPontuacao.Font = Auxiliar.fontePrincipal;
            this.lblPontuacao.Location = ponto;
            this.lblPontuacao.ForeColor = Color.White;
            this.lblPontuacao.BackColor = Color.FromArgb(19, 23, 31);

            this.lblPontuacao.Text = this.Pontuacao.ToString();
            controle.Add(this.lblPontuacao);

            ponto = new Point(posicoesNaipesVitorias[posicao, 0], posicoesNaipesVitorias[posicao, 1]);

            this.lblQtdNaipes = new Label();
            this.lblQtdNaipes.Font = Auxiliar.fontePrincipal;
            this.lblQtdNaipes.Location = ponto;
            this.lblQtdNaipes.ForeColor = Color.White;
            this.lblQtdNaipes.BackColor = Color.FromArgb(19, 23, 31);

            this.lblQtdNaipes.Width = 25;

            this.lblQtdNaipes.Text = this.NaipesDePontosDaRodada.Count.ToString();
            controle.Add(this.lblQtdNaipes);

            this.lblPontuacao.BringToFront();
            this.lblQtdNaipes.BringToFront();
        }

        private static void InstanciarLabelsJogadores(List<Jogador> jogadores, Control.ControlCollection controle)
        {
            foreach (Jogador jogador in jogadores)
                jogador.InstanciarLabels(controle);
        }

        public static void OrganizarJogadores(ref List<Jogador> jogadores, int idPlayer, Control.ControlCollection controle)
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

            InstanciarLabelsJogadores(jogadores, controle);
        }

        public static void PreencherDeck(List<Jogador> jogadores, BaralhoConsulta decks, Control.ControlCollection controle)
        {
            int idJogador, posicao;
            List<Carta> deckJogador;
            char naipe;

            for(int i = 0; i < jogadores.Count; i++)
            {
                idJogador = jogadores[i].IdJogador;
                deckJogador = decks.Baralho[idJogador];

                if (deckJogador == null) continue;

                for(int j = 0; j < deckJogador.Count; j++)
                {
                    naipe = deckJogador[j].Naipe;
                    posicao = deckJogador[j].Posicao;

                    jogadores[i].Deck.Add(new CartaJogador(naipe, posicao));
                    jogadores[i].CartasDisponiveisPorNaipe[naipe]++;
                }

                jogadores[i].CartaJogada = new CartaJogador('C', 15);
                jogadores[i].CartaAposta = new CartaJogador('C', 15);
                jogadores[i].CartaAposta.ValorReal = -1;
            }
                ImagemCarta.CriarImagensCartas(jogadores, controle);
        }

        public static void AtualizarDeck(List<Jogador> jogadores, BaralhoConsulta decks)
        {
            int idJogador, posicaoCarta, qtdCartas, indexCarta;
            List<Carta> deckJogador;
            char naipe;

            List<int> cartasParaRemover = new List<int>();

            for(int i = 0; i < jogadores.Count; i++)
            {
                idJogador = jogadores[i].IdJogador;
                deckJogador = decks.Baralho[idJogador];

                cartasParaRemover.Clear();

                foreach (Ponto ponto in jogadores[i].PontosRodada)
                    ponto.ImagemPonto.PnlPonto.Visible = false;
                
                jogadores[i].PontosRodada.Clear();
                jogadores[i].NaipesDePontosDaRodada.Clear();
                jogadores[i].AtualizarLblNaipesVitorias();

                foreach (char chave in jogadores[i].CartasDisponiveisPorNaipe.Keys.ToList())
                    jogadores[i].CartasDisponiveisPorNaipe[chave] = 0;

                if (deckJogador == null) continue;

                qtdCartas = jogadores[i].Deck.Count;

                for(int j = 0; j < qtdCartas; j++)
                {
                    posicaoCarta = jogadores[i].Deck[j].Posicao;
                    indexCarta = deckJogador.FindIndex(c => c.Posicao == posicaoCarta);
                   
                    if(indexCarta > -1)
                    {
                        naipe = deckJogador[indexCarta].Naipe;
                        jogadores[i].Deck[j].ResetarCarta(naipe);
                        jogadores[i].CartasDisponiveisPorNaipe[naipe]++;
                    }
                    else
                    {
                        jogadores[i].Deck[j].ImagemCarta.TornarInvisivel();
                        cartasParaRemover.Add(j);  
                    }
                }
                for (int k = 0; k < cartasParaRemover.Count; k++)               
                    jogadores[i].Deck.RemoveAt(cartasParaRemover[k]);
                
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
        
        public static void AtualizarJogadas(List<Jogador> jogadores, DadosVerificacao dados, Automato automato, Control.ControlCollection controle, frmNarrador narrador)
        {
            int valorCarta, posicao, indexCarta;
            char naipe, statusCarta;
            Jogador jogadorAtual;
            Orientacao orientacao;

            List<CartaVerificacao> cartasTmp;

            foreach(KeyValuePair<int, List<CartaVerificacao>> chaveValor in dados.CartasRodada.Baralho)
            {
                jogadorAtual = jogadores.Find(j => j.IdJogador == chaveValor.Key);
                orientacao = jogadorAtual.Orientacao;

                cartasTmp = chaveValor.Value;

                for (int i = 0; i <  cartasTmp.Count; i++)
                {
                    valorCarta = cartasTmp[i].ValorReal;
                    posicao = cartasTmp[i].Posicao;
                    naipe = cartasTmp[i].Naipe;
                    statusCarta = cartasTmp[i].Status;

                    if (statusCarta == 'C')
                        jogadorAtual.CartaJogada.AtualizarCarta(naipe, valorCarta);

                    else
                        jogadorAtual.CartaAposta.AtualizarCarta(naipe, valorCarta);

                    indexCarta = jogadorAtual.Deck.FindIndex(c => c.Posicao == posicao);

                    if (indexCarta > -1)
                    {
                        if(jogadorAtual.Deck[indexCarta].Disponivel)
                        {
                            jogadorAtual.Deck[indexCarta].TornarIndisponivel(valorCarta);
                            jogadorAtual.CartasDisponiveisPorNaipe[naipe]--;
                            automato.RemoverValorPossivel(valorCarta, naipe);

                            if (statusCarta == 'C')
                                narrador.NarrarCartaJogada(jogadorAtual, cartasTmp[i]);

                            else
                                narrador.NarrarCartaApostada(jogadorAtual, cartasTmp[i]);
                        }                    
                    }                   

                    else
                    {
                        CartaJogador novaCarta = new CartaJogador(naipe, posicao);

                        ImagemCarta.CriarImagemCarta(jogadorAtual, controle, novaCarta);

                        jogadorAtual.Deck.Add(novaCarta);

                        jogadorAtual.Deck = jogadorAtual.Deck.OrderBy(c => c.Posicao).ToList();

                        novaCarta.TornarIndisponivel(valorCarta);

                        automato.InserirCarta(ref novaCarta);

                        if (statusCarta == 'C')
                            narrador.NarrarCartaJogada(jogadorAtual, novaCarta);

                        else
                            narrador.NarrarCartaApostada(jogadorAtual, novaCarta);
                    }

                    CartaJogador.LimitarDeckJogador(jogadorAtual.Deck, posicao, valorCarta);
                }
            }         
        }

        public static void VerificarHistorico(List<Jogador> jogadores, Partida partida, Automato automato, Control.ControlCollection controle, frmNarrador narrador)
        {
            BaralhoHistorico historicoJogadas = BaralhoHistorico.HandleHistoricoJogadas(partida);

            int rodada = partida.Rodada - 1;

            int posicao, valor, idJogador;
            char naipe;
            Jogador jogadorAtual;

            List<CartaHistorico> listaTmp = historicoJogadas.Baralho[rodada];

            foreach (CartaHistorico carta in listaTmp)
            {
                posicao = carta.Posicao;
                valor = carta.ValorReal;
                naipe = carta.Naipe;
                idJogador = carta.IdJogador;

                jogadorAtual = jogadores.Find(j => j.IdJogador == idJogador);

                if (jogadorAtual == null) continue;

                if (jogadorAtual.Deck[posicao - 1].Disponivel)
                {
                    jogadorAtual.CartasDisponiveisPorNaipe[naipe]--;
                    jogadorAtual.Deck[posicao - 1].TornarIndisponivel(valor);
                    CartaJogador.LimitarDeckJogador(jogadorAtual.Deck, posicao, valor);
                    automato.AtualizarDecks(valor, naipe);
                    automato.RemoverValorPossivel(valor, naipe);

                    narrador.NarrarCartaJogada(jogadorAtual, carta);
                }
            }
            
            Ponto ponto = new Ponto(historicoJogadas, partida.Rodada);            
            Jogador jogadorTmp = jogadores.Find(j => j.IdJogador == ponto.IdJogador);

            Ponto.AtribuirPonto(jogadorTmp, ponto, controle);
        }

        public static void AdicionarUltimoPontoDoRound(List<Jogador> jogadores, Partida partida)
        {
            int round = partida.Round - 1;
            int rodadaFinal = 10 + jogadores.Count;

            BaralhoHistorico historicoJogadas = BaralhoHistorico.HandleHistoricoJogadas(partida, round);

            Ponto ponto = new Ponto(historicoJogadas, rodadaFinal);

            Jogador jogadorTmp = jogadores.Find(j => j.IdJogador == ponto.IdJogador);

            Ponto.AtribuirUltimoPontoDoRound(jogadorTmp, ponto);
        }

        public void AtualizarLblNaipesVitorias()
        {
            int qtdNaipes = this.NaipesDePontosDaRodada.Count;
            this.lblQtdNaipes.ResetText();
            this.lblQtdNaipes.Text = qtdNaipes.ToString();
        }

        private void AtualizarLblPontuacao()
        {
            this.lblPontuacao.Text = this.Pontuacao.ToString();
        }

        /*
            Verifico se existe diferença entre a aposta e a quantidade de vitórias no round
            Se não houver, adiciono 3 pontos a pontosRound, caso contrário, verifico se a 
            diferença é maior do que 0, para multiplica-la por -1 e garantir que ela seja um número
            negativo;
            Após isso, verifico se a minha aposta é igual ao número de naipes das rodadas que ganhei, 
            caso seja, adiciono dois pontos ao placar.
         */
        private void AtualizarPontuacao(frmNarrador narrador)
        {
            int pontosRound = 0;
            int aposta = this.CartaAposta.ValorReal;

            int diferenca = aposta - this.PontosRodada.Count;

            narrador.NarrarPontuacaoCalculada(this.IdJogador, diferenca);

            if (diferenca == 0)
            {
                pontosRound = 3;
               
                if (aposta == this.NaipesDePontosDaRodada.Count)
                {
                    pontosRound += 2;
                    narrador.NarrarPrestigioGanho(this.IdJogador);
                }
            }

            else
                pontosRound = diferenca * (diferenca > 0 ? -1 : 1);         

            this.Pontuacao += pontosRound;
        }

        public static void AtualizarPlacares(List<Jogador> jogadores, frmNarrador narrador)
        {
            foreach (Jogador jogador in jogadores)
            {
                jogador.AtualizarPontuacao(narrador);
                jogador.AtualizarLblNaipesVitorias();
                jogador.AtualizarLblPontuacao();
            }

            foreach (Jogador jogador in jogadores)
                narrador.NarrarNovaPontuacao(jogador);

            narrador.AtualizarJogadores(jogadores);
        }
        
        public static List<char> RetornarNaipesEmComum(List<Jogador> jogadores, Jogador jogador)
        {
            Dictionary<char, int> naipesEmComumDictionary = new Dictionary<char, int>();
            
            foreach(KeyValuePair<char, int> chaveValor in jogador.CartasDisponiveisPorNaipe)            
                if (jogador.CartasDisponiveisPorNaipe[chaveValor.Key] > 0)
                    naipesEmComumDictionary.Add(chaveValor.Key, 0);
           
            foreach(Jogador jogadorTmp in jogadores)
            {
                if (jogadorTmp.IdJogador == jogador.IdJogador) continue;
               
                foreach(char naipe in jogadorTmp.CartasDisponiveisPorNaipe.Keys)                
                    if (naipesEmComumDictionary.ContainsKey(naipe) && jogadorTmp.CartasDisponiveisPorNaipe[naipe] > 0)
                        naipesEmComumDictionary[naipe]++;
            }

            List<char> naipesEmComum = new List<char>();

            List<char> naipes = naipesEmComumDictionary.Keys.ToList();

            foreach (char naipe in naipes)
                if (naipesEmComumDictionary[naipe] > 0)
                    naipesEmComum.Add(naipe);
               
            return naipesEmComum;
        }

        public static int RetornarQtdDeCopas(List<Jogador> jogadores, Jogador jogador)
        {
            int copasDoJogador = jogador.CartasDisponiveisPorNaipe['C'];
            int maiorQtdCopas = 0;

            foreach(Jogador jogadorTmp in jogadores)
            {
                if (jogadorTmp.IdJogador == jogador.IdJogador) continue;

                if (jogadorTmp.CartasDisponiveisPorNaipe['C'] > maiorQtdCopas)
                    maiorQtdCopas = jogadorTmp.CartasDisponiveisPorNaipe['C'];
            }

            if (copasDoJogador - maiorQtdCopas <= 0)
                return 0;

            return copasDoJogador - maiorQtdCopas;
        }
    }
}
