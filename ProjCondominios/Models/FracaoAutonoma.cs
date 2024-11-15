using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class FracaoAutonoma
    {
        #region Propriedades Públicas

        public string Identificacao { get; set; }
        public decimal Area { get; set; }
        public decimal Permilagem { get; set; }
        public decimal Quota { get; set; }
        public TipoFracao TipoFracao { get; set; }
        public Condominio Condominio { get; set; }
        public Condomino Proprietario { get; set; }
        public Condomino? Inquilino { get; set; }

        #endregion

        #region Construtor

        public FracaoAutonoma(string identificacao, decimal area, decimal permilagem, decimal quota, TipoFracao tipoFracao, Condominio condominio, Condomino proprietario, Condomino? inquilino = null)
        {
            Identificacao = identificacao;
            Area = area;
            Permilagem = permilagem;
            Quota = quota;
            TipoFracao = tipoFracao;
            Condominio = condominio;
            Proprietario = proprietario;
            Inquilino = inquilino;
        }
        #endregion
    }
}
