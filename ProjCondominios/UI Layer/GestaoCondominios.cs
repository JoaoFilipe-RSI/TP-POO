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
    public partial class GestaoCondominios : Form
    {
        private readonly CondominioService _condominioService;
        private MenuPrincipal _menuPrincipal;

        public GestaoCondominios(CondominioService condominioService, MenuPrincipal menuPrincipal)
        {
            _condominioService = condominioService;
            _menuPrincipal = menuPrincipal;
            InitializeComponent();
            ConfigurarTamanho();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size; 
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = _menuPrincipal.Location; 
        }
        private void CarregarFormularioAdicionar()
        {
            pnlConteudo.Controls.Clear();

            Label lblTitAdd = new Label { Text = "ADICIONAR NOVO CONDOMÍNIO AO SISTEMA", Dock = DockStyle.Top };

            Label lblId = new Label { Text = "ID do Condomínio:", Dock = DockStyle.Top };
            TextBox txtId = new TextBox { Dock = DockStyle.Top, ReadOnly = true, Text = (_condominioService.Condominios.Count() + 1).ToString() };

            Label lblNome = new Label { Text = "Nome do Condomínio:", Dock = DockStyle.Top };
            TextBox txtNome = new TextBox { Dock = DockStyle.Top };

            Label lblEndereco = new Label { Text = "Endereço:", Dock = DockStyle.Top };
            TextBox txtEndereco = new TextBox { Dock = DockStyle.Top };

            Label lblTipo = new Label { Text = "Tipo de Condomínio:", Dock = DockStyle.Top };
            ComboBox cmbTipo = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = Enum.GetValues(typeof(TipoCondominio))
            };

            Label lblOrcamento = new Label { Text = "Orçamento Anual:", Dock = DockStyle.Top };
            TextBox txtOrcamento = new TextBox { Dock = DockStyle.Top };

            Button btnSalvar = new Button { Text = "Salvar", Dock = DockStyle.Top };
            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    var condominio = new Condominio(
                        txtNome.Text,
                        txtEndereco.Text,
                        (TipoCondominio)cmbTipo.SelectedItem,
                        decimal.Parse(txtOrcamento.Text)
                    );
                    _condominioService.AdicionarCondominio(condominio);
                    MessageBox.Show("Condomínio adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar condomínio: {ex.Message}");
                }
            };

            pnlConteudo.Controls.Add(btnSalvar);
            pnlConteudo.Controls.Add(txtOrcamento);
            pnlConteudo.Controls.Add(lblOrcamento);
            pnlConteudo.Controls.Add(cmbTipo);
            pnlConteudo.Controls.Add(lblTipo);
            pnlConteudo.Controls.Add(txtEndereco);
            pnlConteudo.Controls.Add(lblEndereco);
            pnlConteudo.Controls.Add(txtNome);
            pnlConteudo.Controls.Add(lblNome);
            pnlConteudo.Controls.Add(txtId);
            pnlConteudo.Controls.Add(lblId);
            pnlConteudo.Controls.Add(lblTitAdd);
        }

        private void CarregarFormularioRemover()
        {
            pnlConteudo.Controls.Clear();

            Label lblId = new Label { Text = "ID do Condomínio a Remover:", Dock = DockStyle.Top };
            TextBox txtId = new TextBox { Dock = DockStyle.Top };

            Button btnRemover = new Button { Text = "Remover", Dock = DockStyle.Top };
            btnRemover.Click += (s, e) =>
            {
                try
                {
                    var condominio = _condominioService.Condominios.FirstOrDefault(c => c.Id == int.Parse(txtId.Text));
                    if (condominio != null)
                    {
                        _condominioService.RemoverCondominio(condominio);
                        MessageBox.Show("Condomínio removido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Condomínio não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover condomínio: {ex.Message}");
                }
            };

            pnlConteudo.Controls.Add(btnRemover);
            pnlConteudo.Controls.Add(txtId);
            pnlConteudo.Controls.Add(lblId);
        }

        private void CarregarFormularioEditar()
        {
            pnlConteudo.Controls.Clear();

            Label lblMensagem = new Label { Text = "Formulário de Edição ainda não implementado", Dock = DockStyle.Top };
            pnlConteudo.Controls.Add(lblMensagem);
        }

        private void CarregarFormularioListar()
        {
            pnlConteudo.Controls.Clear();

            DataGridView dgvCondominios = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = _condominioService.Condominios.ToList()
            };
            pnlConteudo.Controls.Add(dgvCondominios);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CarregarFormularioAdicionar();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            CarregarFormularioRemover();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            CarregarFormularioEditar();
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            CarregarFormularioListar();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}