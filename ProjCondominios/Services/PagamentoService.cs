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
            if (pagamento == null)
                throw new ArgumentNullException(nameof(pagamento));
            if (pagamento.Condominio == null)
                throw new ArgumentException("O condomínio do pagamento não pode ser nulo.");
            if (pagamento.Condomino == null)
                throw new ArgumentException("O condômino do pagamento não pode ser nulo.");

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
