
using System;


namespace CalculadoraFinanceira
{
    public class CalculosFinanceirosService
    {

        // M�todo para calcular a �rea total do condom�nio
        public static decimal CalcularAreaTotalCondominio(IEnumerable<decimal> areasFracoes)
        {
            return areasFracoes.Sum();
        }

        // M�todo para calcular a permilagem de cada fra��o
        public static decimal CalcularPermilagem(decimal areaFracao, decimal areaTotalCondominio)
        {
            if (areaTotalCondominio <= 0)
                throw new ArgumentException("A �rea total do condom�nio deve ser maior que zero.");

            return (areaFracao / areaTotalCondominio) * 1000;
        }

        // M�todo para calcular a quota de condom�nio usando a f�rmula de permilagem
        public static decimal CalcularQuota(decimal orcamentoAnual, decimal permilagem)
        {
            return orcamentoAnual * (permilagem / 1000);
        }

        // M�todo para calcular a multa por atraso com base no valor da quota e nos dias de atraso
        public static decimal CalcularMulta(decimal valorQuota, int diasAtraso, decimal taxaMultaDiaria = 0.02m)
        {
            if (diasAtraso <= 0) return 0;
            return valorQuota * taxaMultaDiaria * diasAtraso;
        }

        // M�todo para gerar uma notifica��o de pagamento com base no prazo e na data atual
        public static string GerarNotificacaoPagamento(DateTime dataVencimento)
        {
            DateTime hoje = DateTime.Now;
            int diasRestantes = (dataVencimento - hoje).Days;

            if (diasRestantes > 0)
                return $"Aten��o: Faltam {diasRestantes} dias para o vencimento do pagamento.";
            else if (diasRestantes == 0)
                return "Aten��o: Hoje � o �ltimo dia para o pagamento da quota.";
            else
                return $"Aten��o: Pagamento em atraso h� {-diasRestantes} dias.";
        }


        public decimal CalcularTotal(List<decimal> valores)
        {
            decimal total = 0;
            foreach (var valor in valores)
            {
                total += valor;
            }
            return total;
        }

        // Outros m�todos...
    }
}
