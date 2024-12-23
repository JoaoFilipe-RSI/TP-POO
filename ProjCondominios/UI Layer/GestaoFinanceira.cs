using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CalculadoraFinanceira; // DLL
using System.Globalization;
using ProjCondominios.Models;
using ProjCondominios.Services;


public partial class GestaoFinanceira : Form
{
    private readonly FinanceiroService _financeiroService;
    private Condominio _condominioAtual;

    public GestaoFinanceira(FinanceiroService financeiroService)
    {
        InitializeComponent();
        _financeiroService = financeiroService;
    }

    private void btnCalcularSaldo_Click(object sender, EventArgs e)
    {
        if (_condominioAtual == null)
        {
            MessageBox.Show("Selecione um condomínio antes de calcular o saldo.");
            return;
        }

        decimal saldo = _financeiroService.CalcularSaldoCondominio(_condominioAtual);
        MessageBox.Show($"O saldo do condomínio {_condominioAtual.Nome} é: {saldo:C}", "Saldo do Condomínio");
    }

    private void btnRelatorioFinanceiro_Click(object sender, EventArgs e)
    {
        if (_condominioAtual == null)
        {
            MessageBox.Show("Selecione um condomínio antes de gerar o relatório financeiro.");
            return;
        }

        string relatorio = GerarRelatorioFinanceiro();
    }

    private void btnCalcularBalanco_Click(object sender, EventArgs e)
    {
        if (_condominioAtual == null)
        {
            MessageBox.Show("Selecione um condomínio antes de calcular o balanço.");
            return;
        }

        List<decimal> receitas = _condominioAtual.Fracoes.Select(f => f.Quota).ToList();
        List<decimal> despesas = new List<decimal>(); 

        decimal balanco = _financeiroService.CalcularBalancoFinanceiro(receitas, despesas);
        MessageBox.Show($"O balanço financeiro do condomínio {_condominioAtual.Nome} é: {balanco:C}", "Balanço Financeiro");
    }

    private void BtnFechar_Click(object sender, EventArgs e)
    {
        this.Close();
    }


    public void SetCondominioAtual(Condominio condominio)
    {
        _condominioAtual = condominio;
        lblTitulo.Text = $"Gestão Financeira - {condominio.Nome}";
    }

    private string GerarRelatorioFinanceiro()
    {
        // Exemplo de como gerar um relatório financeiro simples
        var relatorio = $"Relatório Financeiro de {_condominioAtual.Nome}\n\n";
        relatorio += $"Orçamento Anual: {_condominioAtual.OrcamentoAnual:C}\n";

        // Aqui podemos adicionar outras informações como receitas, despesas e balanços
        decimal receitasTotais = _financeiroService.ObterTotalPagamentos(_condominioAtual);
        decimal despesasTotais = _financeiroService.ObterTotalDespesas(_condominioAtual);

        relatorio += $"Receitas Totais: {receitasTotais:C}\n";
        relatorio += $"Despesas Totais: {despesasTotais:C}\n";
        relatorio += $"Balanço Final: {receitasTotais - despesasTotais:C}\n";

        return relatorio;
    }
}
