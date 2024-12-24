using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Inquilino : Condomino
    {
        #region Construtor
        // Construtor vazio
        public Inquilino() : base("", "", "", 0) { }
        public Inquilino(string nome, string nif, string contato, TipoCondomino tipo)
            : base(nome, nif, contato, tipo) { }

        #endregion

        #region Metodos
        public override void ExibirInfo()
        {
            Console.WriteLine($"Inquilino: {Nome}, NIF: {NIF}, Contato: {Contato}");
        }
        #endregion
    }
}
