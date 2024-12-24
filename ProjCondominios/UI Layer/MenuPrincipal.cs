using ProjCondominios.UI_Layer;
using ProjCondominios.Services;
using ProjCondominios.Models;
using ProjCondominios.Interfaces;
using System.Collections.Generic;
using CalculadoraFinanceira;

namespace ProjCondominios
{
    public partial class MenuPrincipal : Form
    {
        private readonly FileService _fileService;
        private readonly List<Condominio> _condominios;
        private readonly CondominioService _condominioService;
        private readonly CondominoService _condominoService;
        private readonly FracaoAutonomaService _fracaoService;
        private readonly ReservaService _reservaService;
        private readonly ReuniaoService _reuniaoService;
        private readonly RelatorioService _relatorioService;
        private readonly IRelatorioService _irelatorioService;
        private readonly DespesaService _despesaService;
        private readonly PagamentoService _pagamentoService;
        private readonly FinanceiroService _financeiroService;
        private readonly CalculosFinanceirosService _calculosFinanceirosService;

        // Construtor único que inicializa todos os serviços necessários
        public MenuPrincipal()
        {
            InitializeComponent();

            _fileService = new FileService();
            _condominioService = new CondominioService();
            _condominoService = new CondominoService();
            _reuniaoService = new ReuniaoService(_relatorioService);
            _fracaoService = new FracaoAutonomaService(_condominioService, _condominoService, _fileService, new List<FracaoAutonoma>());
            _reservaService = new ReservaService();
            _despesaService = new DespesaService();
            _pagamentoService = new PagamentoService();
            _calculosFinanceirosService = new CalculosFinanceirosService();
            _financeiroService = new FinanceiroService(_pagamentoService, _despesaService, _calculosFinanceirosService);
            _relatorioService = new RelatorioService(_pagamentoService, _despesaService, _reservaService);
            _condominios = _condominioService.ObterCondominios();
        }

        // Carregar os dados ao abrir o formulário
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            var condominios = _condominioService.Condominios;
            var condominos = _condominoService.Condominos;
            var fracoes = _fracaoService.ListarTodasFracoes();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GestaoCondominiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoCondominios = new GestaoCondominios(_condominioService, this);
            formGestaoCondominios.Show();
        }

        private void GestaoCondominosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoCondominos = new GestaoCondominos(_condominoService, this);
            formGestaoCondominos.Show();
        }

        private void GestaoFracoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoFracoes = new GestaoFracoes(_fracaoService, _condominioService, _condominoService, this);
            formGestaoFracoes.Show();
        }

        private void GestaoReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoReservas = new GestaoReservas(_reservaService, _condominioService, _condominoService, this);
            formGestaoReservas.Show();
        }

        private void GestaoReunioesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoReunioes = new GestaoReunioes(_reuniaoService, _relatorioService, this);
            formGestaoReunioes.Show();
        }

        private void GestaoDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoDespesas = new GestaoDespesas(_despesaService, _condominios, this);
            formGestaoDespesas.Show();
        }

        private void GestaoPagamentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formGestaoPagamentos = new GestaoPagamentos(_pagamentoService, _condominios, this);
            formGestaoPagamentos.Show();
        }

        private void GestaoFinanceiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoFinanceira = new GestaoFinanceira(_financeiroService, _condominios, this);
            formGestaoFinanceira.Show();
        }

        private void GestaoRelatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestaoRelatorios = new GestaoRelatorios(_relatorioService, this);
            formGestaoRelatorios.Show();
        }
    }
}