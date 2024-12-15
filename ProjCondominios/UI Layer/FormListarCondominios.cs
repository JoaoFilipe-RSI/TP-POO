using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjCondominios.Services;

namespace ProjCondominios.UI_Layer
{
    public partial class FormListarCondominios : Form
    {
        private readonly CondominioService _condominioService;

        public FormListarCondominios(CondominioService condominioService)
        {
            _condominioService = condominioService ?? throw new ArgumentNullException(nameof(condominioService));
            InitializeComponent();
        }

        private void FormListarCondominios_Load(object sender, EventArgs e)
        {
            // Carregar os condomínios no DataGridView
            CarregarCondominios();
        }

        private void CarregarCondominios()
        {
            var condominios = _condominioService.ObterCondominios();

            if (condominios == null || !condominios.Any())
            {
                MessageBox.Show("Nenhum condomínio registrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Atribuir os dados ao DataGridView
            dgvCondominios.DataSource = condominios.Select(c => new
            {
                Nome = c.Nome,
                Endereco = c.Endereco,
                Tipo = c.TipoCondominio,
                OrcamentoAnual = c.OrcamentoAnual,
                TotalFracoes = c.Fracoes.Count()
            }).ToList();
        }

        private void btnRegistoCondominio_Click(object sender, EventArgs e)
        {

        }
    }
}
