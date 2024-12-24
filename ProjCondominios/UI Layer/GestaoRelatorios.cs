using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjCondominios.Interfaces;
using ProjCondominios.Services;

namespace ProjCondominios.UI_Layer
{
    public partial class GestaoRelatorios : Form
    {
        private readonly IRelatorioService _relatorioService;
        private MenuPrincipal _menuPrincipal;

        public GestaoRelatorios(IRelatorioService relatorioService, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _menuPrincipal = menuPrincipal;
            _relatorioService = relatorioService;
            ConfigurarTamanho();
        }

        #region Métodos Auxiliares
        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = _menuPrincipal.Location;
        }

        private void LimparPainelConteudo()
        {
            pnlConteudo.Controls.Clear();
        }

        private void ExibirRelatorio(string titulo, string conteudo)
        {
            LimparPainelConteudo();

            var lblTituloRelatorio = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30
            };

            var txtRelatorio = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Text = conteudo
            };

            pnlConteudo.Controls.Add(txtRelatorio);
            pnlConteudo.Controls.Add(lblTituloRelatorio);
        }
        #endregion

        #region Eventos de Botões

        private void btnGerarRelatorioPagamentos_Click(object sender, EventArgs e)
        {
            try
            {
                var relatorio = _relatorioService?.GerarRelatorioPagamentos();
                ExibirRelatorio("Relatório de Pagamentos", relatorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório de pagamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorioDespesas_Click(object sender, EventArgs e)
        {
            try
            {
                string relatorio = _relatorioService.GerarRelatorioDespesas();
                ExibirRelatorio("Relatório de Despesas", relatorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório de despesas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorioFinanceiro_Click(object sender, EventArgs e)
        {
            try
            {
                string relatorio = _relatorioService.GerarRelatorioFinanceiro();
                ExibirRelatorio("Relatório Financeiro", relatorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório financeiro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorioReservas_Click(object sender, EventArgs e)
        {
            try
            {
                string relatorio = _relatorioService.GerarRelatorioReservas();
                ExibirRelatorio("Relatório de Reservas", relatorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório de reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarAtasReunioes_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarFormularioSelecionarReuniao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar a ata de reuniões: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Métodos para Exibir Campos Dinamicamente

        private void MostrarFormularioSelecionarReuniao()
        {
            LimparPainelConteudo();

            var lblTitulo = new Label
            {
                Text = "Selecionar Reunião",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30
            };

            var lstReunioes = new ListBox
            {
                Dock = DockStyle.Fill
            };

            var reunioes = ObterReunioesFicticias();
            lstReunioes.Items.AddRange(reunioes.ToArray());

            var btnGerarAta = new Button
            {
                Text = "Gerar Ata",
                Dock = DockStyle.Bottom,
                Height = 30
            };

            btnGerarAta.Click += (s, e) =>
            {
                if (lstReunioes.SelectedItem is ProjCondominios.Models.Reuniao reuniaoSelecionada)
                {
                    try
                    {
                        string relatorio = _relatorioService.GerarAtaReuniao(reuniaoSelecionada);
                        ExibirRelatorio("Ata de Reunião", relatorio);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao gerar a ata de reunião: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma reunião válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            pnlConteudo.Controls.Add(btnGerarAta);
            pnlConteudo.Controls.Add(lstReunioes);
            pnlConteudo.Controls.Add(lblTitulo);
        }

        private string[] ObterReunioesFicticias()
        {
            return new[]
            {
                "Reunião 1: Orçamento - 01/01/2024",
                "Reunião 2: Manutenção - 15/01/2024",
                "Reunião 3: Projetos Novos - 25/01/2024"
            };
        }

        #endregion
    }
}
