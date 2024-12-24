using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;
using ProjCondominios.Models;
using ProjCondominios.Services;


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
        public int CondominioId { get; set; }
        public int ProprietarioId { get; set; }
        public int? InquilinoId { get; set; }


        public Condominio? Condominio { get; set; }
        public Condomino? Proprietario { get; set; }
        public Condomino? Inquilino { get; set; }

        #endregion

        #region Construtor

        public FracaoAutonoma(
             string identificacao, decimal area, decimal permilagem, decimal quota,
             TipoFracao tipoFracao, int condominioId, int proprietarioId, int? inquilinoId = null)
        {
            Identificacao = identificacao;
            Area = area;
            Permilagem = permilagem;
            Quota = quota;
            TipoFracao = tipoFracao;
            CondominioId = condominioId;
            ProprietarioId = proprietarioId;
            InquilinoId = inquilinoId;
        }
        #endregion
        #region Metodos
        // Método para associar objetos relacionados
        public void AssociarObjetos(Condominio condominio, Condomino proprietario, Condomino? inquilino = null)
        {
            Condominio = condominio;
            Proprietario = proprietario;
            Inquilino = inquilino;
        }
        #endregion
    }
}
