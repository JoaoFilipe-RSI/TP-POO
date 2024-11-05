using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public class FracaoAutonoma
    {
        #region Propriedades Públicas

        public string Identificacao { get; set; }
        public double Area { get; set; }
        public double Permilagem { get; set; }
        public Condominio Condominio { get; set; }
        public Condomino Proprietario { get; set; }
        public Condomino? Inquilino { get; set; }

        #endregion

        #region Construtor

        public FracaoAutonoma(string identificacao, double area, double permilagem, Condominio condominio, Condomino proprietario, Condomino? inquilino = null)
        {
            Identificacao = identificacao;
            Area = area;
            Permilagem = permilagem;
            Condominio = condominio;
            Proprietario = proprietario;
            Inquilino = inquilino;
        }

        #endregion
    }
}
