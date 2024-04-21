using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class CartasConsulta : CartasChamadas
    {   
        public CartasConsulta(int idJogador, int posicao, char naipe) : base(idJogador, posicao, naipe) { }

        public static List<CartasConsulta> HandleConsultarMao(int idPartida)
        {
            List<CartasConsulta> cartasConsultaTmp = new List<CartasConsulta>();

            string result;

            try
            {
                result = Jogo.ConsultarMao(idPartida);            
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return cartasConsultaTmp;
            }

            if (Auxiliar.VerificarErro(result))
                return cartasConsultaTmp;


            result = result.Replace("\r", "");

            return RetornarConsultarMaoTratada(result);   
        }

        private static List<CartasConsulta> RetornarConsultarMaoTratada(string consultaBruta)
        {
            List<CartasConsulta> cartasConsulta = new List<CartasConsulta>();

            string[] dadosBrutos = consultaBruta.Split('\n');
            string[] dados;

            int idJogador, indexJogador, indexCarta;
            char naipe;

            for(int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i] == "") continue;

                dados = dadosBrutos[i].Split(',');

                idJogador = Convert.ToInt32(dados[0]);
                indexCarta = Convert.ToInt32(dados[1]);
                naipe = Convert.ToChar(dados[2]);

                indexJogador = cartasConsulta.FindIndex(c => c.IdJogador == idJogador);

                if (indexJogador > -1)
                {
                    cartasConsulta[indexJogador].Posicoes.Add(indexCarta);
                    cartasConsulta[indexJogador].NaipeCartas.Add(naipe);
                }

                else
                    cartasConsulta.Add(new CartasConsulta(idJogador, indexCarta, naipe));
            }
            return cartasConsulta;
        }        
    }
}
