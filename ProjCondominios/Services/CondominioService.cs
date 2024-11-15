using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;
using ProjCondominios.Models;
using CalculadoraFinanceira;


namespace ProjCondominios.Services
{
    public class CondominioService
    {
        #region Propriedades Privadas

        private List<Condominio> _condominios;
        #endregion

        #region Propriedades Públicas

        public IEnumerable<Condominio> Condominios => _condominios;
        #endregion

        #region Construtores

        public CondominioService()
        {
            _condominios = new List<Condominio>();
        }
        #endregion

        #region Métodos

        // Método para obter todos os condomínios
        public IEnumerable<Condominio> ObterCondominios()
        {
            return _condominios;
        }

        // Método para adicionar um condomínio
        public void AdicionarCondominio(Condominio condominio)
        {
            _condominios.Add(condominio);
        }

        // Método para remover um condomínio
        public void RemoverCondominio(Condominio condominio)
        {
            _condominios.Remove(condominio);
        }

        // Método para calcular a área total de um condomínio
        public decimal CalcularAreaTotalCondominio(Condominio condominio)
        {
            var areasFracoes = condominio.Fracoes.Select(fracao => fracao.Area);
            return CalculosFinanceirosService.CalcularAreaTotalCondominio(areasFracoes);
        }
        #endregion
    }
}
