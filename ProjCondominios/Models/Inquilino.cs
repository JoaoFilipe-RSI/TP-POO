using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public class Inquilino : Condomino
    {
        public Inquilino(string nome, string nif, string contato)
            : base(nome, nif, contato) { }

        public override void ExibirInfo()
        {
            Console.WriteLine($"Inquilino: {Nome}, NIF: {NIF}, Contato: {Contato}");
        }
    }
}
