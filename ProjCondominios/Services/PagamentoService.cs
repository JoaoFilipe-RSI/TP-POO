using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using ProjCondominios.Services;

namespace ProjCondominios.Services
{
    public class PagamentoService
    {
        #region Propriedades Privadas
        private List<Pagamento> _pagamentos = new List<Pagamento>();
        #endregion

        #region Métodos CRUD
        public void AdicionarPagamento(Pagamento pagamento)
        {
            _pagamentos.Add(pagamento);
        }

        public void RemoverPagamento(Guid id)
        {
            var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento != null)
            {
                _pagamentos.Remove(pagamento);
            }
        }

        public Pagamento BuscarPagamentoPorId(Guid id)
        {
            return _pagamentos.FirstOrDefault(p => p.Id == id);
        }

        public List<Pagamento> ListarPagamentos()
        {
            return _pagamentos;
        }
        #endregion

        #region Métodos Personalizados

        public List<Pagamento> ListarPagamentosPorCondominio(Condominio condominio)
        {
            return _pagamentos.FindAll(p => p.Condominio == condominio);
        }


        // adicionar funcionalidades como cálculo de total recebido, listagem e pagamentos em falta.

        #endregion
    }
}
