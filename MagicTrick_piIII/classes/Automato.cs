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

        public Automato(Jogador jogador)
        {
            this.Jogador = jogador;
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
        
        /*
            Função responsável por retornar a primeira carta disponível para ser jogada na rodada
            atual. Verifica se há alguma carta disponível com o atual naipe, caso não haja,
            verifica se há alguma carta disponível com o naipe de C - copas, caso não haja,
            retorna a primeira carta do naipe disponível, significando que não existem cartas desses
            dois naipes. É somado 1 no final pela posição da carta no banco de dados sendo iniciada com 1,
            ao invés de 0.
         */
        public int JogarPrimeiraCartaPossivel(char? naipeRodada)
        {
            int posicao = -1;

            if(naipeRodada != null)
                posicao = this.Jogador.Deck.FindIndex(c => c.Naipe == naipeRodada && c.Disponivel);

            if(naipeRodada == null)
                posicao = this.Jogador.Deck.FindIndex(c => c.Disponivel);

            if (posicao < 0)
                posicao = this.Jogador.Deck.FindIndex(c => c.Naipe == 'C' && c.Disponivel);

            if (posicao < 0)
                posicao = this.Jogador.Deck.FindIndex(c => c.Disponivel);

            return posicao + 1;
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
    }
}
