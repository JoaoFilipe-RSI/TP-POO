using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Proprietario : Condomino
    {
        // Construtor vazio
        public Proprietario() : base("", "", "", 0) { }
        public Proprietario(string nome, string nif, string contato, TipoCondomino tipo)
            : base(nome, nif, contato, tipo) { }
        public override void ExibirInfo()
        {
            Console.WriteLine($"Proprietário: {Nome}, NIF: {NIF}, Contato: {Contato}");
        }
    }
}
