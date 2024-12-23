using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Reserva
    {
        #region Propriedades Privadas

        private TipoReserva tipoReserva;
        private string descricao;
        private DateTime data;
        private TimeSpan horaInicio;
        private TimeSpan horaFim;
        private Condominio condominio;
        private Condomino condomino;
        #endregion

        #region Propriedades Públicas
        public Guid Id { get; private set; }
        public string Descricao { get; set; }
        public DateTime Data
        {
            get => data;
            set
            {
                if (value < DateTime.Now.Date)
                    throw new ArgumentException("A data da reserva não pode ser no passado.");
                data = value;
            }
        }

        public TimeSpan HoraInicio
        {
            get => horaInicio;
            set
            {
                horaInicio = value;

                // Valida apenas se HoraFim já estiver definida
                if (horaFim != default && horaInicio >= horaFim)
                {
                    throw new ArgumentException("A hora de início deve ser antes da hora de término.");
                }
            }
        }

        public TimeSpan HoraFim
        {
            get => horaFim;
            set
            {
                horaFim = value;

                // Valida apenas se HoraInicio já estiver definida
                if (horaInicio != default && horaFim <= horaInicio)
                {
                    throw new ArgumentException("A hora de término deve ser após a hora de início.");
                }
            }
        }

        public TipoReserva TipoReserva
        {
            get => tipoReserva;
            set => tipoReserva = value;
        }

        public Condomino Condomino
        {
            get => condomino;
            set => condomino = value ?? throw new ArgumentNullException(nameof(Condomino), "Condómino não pode ser nulo.");
        }

        public Condominio Condominio
        {
            get => condominio;
            set => condominio = value ?? throw new ArgumentNullException(nameof(Condominio), "Condomínio não pode ser nulo.");
        }
        #endregion

        #region Construtores
        public Reserva(string descricao, DateTime data, TimeSpan horaInicio, TimeSpan horaFim, TipoReserva tipoReserva, Condominio condominio, Condomino condomino)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            TipoReserva = tipoReserva;
        }
        #endregion
    }
}
