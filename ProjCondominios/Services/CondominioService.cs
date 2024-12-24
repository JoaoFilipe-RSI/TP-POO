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
        private readonly FileService _jsonFileService;
        #endregion

        #region Propriedades Públicas

        public List<Condominio> Condominios => _condominios;
        #endregion

        #region Construtores

        public CondominioService()
        {
            _jsonFileService = new FileService(); 
            _condominios = _jsonFileService.CarregarCondominios(); 
        }
        #endregion

        #region Métodos

        // Método para obter todos os condomínios
        public List<Condominio> ObterCondominios()
        {
            return _condominios;
        }

        // Método para obter condomínio por Id
        public Condominio? ObterPorId(int id)
        {
            return _condominios.FirstOrDefault(c => c.Id == id);
        }

        // Método para adicionar um condomínio
        public void AdicionarCondominio(Condominio condominio)
        {
            if (condominio == null)
            {
                throw new ArgumentNullException(nameof(condominio), "O condomínio não pode ser nulo.");
            }

            _condominios.Add(condominio);
            _jsonFileService.SalvarCondominios(_condominios.ToList()); // Salva as mudanças no arquivo
        }

        // Método para remover um condomínio
        public void RemoverCondominio(Condominio condominio)
        {
            if (_condominios.Contains(condominio))
            {
                _condominios.Remove(condominio);
                _jsonFileService.SalvarCondominios(_condominios.ToList()); // Salva as mudanças no arquivo
            }
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
