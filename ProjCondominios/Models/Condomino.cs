using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjCondominios.Models
{
    public class Condomino
    {
        //  gerar IDs únicos
        private static int _nextId = 1;

        #region Propriedades Públicas
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Contato { get; set; }
        public TipoCondomino TipoCondomino { get; set; }
        public int? CondominioId { get; set; }
             
        public Condominio? Condominio { get; set; }
        public FracaoAutonoma? FracaoAutonoma { get; set; }
        public bool IsInquilino => TipoCondomino == TipoCondomino.Inquilino;

        #endregion

        #region Construtores

        // Construtor vazio
        public Condomino() { Id = _nextId++; }
        public Condomino(string nome, string nif, string contato, TipoCondomino tipoCondomino)
        {
            Id = _nextId++; // Atribuir ID único e incrementar o contador
            Nome = nome;
            NIF = nif;
            Contato = contato;
            TipoCondomino = tipoCondomino;
        }
        #endregion


        #region Metodos
        public void AssociarCondominio(Condominio condominio)
        {
            Condominio = condominio;
            CondominioId = condominio.Id;
        }

        public void RemoverCondominio()
        {
            Condominio = null;
            CondominioId = null;
        }

        public virtual void ExibirInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"NIF: {NIF}");
            Console.WriteLine($"Contato: {Contato}");
            Console.WriteLine($"Tipo: {TipoCondomino}");
            Console.WriteLine($"Condomínio: {(Condominio != null ? Condominio.Nome : "Nenhum")}");
        }
        #endregion
    }
}
