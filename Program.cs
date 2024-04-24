using System;
using CamadaNegocios;

namespace SNS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Aeroporto.ListaAeroporto listaVoos = Aeroporto.ObterListaAeroporto();

  
            double mediaLotacao = CalcularMediaLotacao(listaVoos);

            CartaoVisualizacao cartao = new CartaoVisualizacao();

            cartao.ExibirCartao(listaVoos.Count, mediaLotacao);
        }

        static double CalcularMediaLotacao(Aeroporto.ListaAeroporto voos)
        {
            int totalLotacao = 0;
            foreach (var voo in voos)
            {
                totalLotacao += voo.Lotacao;
            }
            return (double)totalLotacao / voos.Count;
        }
    }
}
