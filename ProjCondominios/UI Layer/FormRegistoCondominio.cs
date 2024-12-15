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

namespace ProjCondominios.Forms
{
    public partial class FormRegistoCondominio : Form
    {
        private readonly CondominioService _condominioService;

        public FormRegistoCondominio(CondominioService condominioService)
        {
            InitializeComponent();

            // Certifique-se de inicializar o serviço
            _condominioService = condominioService ?? throw new ArgumentNullException(nameof(condominioService));
            this.FormClosing += FormRegistoCondominio_FormClosing; // Adiciona o evento de fechamento
        }

        private void FormRegistoCondominio_Load(object sender, EventArgs e)
        {
            // Preenche o ComboBox com os valores do enum TipoCondominio
            cbTipoCondominio.DataSource = Enum.GetValues(typeof(TipoCondominio)).Cast<TipoCondominio>().ToList();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura e valida os dados do formulário
                string nome = txtNome.Text.Trim();
                string endereco = txtEndereco.Text.Trim();
                if (cbTipoCondominio.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um tipo de condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TipoCondominio tipoCondominio = (TipoCondominio)cbTipoCondominio.SelectedItem;
                if (!decimal.TryParse(txtOrcamentoAnual.Text, out decimal orcamentoAnual))
                {
                    MessageBox.Show("Insira um valor numérico válido para o orçamento anual.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(endereco))
                {
                    MessageBox.Show("Os campos Nome e Endereço são obrigatórios.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cria uma nova instância de Condominio
                Condominio novoCondominio = new Condominio(nome, endereco, tipoCondominio, orcamentoAnual);

                // Adiciona o condomínio ao serviço
                _condominioService.AdicionarCondominio(novoCondominio);

                MessageBox.Show("Condomínio registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha o formulário após o registro
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registar condomínio: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistoCondominio_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
                "Tem certeza de que deseja sair? Todas as alterações não salvas serão perdidas.",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true; // Impede o fecho do formulário
            }
        }
    }
}
