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
using static System.Windows.Forms.MonthCalendar;

namespace ProjCondominios.UI_Layer
{
    public partial class GestaoFracoes : Form
    {
        private readonly FracaoAutonomaService _fracaoService;
        private readonly CondominioService _condominioService;
        private readonly CondominoService _condominoService;
        private MenuPrincipal _menuPrincipal;
        private DataGridView dgvFracoes;

        public GestaoFracoes(FracaoAutonomaService fracaoService, CondominioService condominioService, CondominoService condominoService, MenuPrincipal menuPrincipal)
        {
            _fracaoService = fracaoService;
            _condominioService = condominioService;
            _condominoService = condominoService;
            _menuPrincipal = menuPrincipal;

            InitializeComponent();
            ConfigurarTamanho();
            InicializarComponentesPersonalizados();
            ConfigurarTamanho();
            CarregarFracoes();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = _menuPrincipal.Location;
        }

        private void CarregarFormularioAdicionar()
        {
            pnlConteudoFracoes.Controls.Clear();

            Label lblTitulo = new Label { Text = "ADICIONAR NOVA FRAÇÃO AUTÓNOMA", Dock = DockStyle.Top };

            Label lblId = new Label { Text = "Identificação da Fração:", Dock = DockStyle.Top };
            TextBox txtId = new TextBox { Dock = DockStyle.Top };

            Label lblArea = new Label { Text = "Área (m²):", Dock = DockStyle.Top };
            TextBox txtArea = new TextBox { Dock = DockStyle.Top };

            Label lblPermilagem = new Label { Text = "Permilagem:", Dock = DockStyle.Top };
            TextBox txtPermilagem = new TextBox { Dock = DockStyle.Top };

            Label lblQuota = new Label { Text = "Quota:", Dock = DockStyle.Top };
            TextBox txtQuota = new TextBox { Dock = DockStyle.Top };

            Label lblTipoFracao = new Label { Text = "Tipo de Fração:", Dock = DockStyle.Top };
            ComboBox cmbTipoFracao = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = Enum.GetValues(typeof(TipoFracao))
            };

            Label lblCondominio = new Label { Text = "Condomínio:", Dock = DockStyle.Top };
            ComboBox cmbCondominio = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _condominioService.Condominios.ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Label lblProprietario = new Label { Text = "Proprietário:", Dock = DockStyle.Top };
            ComboBox cmbProprietario = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _condominoService.ListarTodos()
                    .Where(c => c.TipoCondomino == TipoCondomino.Proprietario)
                    .ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Label lblInquilino = new Label { Text = "Inquilino (Opcional):", Dock = DockStyle.Top };
            ComboBox cmbInquilino = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = new List<object>
        {
            new { Nome = "N/A", Id = 0 } // Adiciona a opção N/A
        }
                .Concat(_condominoService.ListarTodos()
                        .Where(c => c.IsInquilino) // Filtra apenas os inquilinos
                        .Select(c => new { c.Nome, c.Id }))
                .ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Button btnSalvar = new Button { Text = "Salvar", Dock = DockStyle.Top };
            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    string identificacao = txtId.Text;
                    if (string.IsNullOrWhiteSpace(identificacao))
                    {
                        MessageBox.Show("Identificação é obrigatória.");
                        return;
                    }

                    if (!decimal.TryParse(txtArea.Text, out decimal area) || area <= 0)
                    {
                        MessageBox.Show("Área deve ser um valor positivo.");
                        return;
                    }

                    if (!decimal.TryParse(txtPermilagem.Text, out decimal permilagem) || permilagem <= 0)
                    {
                        MessageBox.Show("Permilagem deve ser um valor positivo.");
                        return;
                    }

                    if (!decimal.TryParse(txtQuota.Text, out decimal quota) || quota < 0)
                    {
                        MessageBox.Show("Quota deve ser um valor positivo ou zero.");
                        return;
                    }

                    if (cmbTipoFracao.SelectedItem is not TipoFracao tipoFracao)
                    {
                        MessageBox.Show("Selecione um tipo de fração válido.");
                        return;
                    }

                    if (cmbCondominio.SelectedItem is not Condominio condominio)
                    {
                        MessageBox.Show("Selecione um condomínio válido.");
                        return;
                    }

                    if (cmbProprietario.SelectedItem is not Condomino proprietario)
                    {
                        MessageBox.Show("Selecione um proprietário válido.");
                        return;
                    }

                    Condomino? inquilino = cmbInquilino.SelectedItem as Condomino;

                    int? inquilinoId = (inquilino != null && inquilino.Nome != "N/A") ? inquilino.Id : null;

                    // Criar a nova fração associando os objetos relacionados
                    _fracaoService.AdicionarFracao(
                        identificacao, area, permilagem, quota, tipoFracao,
                        condominio.Id, proprietario.Id, inquilino?.Id);

                    SalvarFracoes();

                    MessageBox.Show("Fração adicionada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar fração: {ex.Message}");
                }
            };

            pnlConteudoFracoes.Controls.AddRange(new Control[]

            {
                btnSalvar, cmbInquilino, lblInquilino, cmbProprietario, lblProprietario,
                cmbCondominio, lblCondominio, cmbTipoFracao, lblTipoFracao, txtQuota, lblQuota, txtPermilagem, lblPermilagem, txtArea, lblArea,
                txtId, lblId, lblTitulo
            });
        }

        private void CarregarFormularioListar()
        {
            pnlConteudoFracoes.Controls.Clear();

            Label lblSelecioneCondominio = new Label
            {
                Text = "Selecione um condomínio para listar as frações:",
                Dock = DockStyle.Top
            };

            ComboBox cmbCondominios = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _condominioService.Condominios.ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Button btnListarFracoes = new Button
            {
                Text = "Listar Frações",
                Dock = DockStyle.Top
            };

            DataGridView dgvFracoes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true
            };

            btnListarFracoes.Click += (s, e) =>
            {
                if (cmbCondominios.SelectedItem is Condominio condominioSelecionado)
                {
                    var fracoesDetalhadas = _fracaoService
                        .ListarFracoesPorCondominio(condominioSelecionado.Id)
                        .Select(fracao => new
                        {
                            Identificacao = fracao.Identificacao,
                            Condominio = fracao.Condominio?.Nome ?? "N/D",
                            Proprietario = fracao.Proprietario?.Nome ?? "N/D",
                            Inquilino = fracao.Inquilino?.Nome ?? "Sem Inquilino",
                            Tipo = fracao.TipoFracao.ToString(),
                            Area = $"{fracao.Area:F2} m²",
                            Permilagem = $"{fracao.Permilagem:F2}‰",
                            Quota = $"{fracao.Quota:C}"
                        }).ToList();

                    dgvFracoes.DataSource = fracoesDetalhadas;

                    if (!fracoesDetalhadas.Any())
                    {
                        MessageBox.Show("Este condomínio não possui frações cadastradas.", "Informação");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um condomínio.", "Aviso");
                }
            };

            pnlConteudoFracoes.Controls.Add(dgvFracoes);
            pnlConteudoFracoes.Controls.Add(btnListarFracoes);
            pnlConteudoFracoes.Controls.Add(cmbCondominios);
            pnlConteudoFracoes.Controls.Add(lblSelecioneCondominio);
        }

        private void CarregarFormularioRemover()
        {
            pnlConteudoFracoes.Controls.Clear();

            Label lblCondominio = new Label
            {
                Text = "Selecione o Condomínio:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft
            };

            ComboBox cmbCondominios = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label lblFracao = new Label
            {
                Text = "Selecione a Fração:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft
            };

            ComboBox cmbFracoes = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = false
            };

            Button btnRemover = new Button
            {
                Text = "Remover",
                Dock = DockStyle.Top,
                Enabled = false 
            };

            var condominios = _condominioService.Condominios.ToList();

            cmbCondominios.Items.Clear(); 
            if (condominios.Any())
            {
                cmbCondominios.DataSource = condominios;
                cmbCondominios.DisplayMember = "Nome";
                cmbCondominios.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Nenhum condomínio encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cmbCondominios.SelectedIndexChanged += (s, e) =>
            {
                if (cmbCondominios.SelectedItem is Condominio condominioSelecionado)
                {
                    var fracoes = _fracaoService.ListarFracoesPorCondominio(condominioSelecionado.Id);

                    cmbFracoes.Items.Clear();

                    if (fracoes.Any())
                    {
                        cmbFracoes.DataSource = fracoes;
                        cmbFracoes.DisplayMember = "Identificacao";
                        cmbFracoes.ValueMember = "Identificacao";
                        cmbFracoes.Enabled = true;
                        btnRemover.Enabled = false;
                    }
                    else
                    {
                        cmbFracoes.Items.Clear();
                        cmbFracoes.Enabled = false;
                        btnRemover.Enabled = false;
                    }
                }
            };

            // Evento para habilitar o botão de remover ao selecionar uma fração
            cmbFracoes.SelectedIndexChanged += (s, e) =>
            {
                btnRemover.Enabled = cmbFracoes.SelectedIndex >= 0;
            };

            btnRemover.Click += (s, e) =>
            {
                if (cmbCondominios.SelectedItem is Condominio condominioSelecionado &&
                    cmbFracoes.SelectedItem is FracaoAutonoma fracaoSelecionada)
                {
                    bool sucesso = _fracaoService.RemoverFracao(condominioSelecionado.Id, fracaoSelecionada.Identificacao);

                    if (sucesso)
                    {
                        MessageBox.Show("Fração removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var fracoesAtualizadas = _fracaoService.ListarFracoesPorCondominio(condominioSelecionado.Id);
                        cmbFracoes.DataSource = fracoesAtualizadas;

                        if (fracoesAtualizadas.Any())
                        {
                            cmbFracoes.DisplayMember = "Identificacao";
                            cmbFracoes.ValueMember = "Identificacao";
                            cmbFracoes.Enabled = true;
                        }
                        else
                        {
                            cmbFracoes.Enabled = false;
                            btnRemover.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover a fração!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            pnlConteudoFracoes.Controls.Add(btnRemover);
            pnlConteudoFracoes.Controls.Add(cmbFracoes);
            pnlConteudoFracoes.Controls.Add(lblFracao);
            pnlConteudoFracoes.Controls.Add(cmbCondominios);
            pnlConteudoFracoes.Controls.Add(lblCondominio);
        }

        private void CarregarFormularioListarTodos()
        {
            pnlConteudoFracoes.Controls.Clear();

            DataGridView dgvFracoes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                DataSource = _fracaoService.ListarTodasFracoes().Select(fracao => new
                {
                    Identificacao = fracao.Identificacao,
                    Area = fracao.Area.ToString("F2") + " m²",
                    Permilagem = fracao.Permilagem.ToString("F2") + "‰",
                    Quota = fracao.Quota.ToString("C"),
                    Tipo = fracao.TipoFracao.ToString(),
                    Condominio = fracao.Condominio?.Nome ?? "N/A",
                    Proprietario = fracao.Proprietario?.Nome ?? "N/A",
                    Inquilino = fracao.Inquilino?.Nome ?? "N/A"
                }).ToList()
            };

            pnlConteudoFracoes.Controls.Add(dgvFracoes);
        }

        private void CarregarFormularioEditar()
        {
            pnlConteudoFracoes.Controls.Clear();

            Label lblTitulo = new Label
            {
                Text = "EDITAR FRAÇÃO AUTÓNOMA",
                Dock = DockStyle.Top,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            Label lblSelecionar = new Label { Text = "Selecionar Fração:", Dock = DockStyle.Top };
            ComboBox cmbFracao = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _fracaoService.ListarTodasFracoes(),
                DisplayMember = "Identificacao"
            };

            Label lblArea = new Label { Text = "Área:", Dock = DockStyle.Top };
            TextBox txtArea = new TextBox { Dock = DockStyle.Top };

            Label lblPermilagem = new Label { Text = "Permilagem:", Dock = DockStyle.Top };
            TextBox txtPermilagem = new TextBox { Dock = DockStyle.Top };

            Label lblQuota = new Label { Text = "Quota:", Dock = DockStyle.Top };
            TextBox txtQuota = new TextBox { Dock = DockStyle.Top };

            Label lblTipo = new Label { Text = "Tipo de Fração:", Dock = DockStyle.Top };
            ComboBox cmbTipo = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = Enum.GetValues(typeof(TipoFracao))
            };

            Label lblCondominio = new Label { Text = "Condomínio:", Dock = DockStyle.Top };
            ComboBox cmbCondominio = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _condominioService.Condominios,
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Label lblProprietario = new Label { Text = "Proprietário:", Dock = DockStyle.Top };
            ComboBox cmbProprietario = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = _condominoService.ListarTodos()
                    .Where(c => c.TipoCondomino == TipoCondomino.Proprietario)
                    .ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Label lblInquilino = new Label { Text = "Inquilino (Opcional):", Dock = DockStyle.Top };
            ComboBox cmbInquilino = new ComboBox
            {
                Dock = DockStyle.Top,
                DataSource = new List<object>
        {
            new { Nome = "N/A", Id = 0 } // Adiciona a opção N/A
        }
                .Concat(_condominoService.ListarTodos()
                        .Where(c => c.IsInquilino) // Filtra apenas os inquilinos
                        .Select(c => new { c.Nome, c.Id }))
                .ToList(),
                DisplayMember = "Nome",
                ValueMember = "Id"
            };

            Button btnSalvar = new Button { Text = "Salvar Alterações", Dock = DockStyle.Top };

            cmbFracao.SelectedIndexChanged += (s, e) =>
            {
                var fracaoSelecionada = cmbFracao.SelectedItem as FracaoAutonoma;

                if (fracaoSelecionada != null)
                {
                    txtArea.Text = fracaoSelecionada.Area.ToString();
                    txtPermilagem.Text = fracaoSelecionada.Permilagem.ToString();
                    txtQuota.Text = fracaoSelecionada.Quota.ToString();
                    cmbTipo.SelectedItem = fracaoSelecionada.TipoFracao;
                    cmbCondominio.SelectedValue = fracaoSelecionada.CondominioId;
                    cmbProprietario.SelectedValue = fracaoSelecionada.ProprietarioId;
                    cmbInquilino.SelectedValue = fracaoSelecionada.InquilinoId ?? 0; // Seleciona "N/A" se InquilinoId for null
                }
            };

            btnSalvar.Click += (s, e) =>
            {
                try
                {
                    var fracaoSelecionada = cmbFracao.SelectedItem as FracaoAutonoma;
                    if (fracaoSelecionada == null)
                    {
                        MessageBox.Show("Por favor, selecione uma fração.");
                        return;
                    }

                    decimal novaArea = decimal.Parse(txtArea.Text);
                    decimal novaPermilagem = decimal.Parse(txtPermilagem.Text);
                    decimal novaQuota = decimal.Parse(txtQuota.Text);
                    TipoFracao novoTipo = (TipoFracao)cmbTipo.SelectedItem;
                    int novoCondominioId = (int)cmbCondominio.SelectedValue;
                    int novoProprietarioId = (int)cmbProprietario.SelectedValue;
                    int? novoInquilinoId = cmbInquilino.SelectedValue.ToString() == "N/A" ? null : (int?)cmbInquilino.SelectedValue;

                    _fracaoService.AtualizarFracao(
                        fracaoSelecionada.Identificacao,
                        novaArea,
                        novaPermilagem,
                        novaQuota,
                        novoCondominioId,
                        novoProprietarioId,
                        novoInquilinoId
                    );

                    cmbFracao.DataSource = null;
                    cmbFracao.DataSource = _fracaoService.ListarTodasFracoes();
                    cmbFracao.DisplayMember = "Identificacao";

                    MessageBox.Show("Fração atualizada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar alterações: {ex.Message}");
                }
            };

            pnlConteudoFracoes.Controls.Add(btnSalvar);
            pnlConteudoFracoes.Controls.Add(cmbInquilino);
            pnlConteudoFracoes.Controls.Add(lblInquilino);
            pnlConteudoFracoes.Controls.Add(cmbProprietario);
            pnlConteudoFracoes.Controls.Add(lblProprietario);
            pnlConteudoFracoes.Controls.Add(cmbCondominio);
            pnlConteudoFracoes.Controls.Add(lblCondominio);
            pnlConteudoFracoes.Controls.Add(txtQuota);
            pnlConteudoFracoes.Controls.Add(lblQuota);
            pnlConteudoFracoes.Controls.Add(cmbTipo);
            pnlConteudoFracoes.Controls.Add(lblTipo);
            pnlConteudoFracoes.Controls.Add(txtPermilagem);
            pnlConteudoFracoes.Controls.Add(lblPermilagem);
            pnlConteudoFracoes.Controls.Add(txtArea);
            pnlConteudoFracoes.Controls.Add(lblArea);
            pnlConteudoFracoes.Controls.Add(cmbFracao);
            pnlConteudoFracoes.Controls.Add(lblSelecionar);
            pnlConteudoFracoes.Controls.Add(lblTitulo);
        }

        private void InicializarComponentesPersonalizados()
        {
            dgvFracoes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            pnlConteudoFracoes.Controls.Clear();
            //pnlConteudoFracoes.Controls.Add(dgvFracoes);
        }

        private void AtualizarListaFracoes(List<FracaoAutonoma> fracoes)
        {
            dgvFracoes.DataSource = null;
            dgvFracoes.DataSource = fracoes;
        }

        private List<FracaoAutonoma> ObterListaFracoes()
        {
            return (List<FracaoAutonoma>)dgvFracoes.DataSource;
        }

        private void CarregarFracoes()
        {
            try
            {
                var fracoes = _fracaoService.CarregarFracoes();
                AtualizarListaFracoes(fracoes); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar frações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarFracoes()
        {
            try
            {
                var fracoes = _fracaoService.ListarTodasFracoes();
                _fracaoService.SalvarFracoes(fracoes);
                MessageBox.Show("Frações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar frações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CarregarFormularioAdicionar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            CarregarFormularioRemover();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CarregarFormularioEditar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregarFormularioListar();
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            CarregarFormularioListarTodos();
        }
    }
}