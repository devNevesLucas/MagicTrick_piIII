using MagicTrick_piIII.Interfaces;
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

        public Automato(Jogador jogador, List<Jogador> jogadores)
        {
            this.Jogador = jogador;
            this.Jogadores = jogadores;
        }
        /*
            Recebe todos os jogadores da partida, percorre o deck de cada um deles, 
            adiciona cada uma de suas cartas ao dicionário que o autômato possui.         
         */
        public void InicializarDecks(ref List<Jogador> jogadores)
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
        }
        /*
            Atualiza a lista de decks do automato ao trocar de rodada
         */
        public void ReiniciarDecks(ref List<Jogador> jogadores)
        {
            this.Decks.Clear();
            this.InicializarDecks(ref jogadores);
        }

        public void InserirCarta(ref CartaJogador carta)
        {
            char naipe = carta.Naipe;
            this.Decks[naipe].Add(carta);
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
        public int HandleAposta(int rodada)
        {
            if (rodada < 6)
                return 0;

            return CalcularMelhorAposta();
        }

        public int CalcularMelhorAposta()
        {
            int vitorias = this.Jogador.PontosRodada.Count + 2;

            CartaJogador carta = this.Jogador.Deck.Find(c => c.ValorReal == vitorias && c.Disponivel);

            if (carta == null)
                carta = this.Jogador.Deck.Find(c => c.ContemValorSuperior(vitorias) && c.Disponivel);

            return carta.Posicao;
        }

        public int JogarPrimeiraCartaPossivel(char? naipeRodada)
        {
            CartaJogador carta = null;

            if (naipeRodada != null)
                carta = this.Jogador.Deck.Find(c => c.Naipe == naipeRodada && c.Disponivel);

            if (carta == null)
                carta = this.Jogador.Deck.Find(c => c.Disponivel);

            return carta.Posicao;
        }

        public int JogarMenorCartaDeCopas()
        {
            CartaJogador carta;

            carta = this.Jogador.Deck.Find(c => c.Naipe == 'C' && c.Disponivel);

            if (carta == null)
                carta = this.Jogador.Deck.Find(c => c.Disponivel);

            return carta.Posicao;
        }

        public int JogarCartaNoMaiorIntervaloDisponivel()
        {
            int inicio = 0, inicioAux = 0;
            int intervalo = 0, intervaloAux = 0;
            
            for(int i = 0; i < this.Jogador.Deck.Count; i++)
            {
                if (this.Jogador.Deck[i].Disponivel)
                    intervaloAux++;

                else                
                    if(intervaloAux > intervalo)
                    {
                        inicio = inicioAux;
                        inicioAux = i + 1;
                        intervalo = intervaloAux;
                        intervaloAux = 0;
                    }                                        
            }

            if (intervalo == 0)
                intervalo = intervaloAux;

            int posicao = (int)(intervalo / 2) + inicio;

            CartaJogador carta = this.Jogador.Deck.Find(c => c.Posicao >= posicao && c.Disponivel);

            return carta.Posicao;
        }

        public int JogarCartaMaiorQueDemais(int valor, char naipe)
        {
            CartaJogador carta;

            carta = this.Jogador.Deck.Find(c => c.ValorReal > valor && c.Naipe == naipe && c.Disponivel);

            if (carta == null)
                carta = this.Jogador.Deck.Find(c => c.ContemValorSuperior(valor) && c.Naipe == naipe && c.Disponivel);

            if (carta == null)
                carta = this.Jogador.Deck.Find(c => c.Naipe == naipe && c.Disponivel);

            return carta.Posicao;
        }    
        
        public int JogarMaiorCartaPossivel(char? naipe)
        {
            List<CartaJogador> deckTmp = this.Jogador.Deck;

            deckTmp = deckTmp.OrderByDescending(c => c.Posicao).ToList();

            CartaJogador carta = null;

            if (naipe != null)
                carta = deckTmp.Find(c => c.Naipe == naipe && c.Disponivel);

            if (carta == null)
                carta = deckTmp.Find(c => c.Disponivel);

            return carta.Posicao;
        }

        public int HandleJogadas(DadosVerificacao dados)
        {
            List<int> jogadoresQueJaJogaram = dados.JogadoresQueJaJogaram;

            CartaVerificacao cartaCampea = BaralhoVerificacao.RetornarCartaCampea(dados.CartasRodada);
           
            int aposta = this.Jogador.CartaAposta.ValorReal;
            int pontosRodada = this.Jogador.PontosRodada.Count;
            int diferenca = pontosRodada - aposta;
            char? naipe = dados.NaipeRodada;

            if (naipe == null)
                return this.JogarCartaNoMaiorIntervaloDisponivel();

            if (this.Jogador.CartasDisponiveisPorNaipe[(char)naipe] == 1)
                return this.JogarPrimeiraCartaPossivel(naipe);

            int cartasDisponiveis = this.Jogador.CartasDisponiveisPorNaipe[(char)naipe];

            if (diferenca > 0)
            {
                if(cartasDisponiveis == 0)
                {
                    if (cartaCampea.Naipe != 'C')
                        return this.JogarMenorCartaDeCopas();

                    return this.JogarPrimeiraCartaPossivel(naipe);
                }

                if(cartaCampea != null)
                    return this.JogarCartaMaiorQueDemais(cartaCampea.ValorReal, (char)naipe);

                return this.JogarMaiorCartaPossivel(naipe);
            }

            if(cartasDisponiveis == 0)           
                return this.JogarMaiorCartaPossivel(naipe);

            return this.JogarPrimeiraCartaPossivel(naipe);
        }
        
        public int RetornarPosicaoEscolhida(DadosVerificacao dados)
        {
            if (dados.StatusRodada == 'A')
                return this.HandleAposta(dados.RodadaAtual);

            return this.HandleJogadas(dados);
        }
    }
}
