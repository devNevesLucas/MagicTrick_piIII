using MagicTrick_piIII.Interfaces;
using MagicTrick_piIII.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class Automato
    {
        public Dictionary<char, List<CartaJogador>> Decks = new Dictionary<char, List<CartaJogador>>();
        public Jogador Jogador;
        public List<Jogador> Jogadores;

        public CartaJogador CartaReserva1;
        public CartaJogador CartaReserva2;

        public frmStatus StatusForm;

        private Dictionary<char, List<int>> ValoresDisponiveisPorNaipe = new Dictionary<char, List<int>>();

        private static List<char> naipesCartas = new List<char>()
        {
            'C', 'T', 'L', 'E', 'P', 'O', 'S'
        };

        private static List<int> valoresCartas = new List<int>()
        {
            0, 1, 2, 3, 4, 5, 6, 7
        };


        public Automato(Jogador jogador, List<Jogador> jogadores, frmStatus statusForm)
        {
            this.Jogador = jogador;
            this.Jogadores = jogadores;
            this.StatusForm = statusForm;
        }
        /*
            Recebe todos os jogadores da partida, percorre o deck de cada um deles, 
            adiciona cada uma de suas cartas ao dicionário que o autômato possui.         
         */
        public void InicializarPropriedades(ref List<Jogador> jogadores)
        {
            CartaJogador cartaTmp;
            char naipeTmp;

            foreach(Jogador jogadorAtual in jogadores)
            {
                for(int i = 0; i < jogadorAtual.Deck.Count; i++)
                {
                    cartaTmp = jogadorAtual.Deck[i];
                    naipeTmp = cartaTmp.Naipe;

                    if (!this.Decks.ContainsKey(naipeTmp))
                        this.Decks.Add(naipeTmp, new List<CartaJogador>());
                        
                    this.Decks[naipeTmp].Add(cartaTmp);                    
                }
            }
            this.InicializarValoresPossiveis();
            this.CartaReserva1 = null;
            this.CartaReserva2 = null;
        }
        /*
            Atualiza a lista de decks e dicionário de valores possíveis do automato ao trocar de rodada
         */
        public void ReiniciarPropriedades(ref List<Jogador> jogadores)
        {
            this.Decks.Clear();
            this.ValoresDisponiveisPorNaipe.Clear();
            this.InicializarPropriedades(ref jogadores);
        }

        public void InserirCarta(ref CartaJogador carta)
        {
            char naipe = carta.Naipe;
            this.Decks[naipe].Add(carta);
        }

        public void InicializarValoresPossiveis()
        {
            foreach (char naipe in naipesCartas)
                this.ValoresDisponiveisPorNaipe.Add(naipe, valoresCartas.ToList());
        }

        public void RemoverValorPossivel(int valor, char naipe)
        {
            this.ValoresDisponiveisPorNaipe[naipe].Remove(valor);
        }

        public void LimitarCartas(BaralhoVerificacao cartasRodada)
        {
            char naipe;
            int valor;

            List<CartaVerificacao> cartasTmp;
            
            foreach(KeyValuePair<int, List<CartaVerificacao>> chaveValor in cartasRodada.Baralho)
            {
                cartasTmp = chaveValor.Value;

                for(int i = 0; i < chaveValor.Value.Count; i++)
                {
                    naipe = cartasTmp[i].Naipe;
                    valor = cartasTmp[i].ValorReal;

                    this.AtualizarDecks(valor, naipe);
                }
            }
        }

        public void AtualizarDecks(int valor, char naipe)
        {
            List<CartaJogador> cartas = this.Decks[naipe];
            bool flagRemocao;

            foreach(CartaJogador carta in cartas)
            {
                flagRemocao = false;
                
                if (carta.PossiveisValores.Count > 1)
                    flagRemocao = carta.PossiveisValores.Remove(valor);

                if (carta.PossiveisValores.Count == 1 && carta.Disponivel)
                {
                    carta.AtualizarCartaDescoberta();

                    if(flagRemocao)
                        this.AtualizarDecks(carta.PossiveisValores[0], naipe);
                }
            }
        }

        private void ReservarCarta(CartaJogador carta)
        {            
            if (this.CartaReserva1 == null)
                this.CartaReserva1 = carta;

            if(this.CartaReserva2 == null)
                this.CartaReserva2 = carta;

            if(this.CartaReserva1 != null && this.CartaReserva2 != null)
            {
                int pontosRodada = this.Jogador.PontosRodada.Count;

                if (this.CartaReserva1.ValorReal == pontosRodada) return;

                if(this.CartaReserva2.ValorReal == pontosRodada)
                {
                    CartaJogador cartaTmp = this.CartaReserva2;
                    this.CartaReserva2 = this.CartaReserva1;
                    this.CartaReserva1 = cartaTmp;
                }
            }

            this.StatusForm.AtualizarCartasReservadas(this.CartaReserva1, this.CartaReserva2);
        }

        private void AtualizarReservas(CartaJogador cartaJogada)
        {
            if (this.CartaReserva1 == null && this.CartaReserva2 == null) return;

            if (this.CartaReserva1 == this.CartaReserva2)
                this.CartaReserva2 = null;

            if(this.CartaReserva1 == cartaJogada)
            {
                this.CartaReserva1 = this.CartaReserva2;
                this.CartaReserva2 = null;
            }

            if (this.CartaReserva2 == cartaJogada)
                this.CartaReserva2 = null;

            this.StatusForm.AtualizarCartasReservadas(this.CartaReserva1, this.CartaReserva2);
        }

        private bool VerificarReservas(CartaJogador carta)
        {
            if (this.CartaReserva1 != null && carta.Posicao == this.CartaReserva1.Posicao)
                return true;

            if (this.CartaReserva2 != null && carta.Posicao == this.CartaReserva2.Posicao)
                return true;

            return false;
        }

        public int HandleAposta(int rodada)
        {
            if (rodada < 8)
            {
                int pontosRodada = this.Jogador.PontosRodada.Count;




                CartaJogador cartaParaReservar = this.Jogador.Deck.Find(c => c.ValorReal == pontosRodada && c.Disponivel);

                if (cartaParaReservar != null)
                    this.ReservarCarta(cartaParaReservar);

                cartaParaReservar = null;

                cartaParaReservar = this.Jogador.Deck.Find(c => c.ValorReal == pontosRodada + 1 && c.Disponivel);

                if (cartaParaReservar != null)
                    this.ReservarCarta(cartaParaReservar);

                return 0;
            }

            return EscolherCartaAposta();
        }

        public int EscolherCartaAposta()
        {
            int pontosRodada = this.Jogador.PontosRodada.Count;

            CartaJogador carta = this.CartaReserva1;

            List<CartaJogador> deck = this.Jogador.Deck.FindAll(c => c.Disponivel);

            if (carta != null && carta.ValorReal == pontosRodada && carta.Disponivel)
                return carta.Posicao;

            carta = null;

            carta = this.CartaReserva2;

            if (carta != null && carta.ValorReal == pontosRodada && carta.Disponivel)
                return carta.Posicao;

            carta = deck.Find(c => c.ValorReal == pontosRodada && c.Disponivel);

            if (carta == null)
                carta = deck.Find(c => c.ContemValorSuperior(pontosRodada) && c.Disponivel);

            if (carta != null)
                return carta.Posicao;

            if (deck.Count > 1)
                return 0;

            return deck[0].Posicao;
        }

        public int JogarPrimeiraCartaPossivel(char? naipeRodada)
        {
            CartaJogador carta = null;

            List<CartaJogador> deck = this.Jogador.Deck;

            if (naipeRodada != null)
                carta = deck.Find(c => c.Naipe == naipeRodada && !this.VerificarReservas(c) && c.Disponivel);
            
            if (naipeRodada != null && carta == null)            
                carta = deck.Find(c => c.Naipe == naipeRodada && c.Disponivel);
             
            if (carta == null)
                carta = deck.Find(c => c.Disponivel);
            
            this.AtualizarReservas(carta);
            
            return carta.Posicao;
        }

        public int JogarUnicaCartaDisponivel(char naipe)
        {
            CartaJogador carta = this.Jogador.Deck.Find(c => c.Naipe == naipe && c.Disponivel);

            this.AtualizarReservas(carta);

            this.StatusForm.AtualizarEstrategia("Jogar única carta disponível do naipe");

            return carta.Posicao;
        }

        public int JogarMaiorCartaPossivel(char naipe)
        {
            List<CartaJogador> deckTmp = this.Jogador.Deck;

            deckTmp = deckTmp.OrderByDescending(c => c.Posicao).ToList();

            CartaJogador carta = deckTmp.Find(c => c.Naipe == naipe && !this.VerificarReservas(c) && c.Disponivel);

            if(carta == null)
                carta = deckTmp.Find(c => c.Naipe == naipe && c.Disponivel);

            this.AtualizarReservas(carta);

            this.StatusForm.AtualizarEstrategia("Queimar a maior carta possível");

            return carta.Posicao;
        }

        public int JogarMaiorCartaPossivel()
        {
            List<CartaJogador> deckTmp = this.Jogador.Deck;

            deckTmp = deckTmp.OrderByDescending(c => c.Posicao).ToList();

            CartaJogador carta = deckTmp.Find(c => c.Naipe != 'C' && c.Disponivel);

            if (carta == null)
                carta = deckTmp.Find(c => c.Disponivel);

            this.AtualizarReservas(carta);

            this.StatusForm.AtualizarEstrategia("Queimar a maior carta possível");

            return carta.Posicao;
        }

        public int JogarPrimeiraCartaDaRodada()
        {
            List<char> naipesEmComum = Jogador.RetornarNaipesEmComum(this.Jogadores, this.Jogador);

            List<CartaJogador> deck = this.Jogador.Deck;

            CartaJogador carta = deck.Find(c => c.Naipe == 'C' && !this.VerificarReservas(c) && c.Disponivel);
                
            if(carta == null)                
                carta = deck.Find(c => naipesEmComum.Contains(c.Naipe) && !this.VerificarReservas(c) && c.Disponivel);

            if (carta == null)
                carta = deck.Find(c => naipesEmComum.Contains(c.Naipe) && c.Disponivel);
                
            if (carta == null)                
                carta = deck.Find(c => c.Disponivel);

            this.AtualizarReservas(carta);

            this.StatusForm.AtualizarEstrategia("Iniciar rodada com carta de naipe em comum");

            return carta.Posicao;
        }

        public int JogarCartaComValorMenor(CartaVerificacao cartaCampea, char naipeRodada)
        {
            if (cartaCampea.Naipe == 'C' && naipeRodada != 'C')
                return JogarMaiorCartaPossivel(naipeRodada);

            int maiorValor = cartaCampea.ValorReal;

            List<CartaJogador> deck = this.Jogador.Deck;
            CartaJogador carta;

            deck = deck.OrderByDescending(c => c.Posicao).ToList();

            carta = deck.Find(c => c.PossiveisValores.Max() < maiorValor && c.Naipe == naipeRodada && c.Disponivel);

            if (carta == null)
                carta = deck.Find(c => c.ValorReal < maiorValor && c.Naipe == naipeRodada && c.Disponivel);

            if (carta != null && carta.ValorReal < cartaCampea.ValorReal && carta.ValorReal != -1)
            {
                this.AtualizarReservas(carta);

                this.StatusForm.AtualizarEstrategia("Jogar carta com valor menor que campeã");

                return carta.Posicao;
            }
                        
            return JogarPrimeiraCartaPossivel(naipeRodada);
        }

        public int HandleJogadas(DadosVerificacao dados)
        {    
            CartaVerificacao cartaCampea = BaralhoVerificacao.RetornarCartaCampea(dados.CartasRodada);
           
            char? naipe = dados.NaipeRodada;

            if (naipe == null)
                return this.JogarPrimeiraCartaDaRodada();

            if (this.Jogador.CartasDisponiveisPorNaipe[(char)naipe] == 0)
                return this.JogarMaiorCartaPossivel();

            if (this.Jogador.CartasDisponiveisPorNaipe[(char)naipe] == 1)
                return this.JogarUnicaCartaDisponivel((char)naipe);

            if (cartaCampea.ValorReal == 7)
                return this.JogarMaiorCartaPossivel((char)naipe);

            return this.JogarCartaComValorMenor(cartaCampea, (char)naipe);
        }
        
        public int RetornarPosicaoEscolhida(DadosVerificacao dados)
        {
            if (dados.StatusRodada == 'A')
                return this.HandleAposta(dados.RodadaAtual);

            return this.HandleJogadas(dados);
        }
    }
}
