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
        private readonly ReservaService _reservaService;
        private Condominio _condominioSelecionado;
        private MenuPrincipal _menuPrincipal;

        public GestaoReservas(MenuPrincipal menuPrincipal, Condominio condominioSelecionado)
        {
            InitializeComponent();
            _reservaService = new ReservaService();
            _condominioSelecionado = condominioSelecionado;
            _menuPrincipal = menuPrincipal;
            lblCondominio.Text = $"Gestão de Reservas - {_condominioSelecionado.Nome}";
            CarregarTipoReservas();
            AtualizarListaReservas();
            ConfigurarTamanho();
        }

        private void ConfigurarTamanho()
        {
            this.Size = _menuPrincipal.Size; 
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = _menuPrincipal.Location; 
        }

        #region Eventos do Formulário

        private void btnRegistrarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarReserva();
                AtualizarListaReservas();
                LimparCampos();
                MessageBox.Show("Reserva registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizarReserva();
                AtualizarListaReservas();
                LimparCampos();
                MessageBox.Show("Reserva atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarReserva();
                AtualizarListaReservas();
                MessageBox.Show("Reserva cancelada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarReservaSelecionada();
        }

        #endregion

        #region Métodos Privados

        private void CarregarTipoReservas()
        {
            cmbTipoReserva.DataSource = Enum.GetValues(typeof(TipoReserva));
        }

        private void AtualizarListaReservas()
        {
            lstReservas.Items.Clear();
            var reservas = _reservaService.ListarReservasPorCondominio(_condominioSelecionado);

            foreach (var reserva in reservas)
            {
                lstReservas.Items.Add($"{reserva.Id} - {reserva.Descricao} - {reserva.Data.ToShortDateString()} - {reserva.HoraInicio}-{reserva.HoraFim}");
            }
        }

        private void RegistrarReserva()
        {
            var descricao = txtDescricao.Text;
            var data = dtpData.Value;
            var horaInicio = TimeSpan.Parse(txtHoraInicio.Text);
            var horaFim = TimeSpan.Parse(txtHoraFim.Text);
            var tipoReserva = (TipoReserva)cmbTipoReserva.SelectedItem;
            var condomino = (Condomino)cmbCondomino.SelectedItem;

            if (condomino == null)
                throw new ArgumentException("Selecione um condômino válido.");

            var novaReserva = new Reserva(descricao, data, horaInicio, horaFim, tipoReserva, _condominioSelecionado, condomino);
            _reservaService.RegistrarReserva(novaReserva);
        }

        private void AtualizarReserva()
        {
            if (lstReservas.SelectedItem == null)
                throw new ArgumentException("Selecione uma reserva para atualizar.");

            var reservaId = Guid.Parse(lstReservas.SelectedItem.ToString().Split('-')[0].Trim());
            var reserva = _reservaService.ListarReservas().FirstOrDefault(r => r.Id == reservaId);

            if (reserva == null)
                throw new KeyNotFoundException("Reserva não encontrada.");

            reserva.Descricao = txtDescricao.Text;
            reserva.Data = dtpData.Value;
            reserva.HoraInicio = TimeSpan.Parse(txtHoraInicio.Text);
            reserva.HoraFim = TimeSpan.Parse(txtHoraFim.Text);
            reserva.TipoReserva = (TipoReserva)cmbTipoReserva.SelectedItem;
            reserva.Condomino = (Condomino)cmbCondomino.SelectedItem;

            _reservaService.AtualizarReserva(reserva);
        }

        private void CancelarReserva()
        {
            if (lstReservas.SelectedItem == null)
                throw new ArgumentException("Selecione uma reserva para cancelar.");

            var reservaId = Guid.Parse(lstReservas.SelectedItem.ToString().Split('-')[0].Trim());
            _reservaService.CancelarReserva(reservaId);
        }

        private void CarregarReservaSelecionada()
        {
            if (lstReservas.SelectedItem == null) return;

            var reservaId = Guid.Parse(lstReservas.SelectedItem.ToString().Split('-')[0].Trim());
            var reserva = _reservaService.ListarReservas().FirstOrDefault(r => r.Id == reservaId);

            if (reserva != null)
            {
                txtDescricao.Text = reserva.Descricao;
                dtpData.Value = reserva.Data;
                txtHoraInicio.Text = reserva.HoraInicio.ToString(@"hh\:mm");
                txtHoraFim.Text = reserva.HoraFim.ToString(@"hh\:mm");
                cmbTipoReserva.SelectedItem = reserva.TipoReserva;
                cmbCondomino.SelectedItem = reserva.Condomino;
            }
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            dtpData.Value = DateTime.Now;
            txtHoraInicio.Clear();
            txtHoraFim.Clear();
            cmbTipoReserva.SelectedIndex = -1;
            cmbCondomino.SelectedIndex = -1;
        }

        #endregion
    }
}

