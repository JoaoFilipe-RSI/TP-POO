using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using ProjCondominios.Enums;
using ProjCondominios.Interfaces;

namespace ProjCondominios.Services
{
    public class RelatorioService : IRelatorioService
    {

        #region Propriedades Privadas
        private readonly PagamentoService _pagamentoService;
        private readonly DespesaService _despesaService;
        private readonly ReservaService _reservaService;
        #endregion

        #region Construtores
        public RelatorioService(PagamentoService pagamentoService, DespesaService despesaService, ReservaService reservaService)
        {
            _pagamentoService = pagamentoService;
            _despesaService = despesaService;
            _reservaService = reservaService;
        }
        #endregion

        #region Metodos
        public string GerarRelatorioPagamentos()
        {
            var pagamentos = _pagamentoService.ListarPagamentos();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Relatório de Pagamentos:");
            sb.AppendLine("ID | Valor | Condómino | Condomínio | Data");

            foreach (var pagamento in pagamentos)
            {
                sb.AppendLine($"{pagamento.Id} | {pagamento.ValorQuota} | {pagamento.Condomino.Nome} | {pagamento.Condominio.Nome} | {pagamento.DataHoraPagamento}");
            }

            return sb.ToString();
        }

        public string GerarRelatorioDespesas()
        {
            var despesas = _despesaService.ListarDespesas();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Relatório de Despesas:");
            sb.AppendLine("ID | Valor | Tipo | Condomínio | Data");

            foreach (var despesa in despesas)
            {
                sb.AppendLine($"{despesa.Id} | {despesa.Valor} | {despesa.Tipo} | {despesa.Condominio.Nome} | {despesa.DataHoraDespesa}");
            }

            return sb.ToString();
        }

        public string GerarRelatorioReservas()
        {
            var reservas = _reservaService.ListarReservas();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Relatório de Reservas:");
            sb.AppendLine("ID | Condómino | Condomínio | Área Reservada | Data");

            foreach (var reserva in reservas)
            {
                sb.AppendLine($"{reserva.Id} | {reserva.Condomino.Nome} | {reserva.Condominio.Nome} | {reserva.TipoReserva} | {reserva.Data}");
            }

            return sb.ToString();
        }

        public string GerarRelatorioFinanceiro()
        {
            // Obter todas as despesas e pagamentos e calcular o saldo final
            var despesas = _despesaService.ListarDespesas();
            var pagamentos = _pagamentoService.ListarPagamentos();

            decimal totalDespesas = 0;
            decimal totalPagamentos = 0;

            foreach (var despesa in despesas)
            {
                totalDespesas += despesa.Valor;
            }

            foreach (var pagamento in pagamentos)
            {
                totalPagamentos += pagamento.ValorQuota;
            }

            decimal saldo = totalPagamentos - totalDespesas;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Relatório Financeiro:");
            sb.AppendLine($"Total de Pagamentos: {totalPagamentos:C}");
            sb.AppendLine($"Total de Despesas: {totalDespesas:C}");
            sb.AppendLine($"Saldo Final: {saldo:C}");

            return sb.ToString();
        }

        public string GerarAtaReuniao(Reuniao reuniao)
        {
            var relatorio = $"Ata da Reunião\n";
            relatorio += "=============================\n";
            relatorio += $"Data e Hora: {reuniao.DataHora}\n";
            relatorio += $"Local: {reuniao.Local}\n";
            relatorio += $"Pauta: {reuniao.Pauta}\n";
            relatorio += "Participantes:\n";
            foreach (var participante in reuniao.Participantes)
            {
                relatorio += $"- {participante.Nome}\n";
            }
            return relatorio;
        }

        // Exportação de relatórios em formatos como PDF ou Excel.
        #endregion
    }
}
