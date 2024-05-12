using System;

namespace SNS
{
    internal class CartaoVisualizacao
    {
        public void ExibirCartao(int totalVoos, double mediaLotacao)
        {
            Console.WriteLine("Cartão de Visualização de Dados:");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Total de Voos: " + totalVoos);
            Console.WriteLine("Média de Lotação dos Voos: " + mediaLotacao.ToString("0.00"));
            Console.WriteLine("--------------------------------");
        }
    }
}
