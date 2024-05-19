using MagicTrick_piIII.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class BaralhoVerificacao
    {

        public Dictionary<int, List<CartaVerificacao>> Baralho;
        
        public BaralhoVerificacao()
        {
            this.Baralho = new Dictionary<int, List<CartaVerificacao>>();
        }


        public static BaralhoVerificacao RetornarCartasVerificacaoTratadas(string[] dadosBrutos, ref char? naipeRodada)
        {
            BaralhoVerificacao cartasTmp = new BaralhoVerificacao();

            string[] dados;
            int idJogador, valorCarta, posicaoCarta;
            char naipe, status;

            bool flagNaipeRodada = false;

            CartaVerificacao cartaTmp;

            for (int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i].Length == 0) continue;

                if (dadosBrutos[i].StartsWith("C:"))
                {
                    status = 'C';
                    dadosBrutos[i] = dadosBrutos[i].Replace("C:", "");
                }
                else
                {
                    status = 'A';
                    dadosBrutos[i] = dadosBrutos[i].Replace("A:", "");
                }

                dados = dadosBrutos[i].Split(',');

                idJogador = Convert.ToInt32(dados[0]);
                naipe = Convert.ToChar(dados[1]);
                valorCarta = Convert.ToInt32(dados[2]);

                if(status == 'C' && !flagNaipeRodada)
                {
                    naipeRodada = naipe;
                    flagNaipeRodada = true;
                }

                if (status == 'C')
                    posicaoCarta = Convert.ToInt32(dados[3]);

                else
                    posicaoCarta = Convert.ToInt32(dados[4]);
          

                cartaTmp = new CartaVerificacao(posicaoCarta, naipe, valorCarta, status);                
                
                if (cartasTmp.Baralho.ContainsKey(idJogador))
                    cartasTmp.Baralho[idJogador].Add(cartaTmp);
                
                else
                {
                    List<CartaVerificacao> listaTmp = new List<CartaVerificacao>
                    {
                        cartaTmp
                    };

                    cartasTmp.Baralho.Add(idJogador, listaTmp);
                }               
            }
            return cartasTmp;
        }

        public static CartaVerificacao RetornarCartaCampea(BaralhoVerificacao cartas)
        {
            CartaVerificacao cartaCampea = new CartaVerificacao(0, 'A', 0, 'C');
            CartaVerificacao cartaTmp;

            foreach(KeyValuePair<int, List<CartaVerificacao>> chaveValor in cartas.Baralho)
            {
                for(int i = 0; i < chaveValor.Value.Count; i++)
                {
                    cartaTmp = chaveValor.Value[i];

                    if (cartaTmp.Status != 'C') continue;

                    if (cartaCampea.Naipe == 'C' && cartaTmp.Naipe != 'C') continue;

                    if (cartaTmp.Naipe == 'C' && cartaCampea.Naipe != 'C')
                        cartaCampea = cartaTmp;

                    if (cartaTmp.ValorReal > cartaCampea.ValorReal)
                        cartaCampea = cartaTmp;
                }
            }

            if (cartaCampea.Posicao == 0)
                return null;

            return cartaCampea;
        }

        public static List<int> RetornarJogadoresQueJaJogaram(BaralhoVerificacao cartas)
        {
            List<int> jogadores = new List<int>();

            foreach(KeyValuePair<int, List<CartaVerificacao>> chaveValor in cartas.Baralho)            
                if (chaveValor.Value.Any(c => c.Status == 'C'))
                    jogadores.Add(chaveValor.Key);
          
            return jogadores;
        }
    }
}
