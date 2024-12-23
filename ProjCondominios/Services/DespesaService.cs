using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using ProjCondominios.Enums;
using ProjCondominios.Services;

namespace ProjCondominios.Services
{
    public class DespesaService
    {
        #region Propriedades Privadas

        private List<Despesa> _despesas = new List<Despesa>();

        #endregion

        #region Métodos CRUD
        public void AdicionarDespesa(Despesa despesa)
        {
            _despesas.Add(despesa);
        }

        public void RemoverDespesa(Guid id)
        {
            var despesa = _despesas.FirstOrDefault(d => d.Id == id);
            if (despesa != null)
            {
                _despesas.Remove(despesa);
            }
        }

        public Despesa BuscarDespesaPorId(Guid id)
        {
            return _despesas.FirstOrDefault(d => d.Id == id);
        }

        public List<Despesa> ListarDespesas()
        {
            return _despesas;
        }
        #endregion

        #region Métodos Personalizados

        public List<Despesa> ListarDespesasPorCondominio(Condominio condominio)
        {
            return _despesas.FindAll(d => d.Condominio == condominio);
        }

        #endregion
    }
}
