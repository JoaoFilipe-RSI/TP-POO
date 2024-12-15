using ProjCondominios.Forms;
using ProjCondominios.Services;
using ProjCondominios.UI_Layer;

namespace ProjCondominios
{
    public partial class MenuPrincipal : Form
    {
        private CondominioService _condominioService = new CondominioService();

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void adicionarNovoCondominioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário FormRegistoCondominio
            FormRegistoCondominio form = new FormRegistoCondominio(_condominioService);

            // Exibe o formulário de registro de condomínio            
            form.Show(); // Show() ou ShowDialog() 
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GestaoCondominiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var condominioService = new CondominioService(); // Instância do serviço que será passado ao formulário
            var formGestaoCondominios = new GestaoCondominios(condominioService);
            formGestaoCondominios.Show(); // Exibe o formulário
        }

        private void pagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deUmCondóminoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void emitirFaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adicionarNovoMoradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listarCondominiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListarCondominios form = new FormListarCondominios(_condominioService);
            form.Show(); // Para abrir como uma janela modal
        }

    }
}
