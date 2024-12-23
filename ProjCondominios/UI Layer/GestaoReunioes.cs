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
    public partial class GestaoReunioes : Form
    {
        private readonly ReuniaoService _reuniaoService;
        private readonly RelatorioService _relatorioService;
        private MenuPrincipal _menuPrincipal;
        private Reuniao _reuniaoSelecionada;

        public GestaoReunioes(ReuniaoService reuniaoService, RelatorioService relatorioService, MenuPrincipal menuPrincipal)
        {
            _reuniaoService = reuniaoService;
            _relatorioService = relatorioService;
            _menuPrincipal = menuPrincipal;
            InitializeComponent();
            ConfigurarTamanho();
        }
        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size; // Ajusta o tamanho do formulário
            this.StartPosition = FormStartPosition.Manual; // Define a posição manualmente
            this.Location = _menuPrincipal.Location; // Ajusta a localização para coincidir com o MenuPrincipal
        }
        private void GestaoReunioes_Load(object sender, EventArgs e)
        {
            AtualizarProximasReunioes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MostrarFormularioAdicionar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (_reuniaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma reunião para cancelar.");
                return;
            }

            _reuniaoService.CancelarReuniao(_reuniaoSelecionada);
            MessageBox.Show("Reunião cancelada com sucesso!");
            AtualizarProximasReunioes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_reuniaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma reunião para editar.");
                return;
            }

            MostrarFormularioEditar(_reuniaoSelecionada);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarReunioes();
        }

        private void btnProximasReunioes_Click(object sender, EventArgs e)
        {
            AtualizarProximasReunioes();
        }

        private void AtualizarProximasReunioes()
        {
            pnlConteudo.Controls.Clear();

            var lblTitulo = new Label
            {
                Text = "Próximas Reuniões",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlConteudo.Controls.Add(lblTitulo);

            var lstReunioes = new ListBox
            {
                Location = new Point(10, 50),
                Size = new Size(550, 300)
            };
            lstReunioes.SelectedIndexChanged += (s, e) =>
            {
                _reuniaoSelecionada = lstReunioes.SelectedItem as Reuniao;
            };
            pnlConteudo.Controls.Add(lstReunioes);

            var proximasReunioes = _reuniaoService.ListarReunioesFuturas();
            foreach (var reuniao in proximasReunioes)
            {
                lstReunioes.Items.Add(reuniao);
            }
        }

        private void MostrarFormularioAdicionar()
        {
            pnlConteudo.Controls.Clear();

            var lblTitulo = new Label
            {
                Text = "Agendar Nova Reunião",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlConteudo.Controls.Add(lblTitulo);

            var lblDataHora = new Label { Text = "Data e Hora:", Location = new Point(10, 50) };
            pnlConteudo.Controls.Add(lblDataHora);

            var dtpDataHora = new DateTimePicker { Location = new Point(120, 50) };
            pnlConteudo.Controls.Add(dtpDataHora);

            var lblLocal = new Label { Text = "Local:", Location = new Point(10, 90) };
            pnlConteudo.Controls.Add(lblLocal);

            var txtLocal = new TextBox { Location = new Point(120, 90), Width = 200 };
            pnlConteudo.Controls.Add(txtLocal);

            var lblPauta = new Label { Text = "Pauta:", Location = new Point(10, 130) };
            pnlConteudo.Controls.Add(lblPauta);

            var txtPauta = new TextBox { Location = new Point(120, 130), Width = 200 };
            pnlConteudo.Controls.Add(txtPauta);

            var lblParticipantes = new Label { Text = "Participantes:", Location = new Point(10, 170) };
            pnlConteudo.Controls.Add(lblParticipantes);

            var clbParticipantes = new CheckedListBox
            {
                Location = new Point(120, 170),
                Width = 200,
                Height = 100
            };
            // Adiciona participantes fictícios ou baseados nos dados do sistema
            foreach (var participante in _reuniaoService.ListarReunioes())
            {
                clbParticipantes.Items.Add(participante);
            }
            pnlConteudo.Controls.Add(clbParticipantes);

            var btnSalvar = new Button
            {
                Text = "Salvar",
                Location = new Point(120, 300),
                Width = 80
            };
            btnSalvar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtLocal.Text) || string.IsNullOrWhiteSpace(txtPauta.Text))
                {
                    MessageBox.Show("Local e Pauta são obrigatórios.");
                    return;
                }

                var novaReuniao = new Reuniao(dtpDataHora.Value, txtLocal.Text, txtPauta.Text);

                foreach (var participante in clbParticipantes.CheckedItems)
                {
                    novaReuniao.AdicionarParticipante((Condomino)participante);
                }

                _reuniaoService.AgendarReuniao(novaReuniao);
                MessageBox.Show("Reunião agendada com sucesso!");
                AtualizarProximasReunioes();
            };
            pnlConteudo.Controls.Add(btnSalvar);
        }

        private void MostrarFormularioEditar(Reuniao reuniao)
        {
            MostrarFormularioAdicionar();

            // Preenche os campos com os dados da reunião existente
            var dtpDataHora = (DateTimePicker)pnlConteudo.Controls.OfType<DateTimePicker>().FirstOrDefault();
            var txtLocal = (TextBox)pnlConteudo.Controls.OfType<TextBox>().FirstOrDefault(c => c.Location.Y == 90);
            var txtPauta = (TextBox)pnlConteudo.Controls.OfType<TextBox>().FirstOrDefault(c => c.Location.Y == 130);
            var clbParticipantes = (CheckedListBox)pnlConteudo.Controls.OfType<CheckedListBox>().FirstOrDefault();

            dtpDataHora.Value = reuniao.DataHora;
            txtLocal.Text = reuniao.Local;
            txtPauta.Text = reuniao.Pauta;

            foreach (var participante in reuniao.Participantes)
            {
                var index = clbParticipantes.Items.IndexOf(participante);
                if (index >= 0) clbParticipantes.SetItemChecked(index, true);
            }

            var btnSalvar = (Button)pnlConteudo.Controls.OfType<Button>().FirstOrDefault();
            btnSalvar.Click += (s, e) =>
            {
                // Atualiza a reunião com os novos valores
                reuniao.DataHora = dtpDataHora.Value;
                reuniao.Local = txtLocal.Text;
                reuniao.Pauta = txtPauta.Text;

                reuniao.Participantes.Clear();
                foreach (var participante in clbParticipantes.CheckedItems)
                {
                    reuniao.AdicionarParticipante((Condomino)participante);
                }

                // Chama o serviço para atualizar
                _reuniaoService.AtualizarReuniao(reuniao);

                MessageBox.Show("Reunião atualizada com sucesso!");
                AtualizarProximasReunioes();
            };
        }

        private void ListarReunioes()
        {
            pnlConteudo.Controls.Clear();

            var lblTitulo = new Label
            {
                Text = "Lista de Todas as Reuniões",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlConteudo.Controls.Add(lblTitulo);

            var lstReunioes = new ListBox
            {
                Location = new Point(10, 50),
                Size = new Size(550, 300)
            };
            pnlConteudo.Controls.Add(lstReunioes);

            var todasReunioes = _reuniaoService.ListarReunioes();
            foreach (var reuniao in todasReunioes)
            {
                lstReunioes.Items.Add(reuniao);
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}