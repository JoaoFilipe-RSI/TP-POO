using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;
using ProjCondominios.Models;


namespace ProjCondominios.Services
{
    public class ReservaService
    {
        #region Propriedades Privadas
        private List<Reserva> _reservas;
        #endregion

        #region Construtor
        public ReservaService()
        {
            _reservas = new List<Reserva>();
        }
        #endregion

        #region Métodos

        public void RegistrarReserva(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "A reserva não pode ser nula.");

            if (string.IsNullOrWhiteSpace(reserva.Descricao))
                throw new ArgumentException("A descrição da reserva é obrigatória.");

            if (reserva.HoraInicio >= reserva.HoraFim)
                throw new ArgumentException("A hora de início deve ser antes da hora de término.");

            if (reserva.Condominio == null)
                throw new ArgumentException("O campo 'Condomínio' é obrigatório. Certifique-se de selecionar um condomínio válido.");

            if (reserva.Condomino == null)
                throw new ArgumentException("O campo 'Condómino' é obrigatório.");

            if (_reservas.Any(r => r.Data == reserva.Data &&
                                   r.TipoReserva == reserva.TipoReserva &&
                                   r.Condominio.Id == reserva.Condominio.Id &&
                                   ((reserva.HoraInicio >= r.HoraInicio && reserva.HoraInicio < r.HoraFim) ||
                                    (reserva.HoraFim > r.HoraInicio && reserva.HoraFim <= r.HoraFim))))
            {
                throw new InvalidOperationException("Já existe uma reserva para esta área neste horário.");
            }

            _reservas.Add(reserva);
        }

        public void CancelarReserva(Guid id)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
                throw new KeyNotFoundException("Reserva não encontrada.");
            _reservas.Remove(reserva);
        }

        public void AtualizarReserva(Reserva reservaAtualizada)
        {
            if (reservaAtualizada == null)
                throw new ArgumentNullException(nameof(reservaAtualizada), "A reserva atualizada não pode ser nula.");

            if (string.IsNullOrWhiteSpace(reservaAtualizada.Descricao))
                throw new ArgumentException("A descrição da reserva é obrigatória.");

            if (reservaAtualizada.HoraInicio >= reservaAtualizada.HoraFim)
                throw new ArgumentException("A hora de início deve ser antes da hora de término.");

            var reservaExistente = _reservas.FirstOrDefault(r => r.Id == reservaAtualizada.Id);
            if (reservaExistente == null)
                throw new KeyNotFoundException("Reserva não encontrada.");

            reservaExistente.Descricao = reservaAtualizada.Descricao;
            reservaExistente.Data = reservaAtualizada.Data;
            reservaExistente.HoraInicio = reservaAtualizada.HoraInicio;
            reservaExistente.HoraFim = reservaAtualizada.HoraFim;
            reservaExistente.TipoReserva = reservaAtualizada.TipoReserva;
            reservaExistente.Condominio = reservaAtualizada.Condominio;
            reservaExistente.Condomino = reservaAtualizada.Condomino;
        }

        public List<Reserva> ListarReservas() => _reservas;

        public List<Reserva> ListarReservasPorArea(TipoReserva tipo)
        {
            return _reservas?.Where(r => r.TipoReserva == tipo).ToList() ?? new List<Reserva>();
        }

        public List<Reserva> ListarReservasPorData(DateTime data)
        {
            return _reservas?.Where(r => r.Data.Date == data.Date).ToList() ?? new List<Reserva>();
        }

        public List<Reserva> ListarReservasPorCondominio(Condominio condominio)
        {
            if (condominio == null)
                throw new ArgumentNullException(nameof(condominio), "O condomínio não pode ser nulo.");

            return _reservas?.Where(r => r.Condominio.Id == condominio.Id).ToList() ?? new List<Reserva>();
        }

        #endregion
    }
}
