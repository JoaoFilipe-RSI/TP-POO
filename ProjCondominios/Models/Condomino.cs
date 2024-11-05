using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public abstract class Condomino
    {
        #region Propriedades Públicas
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Contato { get; set; }
        #endregion

        #region Construtores
        protected Condomino(string nome, string nif, string contato)
        {
            Nome = nome;
            NIF = nif;
            Contato = contato;
        }
        #endregion


        #region Metodos
        public abstract void ExibirInfo();
        #endregion
    }
}
