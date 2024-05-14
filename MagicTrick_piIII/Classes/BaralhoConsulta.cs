using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick_piIII.classes
{
    public class BaralhoConsulta
    {   
        public Dictionary<int, List<Carta>> Baralho { get; set; }

        public BaralhoConsulta() 
        {
            this.Baralho = new Dictionary<int, List<Carta>>();
        }

        public static BaralhoConsulta HandleConsultarMao(int idPartida)
        {
            BaralhoConsulta cartasConsultaTmp = new BaralhoConsulta();

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

            if (result.StartsWith("ERRO")) 
                return cartasConsultaTmp;


            result = result.Replace("\r", "");

            return RetornarConsultarMaoTratada(result);   
        }

        private static BaralhoConsulta RetornarConsultarMaoTratada(string consultaBruta)
        {
            BaralhoConsulta cartasConsulta = new BaralhoConsulta();

            string[] dadosBrutos = consultaBruta.Split('\n');
            string[] dados;

            int idJogador, indexCarta;
            char naipe;

            Carta novaCarta;
            List<Carta> listaTmp;

            for(int i = 0; i < dadosBrutos.Length; i++)
            {
                if (dadosBrutos[i] == "") continue;

                dados = dadosBrutos[i].Split(',');

                idJogador = Convert.ToInt32(dados[0]);
                indexCarta = Convert.ToInt32(dados[1]);
                naipe = Convert.ToChar(dados[2]);
              
                novaCarta = new Carta(indexCarta, naipe);

                if(cartasConsulta.Baralho.ContainsKey(idJogador))
                    cartasConsulta.Baralho[idJogador].Add(novaCarta);
                
                else
                {
                    listaTmp = new List<Carta>
                    {
                        novaCarta
                    };
                    cartasConsulta.Baralho.Add(idJogador, listaTmp);
                }
            }
            return cartasConsulta;
        }        
    }
}
