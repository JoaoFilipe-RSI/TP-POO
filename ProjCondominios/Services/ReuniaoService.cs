using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Interfaces;
using ProjCondominios.Models;

namespace ProjCondominios.Services
{
    public class ReuniaoService
    {

        #region Propriedades Privadas

        private List<Reuniao> _reunioes;
        private readonly IRelatorioService _relatorioService;

        #endregion

        #region Construtores

        public ReuniaoService(IRelatorioService relatorioService)
        {
            _reunioes = new List<Reuniao>();
            _relatorioService = relatorioService;
        }

        #endregion

        #region Métodos

        // Método para agendar uma nova reunião
        public void AgendarReuniao(Reuniao reuniao)
        {
            if (reuniao == null) throw new ArgumentNullException(nameof(reuniao));
            _reunioes.Add(reuniao);
        }

        // Método para cancelar uma reunião
        public void CancelarReuniao(Reuniao reuniao)
        {
            if (reuniao == null) throw new ArgumentNullException(nameof(reuniao));
            _reunioes.Remove(reuniao);
        }

        // Método para atualizar uma reunião existente, usando apenas a instância atualizada.
        public void AtualizarReuniao(Reuniao reuniaoAtualizada)
        {
            if (reuniaoAtualizada == null)
                throw new ArgumentNullException(nameof(reuniaoAtualizada), "A reunião não pode ser nula.");

            var reuniaoExistente = _reunioes.FirstOrDefault(r => r.DataHora == reuniaoAtualizada.DataHora && r.Local == reuniaoAtualizada.Local);

            if (reuniaoExistente == null)
                throw new KeyNotFoundException("Reunião não encontrada para atualizar.");

            reuniaoExistente.DataHora = reuniaoAtualizada.DataHora;
            reuniaoExistente.Local = reuniaoAtualizada.Local;
            reuniaoExistente.Pauta = reuniaoAtualizada.Pauta;

            // Atualiza a lista de participantes
            reuniaoExistente.Participantes.Clear();
            foreach (var participante in reuniaoAtualizada.Participantes)
            {
                reuniaoExistente.AdicionarParticipante(participante);
            }
        }

        // Método para listar todas as reuniões de um condomínio
        public List<Reuniao> ListarReunioes()
        {
            return _reunioes;
        }

        // Método para gerar um relatório de uma reunião específica
        public string GerarRelatorioReuniao(Reuniao reuniao)
        {
            return _relatorioService.GerarAtaReuniao(reuniao);
        }

        // Método para obter todas as reuniões futuras
        public List<Reuniao> ListarReunioesFuturas()
        {
            return _reunioes.Where(r => r.DataHora > DateTime.Now).ToList();
        }

        // Método para listar os participantes de uma reunião específica
        public IEnumerable<Condomino> ListarParticipantesDeReuniao(Reuniao reuniao)
        {
            if (reuniao == null) throw new ArgumentNullException(nameof(reuniao), "A reunião não pode ser nula.");
            return reuniao.ListarParticipantes();
        }
        #endregion
    }
}
