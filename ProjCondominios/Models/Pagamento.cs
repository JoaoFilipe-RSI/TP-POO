using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Pagamento
    {
        #region Propriedades Privadas

        private decimal valorQuota;
        private string descricao;
        private Condominio condominio;
        private Condomino condomino;
        private DateTime dataHoraPagamento;
        #endregion

        #region Propriedades Públicas
        public Guid Id { get; private set; }

        public decimal ValorQuota
        {
            get => valorQuota;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O valor da quota deve ser maior que zero.");
                valorQuota = value;
            }
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public Condominio Condominio
        {
            get => condominio;
            set => condominio = value;
        }

        public Condomino Condomino
        {
            get => condomino;
            set => condomino = value;
        }

        public DateTime DataHoraPagamento
        {
            get => dataHoraPagamento;
            set => dataHoraPagamento = value;
        }

        #endregion

        #region Construtores

        public Pagamento(decimal valorQuota, string descricao, Condominio condominio, Condomino condomino, DateTime dataHoraPagamento)
        {
            Id = Guid.NewGuid();
            ValorQuota = valorQuota;
            Descricao = descricao;
            Condominio = condominio;
            Condomino = condomino;
            DataHoraPagamento = dataHoraPagamento;
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return $"ID: {Id}, Valor: {ValorQuota:C}, Mês: {Descricao}, " +
                   $"Condomínio: {(Condominio != null ? Condominio.Nome : "Não definido")}, " +
                   $"Condómino: {(Condomino != null ? Condomino.Nome : "Não definido")}, " +
                   $"Data: {DataHoraPagamento:dd/MM/yyyy HH:mm}";
        }

        #endregion
    }
}
