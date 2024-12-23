using System;
using System.Collections.Generic;
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
    public partial class GestaoCondominos : Form
    {
        private readonly CondominoService _condominoService;
        private MenuPrincipal _menuPrincipal;

        // Campos para controle de formulário
        private TextBox txtNome, txtNif, txtContato, txtId;
        private ComboBox cmbTipo;
        private Button btnSalvar;

        private Condomino _condominoAtual; // Usado para edição

        // Construtor
        public GestaoCondominos(CondominoService condominoService, MenuPrincipal menuPrincipal)
        {
            _condominoService = condominoService;
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

        // Evento Load
        private void GestaoCondominos_Load(object sender, EventArgs e)
        {
        
        }

        // ----------------------------- Botões Principais -----------------------------
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            CarregarFormularioAdicionar();
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            CarregarFormularioListar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            CarregarFormularioEditar();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            CarregarFormularioRemover();
        }

        private void BtnFecharCondominos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ----------------------------- Métodos de Carregamento -----------------------------

        private void CarregarFormularioAdicionar()
        {
            LimparPainel();

            // Título do formulário
            Label lblTitulo = CriarLabel("ADICIONAR CONDÓMINO", 12);
            pnlConteudoCondonimos.Controls.Add(lblTitulo);

            // Criar o formulário base (campos básicos: Nome, NIF, etc.)
            CriarFormularioBase();


            // Botão Salvar
            btnSalvar = new Button
            {
                Text = "Salvar",
                Dock = DockStyle.Top,
                Height = 25
            };
            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    // Criar e salvar o novo condômino
                    var novoCondomino = new Condomino
                    {
                        Nome = txtNome.Text,
                        NIF = txtNif.Text,
                        Contato = txtContato.Text,
                        TipoCondomino = (TipoCondomino)cmbTipo.SelectedItem
                    };

                    _condominoService.Adicionar(novoCondomino);

                    MessageBox.Show("Condómino adicionado com sucesso!");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o condómino: {ex.Message}");
                }
            };


            pnlConteudoCondonimos.Controls.AddRange(new Control[] { lblTitulo, btnSalvar });
        }

        private void CarregarFormularioListar()
        {
            LimparPainel();

            Label lblTitulo = CriarLabel("LISTA DE CONDÓMINOS", 12);
            DataGridView dgvCondominos = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                DataSource = _condominoService.ListarTodos().ToList(),
                ColumnHeadersVisible = true,
            };

            dgvCondominos.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvCondominos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pnlConteudoCondonimos.Controls.AddRange(new Control[] { lblTitulo, dgvCondominos });
        }

        private void CarregarFormularioEditar()
        {
            LimparPainel();

            Label lblTitulo = CriarLabel("EDITAR CONDÓMINO", 12);

            Label lblBuscarId = new Label { Text = "ID do Condómino:", Dock = DockStyle.Top };
            TextBox txtBuscarId = new TextBox { Dock = DockStyle.Top };

            Button btnBuscar = new Button { Text = "Buscar", Dock = DockStyle.Top };
            btnBuscar.Click += (s, e) =>
            {
                if (int.TryParse(txtBuscarId.Text, out int id))
                {
                    var condomino = _condominoService.BuscarPorId(id);
                    if (condomino != null)
                    {
                        _condominoAtual = condomino;
                        CarregarFormularioEdicao(condomino);
                    }
                    else
                    {
                        MessageBox.Show("Condómino não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Escolha  um ID válido.");
                }
            };

            pnlConteudoCondonimos.Controls.AddRange(new Control[] { lblTitulo, lblBuscarId, txtBuscarId, btnBuscar });
        }

        private void CarregarFormularioEdicao(Condomino condomino)
        {
            LimparPainel();

            Label lblTitulo = CriarLabel("EDITAR CONDÓMINO", 12);
            CriarFormularioBase();

            // Preencher os campos com os dados existentes
            txtId.Text = condomino.Id.ToString();
            txtNome.Text = condomino.Nome;
            txtNif.Text = condomino.NIF;
            txtContato.Text = condomino.Contato;
            cmbTipo.SelectedItem = condomino.TipoCondomino;

            btnSalvar = new Button { Text = "Salvar Alterações", Dock = DockStyle.Top };
            btnSalvar.Click += (s, e) =>
            {
                _condominoAtual.Nome = txtNome.Text;
                _condominoAtual.NIF = txtNif.Text;
                _condominoAtual.Contato = txtContato.Text;
                _condominoAtual.TipoCondomino = (TipoCondomino)cmbTipo.SelectedItem;

                _condominoService.Atualizar(_condominoAtual);
                MessageBox.Show("Condómino atualizado com sucesso!");
                CarregarFormularioListar();
            };

            pnlConteudoCondonimos.Controls.AddRange(new Control[] { lblTitulo, btnSalvar });
        }

        private void CarregarFormularioRemover()
        {
            LimparPainel();

            Label lblTitulo = CriarLabel("REMOVER CONDÓMINO", 12);
            Label lblId = new Label { Text = "ID do Condómino:", Dock = DockStyle.Top };
            TextBox txtId = new TextBox { Dock = DockStyle.Top };

            Button btnRemover = new Button { Text = "Remover", Dock = DockStyle.Top };
            btnRemover.Click += (s, e) =>
            {
                if (int.TryParse(txtId.Text, out int id))
                {
                    _condominoService.Remover(id);
                    MessageBox.Show("Condómino removido com sucesso!");
                    CarregarFormularioListar();
                }
                else
                {
                    MessageBox.Show("ID inválido.");
                }
            };

            pnlConteudoCondonimos.Controls.AddRange(new Control[] { lblTitulo, lblId, txtId, btnRemover });
        }

        // ----------------------------- Métodos Auxiliares -----------------------------

        private void LimparPainel()
        {
            pnlConteudoCondonimos.Controls.Clear();
        }

        private Label CriarLabel(string texto, int fontSize)
        {
            return new Label
            {
                Text = texto,
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Arial", fontSize, System.Drawing.FontStyle.Bold)
            };
        }

        private void CriarFormularioBase()
        {
            txtId = new TextBox { ReadOnly = true, Dock = DockStyle.Top };
            txtNome = new TextBox { Dock = DockStyle.Top };
            txtNif = new TextBox { Dock = DockStyle.Top };
            txtContato = new TextBox { Dock = DockStyle.Top };
            cmbTipo = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = Enum.GetValues(typeof(TipoCondomino))
            };

            pnlConteudoCondonimos.Controls.AddRange(new Control[]
            {
            new Label { Text = "Tipo:", Dock = DockStyle.Top }, cmbTipo,
            new Label { Text = "Contato:", Dock = DockStyle.Top }, txtContato,
            new Label { Text = "NIF:", Dock = DockStyle.Top }, txtNif,
            new Label { Text = "Nome:", Dock = DockStyle.Top }, txtNome,
            new Label { Text = "ID:", Dock = DockStyle.Top }, txtId
            });
        }

        private void AdicionarControlesAoPainel(params Control[] controles)
        {
            foreach (var controle in controles.Reverse())
            {
                pnlConteudoCondonimos.Controls.Add(controle);
            }
        }
    }
}