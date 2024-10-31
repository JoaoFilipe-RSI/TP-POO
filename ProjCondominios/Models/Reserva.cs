using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public class Reserva
    {
        #region Propriedades Públicas
        public int Id { get; private set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        #endregion

        #region Construtores
        public Reserva(int id, string descricao, DateTime data)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
        }
        #endregion
    }
}
