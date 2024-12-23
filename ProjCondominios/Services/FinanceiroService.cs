using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using ProjCondominios.Enums;
using ProjCondominios.Interfaces;
using CalculadoraFinanceira; // Referência à DLL


namespace ProjCondominios.Services
{
    public class FinanceiroService
    {
        #region Propriedades Privadas

        private readonly PagamentoService _pagamentoService;
        private readonly DespesaService _despesaService;
        private readonly CalculosFinanceirosService _calculadoraFinanceira;

        #endregion

        #region Construtores

        public FinanceiroService(PagamentoService pagamentoService, DespesaService despesaService, CalculosFinanceirosService calculadoraFinanceira)
        {
            _pagamentoService = pagamentoService ?? throw new ArgumentNullException(nameof(pagamentoService));
            _despesaService = despesaService ?? throw new ArgumentNullException(nameof(despesaService));
            _calculadoraFinanceira = calculadoraFinanceira ?? new CalculosFinanceirosService();
        }

        #endregion

        #region Métodos

        // Método para calcular o saldo total de um condomínio específico
        public decimal CalcularSaldoCondominio(Condominio condominio)
        {
            if (condominio == null)
                throw new ArgumentNullException(nameof(condominio));

            decimal totalPagamentos = ObterTotalPagamentos(condominio);
            decimal totalDespesas = ObterTotalDespesas(condominio);
          
            return totalPagamentos - totalDespesas;   // Saldo 
        }

        // Obter total de pagamentos para o condomínio especificado através do serviço de pagamentos
        public decimal ObterTotalPagamentos(Condominio condominio)
        {
            var pagamentos = _pagamentoService.ListarPagamentosPorCondominio(condominio);
            decimal totalPagamentos = 0;

            foreach (var pagamento in pagamentos)
            {
                totalPagamentos += pagamento.ValorQuota;
            }

            return totalPagamentos;
        }

        // Obter total de despesas para o condomínio especificado através do serviço de despesas
        public decimal ObterTotalDespesas(Condominio condominio)
        {
            var despesas = _despesaService.ListarDespesasPorCondominio(condominio);
            decimal totalDespesas = 0;

            foreach (var despesa in despesas)
            {
                totalDespesas += despesa.Valor;
            }

            return totalDespesas;
        }

        // Método para calcular o total de despesas e receitas de todos os condominios
        public decimal CalcularBalancoFinanceiro(List<decimal> receitas, List<decimal> despesas)
        {
            decimal totalReceitas = _calculadoraFinanceira.CalcularTotal(receitas);
            decimal totalDespesas = _calculadoraFinanceira.CalcularTotal(despesas);
            return totalReceitas - totalDespesas;
        }

        // Método para gerar um relatório financeiro básico do condomínio
        public string GerarRelatorioFinanceiro(Condominio condominio)
        {
            decimal saldo = CalcularSaldoCondominio(condominio);
            string relatorio = $"Relatório Financeiro - {condominio.Nome}\n";
            relatorio += "====================================\n";
            relatorio += $"Saldo Atual: {saldo:C}\n";
            relatorio += $"Total de Pagamentos: {ObterTotalPagamentos(condominio):C}\n";
            relatorio += $"Total de Despesas: {ObterTotalDespesas(condominio):C}\n";
            relatorio += "------------------------------------\n";

            return relatorio;
        }
        #endregion

        // Relatórios detalhados por período (por exemplo, despesas e receitas mensais).
        // Notificações de saldo negativo, caso as despesas superem os pagamentos.

    }
}
