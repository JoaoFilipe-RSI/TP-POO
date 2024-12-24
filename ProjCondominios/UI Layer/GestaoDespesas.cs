using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjCondominios.Enums;
using ProjCondominios.Models;
using ProjCondominios.Services;

namespace ProjCondominios.UI_Layer
{
    public partial class GestaoDespesas : Form
    {
        private DespesaService _despesaService;
        private List<Condominio> _condominios;
        private MenuPrincipal _menuPrincipal;
        private DataGridView dgvDespesas;
        private ComboBox cmbCondominio;
        private ComboBox cmbTipo;
        private TextBox txtValor;
        private DateTimePicker dtpData;

        public GestaoDespesas(DespesaService despesaService, List<Condominio> condominios, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _despesaService = despesaService;
            _condominios = condominios;
            _menuPrincipal = menuPrincipal;

            ConfigurarTamanho();
            ConfigurarPainelConteudo();
            AtualizarTabela();
            CarregarCondominios();
        }
        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size; // Ajusta o tamanho do formulário
            this.StartPosition = FormStartPosition.Manual; // Define a posição manualmente
            this.Location = _menuPrincipal.Location; // Ajusta a localização para coincidir com o MenuPrincipal
        }

        private void ConfigurarPainelConteudo()
        {
            pnlConteudo.Controls.Clear();

            dgvDespesas = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvDespesas.Columns.Add("Id", "ID");
            dgvDespesas.Columns.Add("Tipo", "Tipo");
            dgvDespesas.Columns.Add("Valor", "Valor");
            dgvDespesas.Columns.Add("Data", "Data");
            dgvDespesas.Columns.Add("Condominio", "Condomínio");
            pnlConteudo.Controls.Add(dgvDespesas);

            Label lblCondominio = new Label { Text = "Condomínio:", Top = 210, Left = 10 };
            cmbCondominio = new ComboBox { Top = 230, Left = 10, Width = 150 };
            pnlConteudo.Controls.Add(lblCondominio);
            pnlConteudo.Controls.Add(cmbCondominio);

            Label lblTipo = new Label { Text = "Tipo de Despesa:", Top = 210, Left = 180 };
            cmbTipo = new ComboBox { Top = 230, Left = 180, Width = 150 };
            cmbTipo.Items.AddRange(Enum.GetNames(typeof(TipoDespesa)));
            pnlConteudo.Controls.Add(lblTipo);
            pnlConteudo.Controls.Add(cmbTipo);

            Label lblValor = new Label { Text = "Valor:", Top = 260, Left = 10 };
            txtValor = new TextBox { Top = 280, Left = 10, Width = 150 };
            pnlConteudo.Controls.Add(lblValor);
            pnlConteudo.Controls.Add(txtValor);

            Label lblData = new Label { Text = "Data:", Top = 260, Left = 180 };
            dtpData = new DateTimePicker { Top = 280, Left = 180, Width = 150 };
            pnlConteudo.Controls.Add(lblData);
            pnlConteudo.Controls.Add(dtpData);
        }

        private void CarregarCondominios()
        {
            cmbCondominio.Items.Clear();

            if (_condominios == null || !_condominios.Any())
            {
                MessageBox.Show("Nenhum condomínio disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmbCondominio.Items.AddRange(_condominios.Select(c => c.Nome).ToArray());
        }

        private void AtualizarTabela()
        {
            dgvDespesas.Rows.Clear();
            var despesas = _despesaService.ListarDespesas();

            foreach (var despesa in despesas)
            {
                dgvDespesas.Rows.Add(
                    despesa.Id.ToString(),
                    despesa.Tipo.ToString(),
                    despesa.Valor.ToString("C"),
                    despesa.DataHoraDespesa.ToShortDateString(),
                    despesa.Condominio.Nome
                );
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cmbCondominio.SelectedIndex < 0 || cmbTipo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar.");
                return;
            }

            var condominioSelecionado = _condominios[cmbCondominio.SelectedIndex];
            var tipo = (TipoDespesa)Enum.Parse(typeof(TipoDespesa), cmbTipo.SelectedItem.ToString());
            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Valor inválido.");
                return;
            }
            var data = dtpData.Value;

            var novaDespesa = new Despesa(tipo, valor, condominioSelecionado, data);
            _despesaService.AdicionarDespesa(novaDespesa);

            MessageBox.Show("Despesa adicionada com sucesso!");
            AtualizarTabela();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvDespesas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma despesa para remover.");
                return;
            }

            var id = Guid.Parse(dgvDespesas.SelectedRows[0].Cells[0].Value.ToString());
            _despesaService.RemoverDespesa(id);

            MessageBox.Show("Despesa removida com sucesso!");
            AtualizarTabela();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDespesas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma despesa para editar.");
                return;
            }

            var id = Guid.Parse(dgvDespesas.SelectedRows[0].Cells[0].Value.ToString());
            var despesa = _despesaService.BuscarDespesaPorId(id);

            cmbCondominio.SelectedItem = despesa.Condominio.Nome;
            cmbTipo.SelectedItem = despesa.Tipo.ToString();
            txtValor.Text = despesa.Valor.ToString();
            dtpData.Value = despesa.DataHoraDespesa;

            _despesaService.RemoverDespesa(id); 
            MessageBox.Show("Edite os campos e clique em 'Adicionar' para salvar as alterações.");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void btnListarDespesasPorCondominio_Click(object sender, EventArgs e)
        {
            if (cmbCondominio.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um condomínio.");
                return;
            }

            var condominioSelecionado = _condominios[cmbCondominio.SelectedIndex];
            var despesas = _despesaService.ListarDespesasPorCondominio(condominioSelecionado);

            dgvDespesas.Rows.Clear();
            foreach (var despesa in despesas)
            {
                dgvDespesas.Rows.Add(
                    despesa.Id.ToString(),
                    despesa.Tipo.ToString(),
                    despesa.Valor.ToString("C"),
                    despesa.DataHoraDespesa.ToShortDateString(),
                    despesa.Condominio.Nome
                );
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}