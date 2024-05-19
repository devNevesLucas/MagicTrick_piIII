using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class DadosVerificacao
    {
        public char StatusPartida { get; set; }
        public int IdJogador { get; set; } 
        public int RodadaAtual { get; set; }
        public char StatusRodada { get; set; }
        public char? NaipeRodada { get; set; }  
        public List<int> JogadoresQueJaJogaram { get; set; }        
        public BaralhoVerificacao CartasRodada { get; set; }

        public DadosVerificacao(string dadosPartida) 
        {
            string[] dadosArray = dadosPartida.Split(',');

            char status = Convert.ToChar(dadosArray[0]);
            int idJogador = Convert.ToInt32(dadosArray[1]);
            int rodada = Convert.ToInt32(dadosArray[2]);
            char statusRodada = Convert.ToChar(dadosArray[3]);

            this.StatusPartida = status;
            this.IdJogador = idJogador;
            this.RodadaAtual = rodada;
            this.StatusRodada = statusRodada;
            this.JogadoresQueJaJogaram = new List<int>();
            this.CartasRodada = new BaralhoVerificacao();
        }   

        public static DadosVerificacao RetornarDadosVerificacao(int idPartida)
        {
            DadosVerificacao dadosVerificacao = null;

            string result;

            char? naipeTmp = null;

            try
            {
                result = Jogo.VerificarVez2(idPartida);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return dadosVerificacao;
            }

            if (result.StartsWith("ERRO"))
                return dadosVerificacao;

            result = result.Replace("\r", "");

            string[] dadosTmp = result.Split('\n');

            dadosVerificacao = new DadosVerificacao(dadosTmp[0]);

            dadosTmp = dadosTmp.Skip(1).ToArray();

            dadosVerificacao.CartasRodada = BaralhoVerificacao.RetornarCartasVerificacaoTratadas(dadosTmp, ref naipeTmp);

            dadosVerificacao.JogadoresQueJaJogaram = BaralhoVerificacao.RetornarJogadoresQueJaJogaram(dadosVerificacao.CartasRodada);

            dadosVerificacao.NaipeRodada = naipeTmp;

            return dadosVerificacao;    
        }        
    }
}
