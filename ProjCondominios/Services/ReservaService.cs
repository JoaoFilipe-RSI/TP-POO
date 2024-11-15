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
        private List<Reserva> _reservas = new List<Reserva>();
        #endregion

        #region Métodos

        public void RegistrarReserva(Reserva reserva)
        {
            if (_reservas.Any(r => r.Data == reserva.Data &&
                                   r.TipoReserva == reserva.TipoReserva &&
                                   r.Condominio == reserva.Condominio &&
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

        public List<Reserva> ListarReservas()
        {
            return _reservas;
        }

        public List<Reserva> ListarReservasPorArea(TipoReserva tipo)
        {
            return _reservas.Where(r => r.TipoReserva == tipo).ToList();
        }

        public List<Reserva> ListarReservasPorData(DateTime data)
        {
            return _reservas.Where(r => r.Data.Date == data.Date).ToList();
        }

        public List<Reserva> ListarReservasPorCondominio(Condominio condominio)
        {
            return _reservas.Where(r => r.Condominio == condominio).ToList();
        }
        #endregion
    }
}
