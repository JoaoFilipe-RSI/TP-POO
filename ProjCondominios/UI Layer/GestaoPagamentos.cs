using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjCondominios.Models;
using ProjCondominios.Services;

namespace ProjCondominios.UI_Layer
{
    public partial class GestaoPagamentos : Form
    {
        private readonly PagamentoService _pagamentoService;
        private readonly List<Condominio> _condominios;
        private readonly MenuPrincipal _menuPrincipal;

        public GestaoPagamentos(PagamentoService pagamentoService, List<Condominio> condominios, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _pagamentoService = pagamentoService;
            _condominios = condominios; 
            _menuPrincipal = menuPrincipal; 

            ConfigurarTamanho();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = _menuPrincipal.Location;
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MostrarFormularioAdicionarPagamento();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarFormularioEditarPagamento();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            MostrarFormularioRemoverPagamento();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarPagamentos();
        }

        #region Métodos para exibição de formulários dinâmicos no painel

        private void MostrarFormularioAdicionarPagamento()
        {
            LimparPainelConteudo();

            var lblCondominio = new Label { Text = "Condomínio:", Top = 20, Left = 20, Width = 100 };
            var cmbCondominio = new ComboBox { Top = 40, Left = 20, Width = 200 };

            cmbCondominio.DataSource = _condominios; 
            cmbCondominio.DisplayMember = "Nome";
            cmbCondominio.ValueMember = "Id";

            var lblCondomino = new Label { Text = "Condómino:", Top = 80, Left = 20, Width = 100 };
            var cmbCondomino = new ComboBox { Top = 100, Left = 20, Width = 200 };

            cmbCondominio.SelectedIndexChanged += (s, e) =>
            {
                AtualizarCondominos(cmbCondominio, cmbCondomino);
            };

            this.Controls.Add(lblCondominio);
            this.Controls.Add(cmbCondominio);
            this.Controls.Add(lblCondomino);
            this.Controls.Add(cmbCondomino);

            AtualizarCondominos(cmbCondominio, cmbCondomino);

            var lblDescricao = new Label { Text = "Descrição (Mês):", Top = 140, Left = 20, Width = 150 };
            var txtDescricao = new TextBox { Top = 160, Left = 20, Width = 200 };

            var lblValor = new Label { Text = "Valor da Quota (€):", Top = 200, Left = 20, Width = 150 };
            var txtValor = new TextBox { Top = 220, Left = 20, Width = 200 };

            var lblDataHora = new Label { Text = "Data do Pagamento:", Top = 260, Left = 20, Width = 150 };
            var dtpDataHora = new DateTimePicker { Top = 280, Left = 20, Width = 200, Format = DateTimePickerFormat.Short };

            var btnSalvar = new Button { Text = "Registar Pagamento", Top = 340, Left = 20, Width = 200 };
            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    var pagamento = new Pagamento(
                        decimal.Parse(txtValor.Text),
                        txtDescricao.Text,
                        (Condominio)cmbCondominio.SelectedItem,
                        (Condomino)cmbCondomino.SelectedItem,
                        dtpDataHora.Value
                    );
                    _pagamentoService.AdicionarPagamento(pagamento);
                    MessageBox.Show("Pagamento registrado com sucesso!");
                    LimparPainelConteudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao registrar pagamento: {ex.Message}");
                }
            };

            pnlConteudo.Controls.AddRange(new Control[] {
        lblCondominio, cmbCondominio, lblCondomino, cmbCondomino,
        lblDescricao, txtDescricao, lblValor, txtValor,
        lblDataHora, dtpDataHora, btnSalvar
    });
        }

        private void AtualizarCondominos(ComboBox cmbCondominio, ComboBox cmbCondomino)
        {
            if (cmbCondominio.SelectedValue != null)
            {
                int condominioId;

                if (int.TryParse(cmbCondominio.SelectedValue.ToString(), out condominioId))
                {
                    var condominioSelecionado = _condominios.FirstOrDefault(c => c.Id == condominioId);

                    if (condominioSelecionado != null)
                    {
                        cmbCondomino.DataSource = condominioSelecionado.Condominos.ToList();
                        cmbCondomino.DisplayMember = "Nome";
                        cmbCondomino.ValueMember = "Id";
                        return;
                    }
                }
            }
            // Se não houver condomínio selecionado ou condôminos, limpa a ComboBox
            cmbCondomino.DataSource = null;
        }

        private void MostrarFormularioEditarPagamento()
        {
            LimparPainelConteudo();

            var lblPagamento = new Label { Text = "Selecione um Pagamento:", Top = 20, Left = 20, Width = 200 };
            var cmbPagamentos = new ComboBox { Top = 40, Left = 20, Width = 300 };
            cmbPagamentos.DataSource = _pagamentoService.ListarPagamentos();
            cmbPagamentos.DisplayMember = "Descricao";
            cmbPagamentos.ValueMember = "Id";

            var lblNovoValor = new Label { Text = "Novo Valor (€):", Top = 80, Left = 20, Width = 200 };
            var txtNovoValor = new TextBox { Top = 100, Left = 20, Width = 200 };

            var btnSalvar = new Button { Text = "Salvar Alterações", Top = 140, Left = 20, Width = 200 };
            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    var pagamentoSelecionado = (Pagamento)cmbPagamentos.SelectedItem;
                    pagamentoSelecionado.ValorQuota = decimal.Parse(txtNovoValor.Text);
                    MessageBox.Show("Pagamento atualizado com sucesso!");
                    LimparPainelConteudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar pagamento: {ex.Message}");
                }
            };

            pnlConteudo.Controls.AddRange(new Control[] { lblPagamento, cmbPagamentos, lblNovoValor, txtNovoValor, btnSalvar });
        }

        private void MostrarFormularioRemoverPagamento()
        {
            LimparPainelConteudo();

            var lblPagamento = new Label { Text = "Selecione um Pagamento para remover:", Top = 20, Left = 20, Width = 300 };
            var cmbPagamentos = new ComboBox { Top = 40, Left = 20, Width = 300 };
            cmbPagamentos.DataSource = _pagamentoService.ListarPagamentos();
            cmbPagamentos.DisplayMember = "Descricao";
            cmbPagamentos.ValueMember = "Id";

            var btnRemover = new Button { Text = "Remover Pagamento", Top = 80, Left = 20, Width = 200 };
            btnRemover.Click += (s, e) =>
            {
                try
                {
                    var pagamentoSelecionado = (Pagamento)cmbPagamentos.SelectedItem;
                    _pagamentoService.RemoverPagamento(pagamentoSelecionado.Id);
                    MessageBox.Show("Pagamento removido com sucesso!");
                    LimparPainelConteudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover pagamento: {ex.Message}");
                }
            };

            pnlConteudo.Controls.AddRange(new Control[] { lblPagamento, cmbPagamentos, btnRemover });
        }

       private void ListarPagamentos()
{
    try
    {
        var pagamentos = _pagamentoService.ListarPagamentos();

        if (dgvPagamentos.Columns.Count == 0)
        {
            dgvPagamentos.Columns.Add("Descricao", "Descrição");
            dgvPagamentos.Columns.Add("Valor", "Valor");
            dgvPagamentos.Columns.Add("Condominio", "Condomínio");
            dgvPagamentos.Columns.Add("Condomino", "Condómino");
            dgvPagamentos.Columns.Add("Data", "Data");
        }
        dgvPagamentos.Rows.Clear();

        foreach (var pagamento in pagamentos)
        {
            dgvPagamentos.Rows.Add(
                pagamento.Descricao ?? "N/A",
                pagamento.ValorQuota.ToString("C"),
                pagamento.Condominio?.Nome ?? "N/A", 
                pagamento.Condomino?.Nome ?? "N/A", 
                pagamento.DataHoraPagamento.ToString("dd/MM/yyyy")
            );
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erro ao listar pagamentos: {ex.Message}");
    }
}

        private void LimparPainelConteudo()
        {
            pnlConteudo.Controls.Clear();
        }

        #endregion
    }
}
