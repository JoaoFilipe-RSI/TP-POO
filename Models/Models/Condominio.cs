using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Condominio
    {
        #region Propriedades Privadas
        private List<Morador> moradores;
        private List<Reserva> reservas;
        #endregion

        #region Propriedades Públicas
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public TipoCondominio Tipo { get; set; }
        #endregion

        #region Construtores
        public Condominio(int id, string nome, string endereco, TipoCondominio tipo)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Tipo = tipo;
            moradores = new List<Morador>();
            reservas = new List<Reserva>();
        }
        #endregion

        #region Métodos
        #endregion
    }
}
