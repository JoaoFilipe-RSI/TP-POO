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
    public partial class GestaoReservas : Form
    {
        // Serviços e dependências
        private readonly ReservaService _reservaService;
        private readonly CondominioService _condominioService;
        private readonly CondominoService _condominoService;
        private readonly MenuPrincipal _menuPrincipal;

        // Painel para exibir campos dinamicamente
        private Panel painelCampos;

        // Botões de ação
        private Button btnAdicionarReserva, btnEditarReserva, btnRemoverReserva, btnListarReservas;
        private Button btnFiltrarPorArea, btnFiltrarPorData, btnFiltrarPorCondominio, btnFechar;

        // Controles dinâmicos do formulário
        private TextBox txtDescricao;
        private DateTimePicker dtpData, dtpHoraInicio, dtpHoraFim;
        private ComboBox cmbTipoReserva, cmbCondominio, cmbCondomino;
        private ListBox lstReservas;

        public GestaoReservas(ReservaService reservaService, CondominioService condominioService, CondominoService condominoService, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();

            _reservaService = reservaService;
            _condominioService = condominioService;
            _condominoService = condominoService;
            _menuPrincipal = menuPrincipal;

            ConfigurarTamanho();
            ConfigurarFormulario();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = _menuPrincipal.Location;
        }
        private ComboBox cmbReservas; // Definição no início da classe
        private void ConfigurarFormulario()
        {
            this.Text = "Gestão de Reservas";

            // Inicializar painel para os campos
            painelCampos = new Panel { Left = 20, Top = 100, Width = 600, Height = 400, BorderStyle = BorderStyle.FixedSingle, Visible = false};
            
            // Inicializar ComboBox para reservas
            cmbReservas = new ComboBox { Left = 20, Top = 160, Width = 550, DropDownStyle = ComboBoxStyle.DropDownList};

            // Botões principais
            btnAdicionarReserva = new Button { Left = 20, Top = 20, Width = 150, Text = "Adicionar Reserva" };
            btnEditarReserva = new Button { Left = 180, Top = 20, Width = 150, Text = "Editar Reserva" };
            btnRemoverReserva = new Button { Left = 20, Top = 60, Width = 150, Text = "Remover Reserva" };
            btnListarReservas = new Button { Left = 180, Top = 60, Width = 150, Text = "Listar Reservas" };
            btnFiltrarPorArea = new Button { Left = 340, Top = 10, Width = 150, Text = "Filtrar por Área" };
            btnFiltrarPorData = new Button { Left = 340, Top = 40, Width = 150, Text = "Filtrar por Data" };
            btnFiltrarPorCondominio = new Button { Left = 340, Top = 70, Width = 150, Text = "Filtrar por Condomínio" };
            btnFechar = new Button { Left = 20, Top = 500, Width = 420, Text = "Fechar" };

            // Adicionar eventos aos botões
            btnAdicionarReserva.Click += (s, e) => ExibirFormularioAdicionarReserva();
            btnEditarReserva.Click += (s, e) => ExibirFormularioEditarReserva();
            btnRemoverReserva.Click += (s, e) => ExibirFormularioRemoverReserva();
            btnListarReservas.Click += (s, e) => CarregarReservas();
            btnFiltrarPorArea.Click += (s, e) => ExibirFormularioFiltrarPorArea();
            btnFiltrarPorData.Click += (s, e) => ExibirFormularioFiltrarPorData();
            btnFiltrarPorCondominio.Click += (s, e) => ExibirFormularioFiltrarPorCondominio();
            btnFechar.Click += (s, e) => this.Close();

            // Adicionar controles ao formulário
            this.Controls.AddRange(new Control[] {
                painelCampos, cmbReservas, btnAdicionarReserva, btnEditarReserva, btnRemoverReserva, btnListarReservas,
                btnFiltrarPorArea, btnFiltrarPorData, btnFiltrarPorCondominio, btnFechar
            });

            // Inicializar a lista de reservas
            lstReservas = new ListBox { Left = 20, Top = 180, Width = 550, Height = 300 };
            this.Controls.Add(lstReservas);
        }

        private void LimparPainel()
        {
            painelCampos.Controls.Clear();
            painelCampos.Visible = true;
        }

        #region Métodos de Exibição de Formulários

        private void ExibirFormularioAdicionarReserva()
        {
            LimparPainel();

            AdicionarCamposComLabels();

            // Botão para registrar reserva
            var btnRegistrar = new Button { Left = 240, Top = 300, Width = 100, Text = "Registrar" };
            btnRegistrar.Click += (s, e) => RegistrarNovaReserva();

            painelCampos.Controls.Add(btnRegistrar);
        }

        private void ExibirFormularioEditarReserva()
        {
            LimparPainel();

            // Seleção de reserva para editar
            var lblSelecionar = new Label { Left = 20, Top = 20, Width = 200, Text = "Selecionar Reserva:" };
            var cmbReservas = new ComboBox { Left = 20, Top = 40, Width = 200 };
            CarregarReservasNoComboBox(cmbReservas);

            painelCampos.Controls.AddRange(new Control[] { lblSelecionar, cmbReservas });

            AdicionarCamposComLabels();

            // Botão para salvar alterações
            var btnSalvar = new Button { Left = 240, Top = 300, Width = 100, Text = "Salvar" };
            btnSalvar.Click += (s, e) => SalvarEdicaoReserva(cmbReservas);

            painelCampos.Controls.Add(btnSalvar);
        }

        private void ExibirFormularioRemoverReserva()
        {
            LimparPainel();

            // Seleção de reserva para remover
            var lblSelecionar = new Label { Left = 20, Top = 20, Width = 200, Text = "Selecionar Reserva:" };
            var cmbReservas = new ComboBox { Left = 20, Top = 40, Width = 200 };
            CarregarReservasNoComboBox(cmbReservas);

            var btnRemover = new Button { Left = 240, Top = 40, Width = 100, Text = "Remover" };
            btnRemover.Click += (s, e) => RemoverReserva(cmbReservas);

            painelCampos.Controls.AddRange(new Control[] { lblSelecionar, cmbReservas, btnRemover });
        }

        private void ExibirFormularioFiltrarPorArea()
        {
            LimparPainel();

            // Label e ComboBox para selecionar tipo de reserva
            var lblTipoReserva = new Label { Left = 20, Top = 20, Width = 200, Text = "Tipo de Reserva:" };
            var cmbTipoReserva = new ComboBox { Left = 20, Top = 40, Width = 200 };
            cmbTipoReserva.DataSource = Enum.GetValues(typeof(TipoReserva));

            // Botão para aplicar o filtro
            var btnAplicarFiltro = new Button { Left = 20, Top = 80, Width = 100, Text = "Filtrar" };
            btnAplicarFiltro.Click += (s, e) =>
            {
                var tipoSelecionado = (TipoReserva)cmbTipoReserva.SelectedItem;
                FiltrarReservasPorArea(tipoSelecionado);
            };

            painelCampos.Controls.AddRange(new Control[] { lblTipoReserva, cmbTipoReserva, btnAplicarFiltro });
        }

        private void FiltrarReservasPorArea(TipoReserva tipoReserva)
        {
            try
            {
                var reservasFiltradas = _reservaService.ListarReservasPorArea(tipoReserva);
                AtualizarListaReservas(reservasFiltradas);
                MessageBox.Show($"Foram encontradas {reservasFiltradas.Count} reservas para o tipo {tipoReserva}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar reservas por área: {ex.Message}");
            }
        }

        private void ExibirFormularioFiltrarPorData()
        {
            LimparPainel();

            // Label e DateTimePicker para selecionar a data
            var lblData = new Label { Left = 20, Top = 20, Width = 200, Text = "Data da Reserva:" };
            var dtpData = new DateTimePicker { Left = 20, Top = 40, Width = 200, Format = DateTimePickerFormat.Short };

            // Botão para aplicar o filtro
            var btnAplicarFiltro = new Button { Left = 20, Top = 80, Width = 100, Text = "Filtrar" };
            btnAplicarFiltro.Click += (s, e) =>
            {
                var dataSelecionada = dtpData.Value.Date;
                FiltrarReservasPorData(dataSelecionada);
            };

            painelCampos.Controls.AddRange(new Control[] { lblData, dtpData, btnAplicarFiltro });
        }

        private void FiltrarReservasPorData(DateTime data)
        {
            try
            {
                var reservasFiltradas = _reservaService.ListarReservasPorData(data);
                AtualizarListaReservas(reservasFiltradas);
                MessageBox.Show($"Foram encontradas {reservasFiltradas.Count} reservas para a data {data.ToShortDateString()}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar reservas por data: {ex.Message}");
            }
        }

        private void ExibirFormularioFiltrarPorCondominio()
        {
            LimparPainel();

            // Label e ComboBox para selecionar condomínio
            var lblCondominio = new Label { Left = 20, Top = 20, Width = 200, Text = "Condomínio:" };
            var cmbCondominio = new ComboBox { Left = 20, Top = 40, Width = 200 };

            // Carregar lista de condomínios no ComboBox
            cmbCondominio.DataSource = _condominioService.ObterCondominios();
            cmbCondominio.DisplayMember = "Nome";
            cmbCondominio.ValueMember = "Id";

            // Botão para aplicar o filtro
            var btnAplicarFiltro = new Button { Left = 20, Top = 80, Width = 100, Text = "Filtrar" };
            btnAplicarFiltro.Click += (s, e) =>
            {
                var condominioSelecionado = (Condominio)cmbCondominio.SelectedItem;
                FiltrarReservasPorCondominio(condominioSelecionado);
            };

            painelCampos.Controls.AddRange(new Control[] { lblCondominio, cmbCondominio, btnAplicarFiltro });
        }

        private void FiltrarReservasPorCondominio(Condominio condominio)
        {
            try
            {
                var reservasFiltradas = _reservaService.ListarReservasPorCondominio(condominio);
                AtualizarListaReservas(reservasFiltradas);
                MessageBox.Show($"Foram encontradas {reservasFiltradas.Count} reservas para o condomínio {condominio.Nome}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar reservas por condomínio: {ex.Message}");
            }
        }

        private void AdicionarCamposComLabels()
        {
            // Campos para criar ou editar uma reserva
            var lblDescricao = new Label { Left = 20, Top = 20, Width = 200, Text = "Descrição:" };
            txtDescricao = new TextBox { Left = 20, Top = 40, Width = 200 };

            var lblData = new Label { Left = 20, Top = 80, Width = 200, Text = "Data:" };
            dtpData = new DateTimePicker { Left = 20, Top = 100, Width = 200, Format = DateTimePickerFormat.Short };

            var lblHoraInicio = new Label { Left = 20, Top = 140, Width = 200, Text = "Hora Início:" };
            dtpHoraInicio = new DateTimePicker { Left = 20, Top = 160, Width = 200, Format = DateTimePickerFormat.Time, ShowUpDown = true };

            var lblHoraFim = new Label { Left = 20, Top = 200, Width = 200, Text = "Hora Fim:" };
            dtpHoraFim = new DateTimePicker { Left = 20, Top = 220, Width = 200, Format = DateTimePickerFormat.Time, ShowUpDown = true };

            var lblTipoReserva = new Label { Left = 240, Top = 20, Width = 200, Text = "Tipo de Reserva:" };
            cmbTipoReserva = new ComboBox { Left = 240, Top = 40, Width = 200 };

            var lblCondominio = new Label { Left = 240, Top = 80, Width = 200, Text = "Condomínio:" };
            cmbCondominio = new ComboBox { Left = 240, Top = 100, Width = 200 };

            var lblCondomino = new Label { Left = 240, Top = 140, Width = 200, Text = "Condómino:" };
            cmbCondomino = new ComboBox { Left = 240, Top = 160, Width = 200 };

            painelCampos.Controls.AddRange(new Control[]
            {
                lblDescricao, txtDescricao, lblData, dtpData,
                lblHoraInicio, dtpHoraInicio, lblHoraFim, dtpHoraFim,
                lblTipoReserva, cmbTipoReserva, lblCondominio, cmbCondominio,
                lblCondomino, cmbCondomino
            });

            CarregarComboBoxes();
        }

        #endregion

        #region Métodos para Operações de Reserva

        private void RegistrarNovaReserva()
        {
            try
        {
        // Validar Descrição
        if (string.IsNullOrWhiteSpace(txtDescricao.Text))
        {
            MessageBox.Show("A descrição é obrigatória.");
            return;
        }

        // Validar Tipo de Reserva
        if (cmbTipoReserva.SelectedItem == null || !(cmbTipoReserva.SelectedItem is TipoReserva tipoReservaSelecionado))
        {
            MessageBox.Show("Selecione um tipo de reserva válido.");
            return;
        }

        // Validar Condomínio
        var condominioSelecionado = cmbCondominio.SelectedItem as Condominio;
        if (condominioSelecionado == null || condominioSelecionado.Id == 0)
        {
            MessageBox.Show("Selecione um condomínio válido.");
            return;
        }

        // Validar Condómino
        var condominoSelecionado = cmbCondomino.SelectedItem as Condomino;
        if (condominoSelecionado == null)
        {
            MessageBox.Show("Selecione um condômino válido.");
            return;
        }

        // Validar Data e Hora
        if (dtpData.Value.Date < DateTime.Now.Date)
        {
            MessageBox.Show("A data da reserva não pode ser no passado.");
            return;
        }

        if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFim.Value.TimeOfDay)
        {
            MessageBox.Show("O horário de início deve ser anterior ao horário de fim.");
            return;
        }

        // Verificar conflitos de reservas
        var reservasExistentes = _reservaService.ListarReservas();
        var conflito = reservasExistentes.Any(r =>
            r.Condominio?.Id == condominioSelecionado.Id &&
            r.TipoReserva == tipoReservaSelecionado &&
            r.Data == dtpData.Value.Date &&
            ((r.HoraInicio < dtpHoraFim.Value.TimeOfDay && r.HoraFim > dtpHoraInicio.Value.TimeOfDay))
        );

        if (conflito)
        {
            MessageBox.Show("Já existe uma reserva para este horário, área e condomínio. Escolha outro horário.");
            return;
        }

        // Criar objeto reserva
        var reserva = new Reserva(
            txtDescricao.Text,
            dtpData.Value,
            dtpHoraInicio.Value.TimeOfDay,
            dtpHoraFim.Value.TimeOfDay,
            tipoReservaSelecionado,
            condominioSelecionado,
            condominoSelecionado
        );

        // Registrar reserva
        _reservaService.RegistrarReserva(reserva);
        MessageBox.Show("Reserva registrada com sucesso!");

        // Limpar campos e atualizar lista
        txtDescricao.Clear();
        dtpData.Value = DateTime.Now;
        dtpHoraInicio.Value = DateTime.Now;
        dtpHoraFim.Value = DateTime.Now;
        painelCampos.Visible = false;

        CarregarReservas();
    }
    catch (NullReferenceException)
    {
        MessageBox.Show("Erro: Dados obrigatórios não foram preenchidos corretamente.");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erro inesperado ao registrar reserva: {ex.Message}");
    }
}

        private void SalvarEdicaoReserva(ComboBox cmbReservas)
        {
            try
            {
                var reservaSelecionada = (Reserva)cmbReservas.SelectedItem;

                reservaSelecionada.Descricao = txtDescricao.Text;
                reservaSelecionada.Data = dtpData.Value;
                reservaSelecionada.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                reservaSelecionada.HoraFim = dtpHoraFim.Value.TimeOfDay;
                reservaSelecionada.TipoReserva = (TipoReserva)cmbTipoReserva.SelectedItem;
                reservaSelecionada.Condominio = (Condominio)cmbCondominio.SelectedItem;
                reservaSelecionada.Condomino = (Condomino)cmbCondomino.SelectedItem;

                _reservaService.AtualizarReserva(reservaSelecionada);
                MessageBox.Show("Reserva editada com sucesso!");
                CarregarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar reserva: {ex.Message}");
            }
        }

        private void RemoverReserva(ComboBox cmbReservas)
        {
            try
            {
                // Verifica se uma reserva foi selecionada
                if (cmbReservas.SelectedItem is Reserva reservaSelecionada)
                {
                    _reservaService.CancelarReserva(reservaSelecionada.Id);

                    MessageBox.Show("Reserva removida com sucesso!");
                    CarregarReservas();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma reserva para remover.", "Aviso");
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("A reserva selecionada não foi encontrada. Pode ter sido removida anteriormente.", "Erro");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover reserva: {ex.Message}");
            }
        }

        private void CarregarReservas()
        {
            try
            {
                // Verifica se o serviço está disponível
                if (_reservaService == null)
                {
                    MessageBox.Show("Erro: Serviço de reservas não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var reservas = _reservaService.ListarReservas();

                if (reservas == null || reservas.Count == 0)
                {
                    MessageBox.Show("Nenhuma reserva encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Atualiza o ListBox com todas as reservas
                lstReservas.Items.Clear();
                foreach (var reserva in reservas)
                {
                    var condominioNome = reserva.Condominio?.Nome ?? "Não especificado";
                    var condonomoNome = reserva.Condomino?.Nome ?? "Não especificado";

                    lstReservas.Items.Add($"ID: {reserva.Id}, Descrição: {reserva.Descricao}, " +
                                          $"Data: {reserva.Data.ToShortDateString()}, " +
                                          $"Hora: {reserva.HoraInicio} - {reserva.HoraFim}, " +
                                          $"Área: {reserva.TipoReserva}, " +
                                          $"Condomínio: {condominioNome}, " +
                                          $"Condómino: {condonomoNome}");
                }

                // Atualiza o ComboBox com as reservas para edição ou remoção
                cmbReservas.DataSource = reservas;
                cmbReservas.DisplayMember = "Descricao";
                cmbReservas.ValueMember = "Id";
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Erro ao carregar reservas: Serviço de reservas não está inicializado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarListaReservas(List<Reserva> reservas)
        {
            lstReservas.Items.Clear();

            foreach (var reserva in reservas)
            {
                lstReservas.Items.Add($"ID: {reserva.Id}, Descrição: {reserva.Descricao}, " +
                                      $"Data: {reserva.Data.ToShortDateString()}, " +
                                      $"Hora: {reserva.HoraInicio} - {reserva.HoraFim}, " +
                                      $"Área: {reserva.TipoReserva}, " +
                                      $"Condomínio: {reserva.Condominio.Nome}, " +
                                      $"Condómino: {reserva.Condomino.Nome}");
            }
        }

        private void CarregarReservasNoComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = _reservaService.ListarReservas();
            comboBox.DisplayMember = "Descricao";
            comboBox.ValueMember = "Id";
        }

        private void CarregarComboBoxes()
        {
            cmbCondominio.DataSource = _condominioService.ObterCondominios();
            cmbCondominio.DisplayMember = "Nome";
            cmbCondominio.ValueMember = "Id";

            cmbCondomino.DataSource = _condominoService.ListarTodos();
            cmbCondomino.DisplayMember = "Nome";
            cmbCondomino.ValueMember = "Id";

            cmbTipoReserva.DataSource = Enum.GetValues(typeof(TipoReserva));
        }

        #endregion
    }
}
