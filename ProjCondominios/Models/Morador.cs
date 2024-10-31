using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Morador
    {
        #region Propriedades Privadas
        private List<Pagamento> pagamentos;
        #endregion

        #region Propriedades Públicas
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Apartamento { get; set; }
        public string Contato { get; set; }
        public TipoMorador Tipo { get; set; }
        #endregion

        #region Construtores
        public Morador(int id, string nome, string apartamento, string contato, TipoMorador tipo)
        {
            Id = id;
            Nome = nome;
            Apartamento = apartamento;
            Contato = contato;
            Tipo = tipo;
            pagamentos = new List<Pagamento>();
        }
        #endregion

        #region Métodos

        #endregion
    }
}
