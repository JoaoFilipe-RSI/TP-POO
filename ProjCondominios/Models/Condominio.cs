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

        private List<Condomino> condominos;

        private List<FracaoAutonoma> _fracoes = new List<FracaoAutonoma>();

        #endregion

        #region Propriedades Públicas

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public TipoCondominio TipoCondominio { get; set; }
        public List<Condomino> Condominos => condominos;
        public IEnumerable<FracaoAutonoma> Fracoes => _fracoes;

        #endregion

        #region Construtores

        public Condominio(string nome, string endereco, TipoCondominio tipoCondominio)
        {
            Nome = nome;
            Endereco = endereco;
            TipoCondominio = tipoCondominio;
            condominos = new List<Condomino>();
        }

        #endregion

        #region Métodos

        public void AdicionarCondomino(Condomino condomino) => condominos.Add(condomino);
        public void RemoverCondomino(Condomino condomino) => condominos.Remove(condomino);

        public void AdicionarFracao(FracaoAutonoma fracao)
        {
            _fracoes.Add(fracao);
        }
        public void RemoverFracao(FracaoAutonoma fracao)
        {
            _fracoes.Remove(fracao);
        }
        #endregion
    }
}
