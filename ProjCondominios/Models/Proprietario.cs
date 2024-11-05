using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public class Proprietario : Condomino
    {
        public Proprietario(string nome, string nif, string contato)
            : base(nome, nif, contato) { }

        public override void ExibirInfo()
        {
            Console.WriteLine($"Proprietário: {Nome}, NIF: {NIF}, Contato: {Contato}");
        }
    }
}
