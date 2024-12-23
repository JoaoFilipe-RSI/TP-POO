using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;

namespace ProjCondominios.Models
{
    public class Despesa
    {
        #region Propriedades Privadas

        private TipoDespesa tipo;
        private decimal valor;
        private Condominio condominio;
        private DateTime dataHoraDespesa;
        #endregion

        #region Propriedades Públicas

        public TipoDespesa Tipo
        {
            get => tipo;
            set => tipo = value;
        }
        public Guid Id { get; private set; }
        public decimal Valor
        {
            get => valor;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O valor da despesa não pode ser negativo.");
                valor = value;
            }
        }

        public Condominio Condominio
        {
            get => condominio;
            set => condominio = value;
        }

        public DateTime DataHoraDespesa
        {
            get => dataHoraDespesa;
            set => dataHoraDespesa = value;
        }
        #endregion

        #region Construtores

        public Despesa(TipoDespesa tipo, decimal valor, Condominio condominio, DateTime dataHoraDespesa)
        {
            Id = Guid.NewGuid();
            Tipo = tipo;
            Valor = valor;
            Condominio = condominio ?? throw new ArgumentNullException(nameof(condominio));
        }
        #endregion

        #region Métodos

        public override string ToString()
        {
            return $"{Tipo}: {Valor:C} - Condomínio: {Condominio.Nome}";
        }

        #endregion
    }
}
