
using System;


namespace CalculadoraFinanceira
{
    public class CalculosFinanceirosService
    {

        // Método para calcular a área total do condomínio
        public static decimal CalcularAreaTotalCondominio(IEnumerable<decimal> areasFracoes)
        {
            return areasFracoes.Sum();
        }

        // Método para calcular a permilagem de cada fração
        public static decimal CalcularPermilagem(decimal areaFracao, decimal areaTotalCondominio)
        {
            if (areaTotalCondominio <= 0)
                throw new ArgumentException("A área total do condomínio deve ser maior que zero.");

            return (areaFracao / areaTotalCondominio) * 1000;
        }

        // Método para calcular a quota de condomínio usando a fórmula de permilagem
        public static decimal CalcularQuota(decimal orcamentoAnual, decimal permilagem)
        {
            return orcamentoAnual * (permilagem / 1000);
        }

        // Método para calcular a multa por atraso com base no valor da quota e nos dias de atraso
        public static decimal CalcularMulta(decimal valorQuota, int diasAtraso, decimal taxaMultaDiaria = 0.02m)
        {
            if (diasAtraso <= 0) return 0;
            return valorQuota * taxaMultaDiaria * diasAtraso;
        }

        // Método para gerar uma notificação de pagamento com base no prazo e na data atual
        public static string GerarNotificacaoPagamento(DateTime dataVencimento)
        {
            DateTime hoje = DateTime.Now;
            int diasRestantes = (dataVencimento - hoje).Days;

            if (diasRestantes > 0)
                return $"Atenção: Faltam {diasRestantes} dias para o vencimento do pagamento.";
            else if (diasRestantes == 0)
                return "Atenção: Hoje é o último dia para o pagamento da quota.";
            else
                return $"Atenção: Pagamento em atraso há {-diasRestantes} dias.";
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
    }
}
