using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CalculadoraFinanceira; // DLL
using System.Globalization;
using ProjCondominios.Models;
using ProjCondominios.Services;

namespace ProjCondominios.UI_Layer
{
    public partial class GestaoFinanceira : Form
    {
        private readonly FinanceiroService _financeiroService;
        private Condominio _condominioAtual;
        private readonly List<Condominio> _condominios;
        private MenuPrincipal _menuPrincipal;
        private Condominio _condominioSelecionado;
        private DataGridView dgvCondominios;

        public GestaoFinanceira(FinanceiroService financeiroService, List<Condominio> condominios, MenuPrincipal menuPrincipal)
        {

            _condominios = condominios;
            _financeiroService = financeiroService;
            _menuPrincipal = menuPrincipal;

            InitializeComponent();
            ConfigurarTamanho();
            CarregarCondominios();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = _menuPrincipal.Location;
        }
        private void CarregarCondominios()
        {
            if (_condominios == null || !_condominios.Any())
            {
                MessageBox.Show("Nenhum condomínio disponível.");
                return; // Impede a execução se a lista estiver vazia
            }

            // Limpa o painel antes de adicionar o DataGridView
            pnlConteudo.Controls.Clear();

            // Criação e configuração do DataGridView
            var dgvCondominios = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Vincula os dados ao DataGridView
            dgvCondominios.DataSource = _condominios.Select(c => new
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                Tipo = c.TipoCondominio,
            }).ToList();

            // Adiciona evento para manipular seleção
            dgvCondominios.CellDoubleClick += DgvCondominios_CellDoubleClick;

            // Adiciona o DataGridView ao painel
            pnlConteudo.Controls.Add(dgvCondominios);
        }
        private void DgvCondominios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv && e.RowIndex >= 0)
            {
                // Obtém o nome do condomínio selecionado
                string nomeCondominio = dgv.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                MessageBox.Show($"Condomínio selecionado: {nomeCondominio}");

                // Aqui, você pode implementar a lógica para carregar os detalhes do condomínio selecionado
            }
        }
        private void dgvCondominios_SelectionChanged(object sender, EventArgs e)
        {// Verifica se há uma linha válida selecionada
            if (dgvCondominios.CurrentRow != null)
            {
                // Obtém o ID do condomínio da célula "Id"
                int idCondominio = Convert.ToInt32(dgvCondominios.CurrentRow.Cells["Id"].Value);

                // Localiza o condomínio na lista
                _condominioSelecionado = _condominios.FirstOrDefault(c => c.Id == idCondominio);
            }
        }

        private void btnCalcularSaldo_Click(object sender, EventArgs e)
        {
            if (_condominioAtual == null)
            {
                MessageBox.Show("Selecione um condomínio antes de calcular o saldo.");
                return;
            }

            decimal saldo = _financeiroService.CalcularSaldoCondominio(_condominioSelecionado);
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
            // relatório financeiro simples
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

        private void pnlConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
