using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using CalculadoraFinanceira;

namespace ProjCondominios.Services
{
    public class FracaoAutonomaService
    {
        #region Propriedades Privadas
        private readonly List<FracaoAutonoma> _fracoes;
        //private readonly CalculosFinanceirosService _calculadoraFinanceira;
        #endregion


        #region Construtor

        public FracaoAutonomaService(List<FracaoAutonoma> fracoes)
        {
            _fracoes = fracoes;
        }

        #endregion


        #region Métodos

        // Método para adicionar uma fração autónoma
        public void AdicionarFracao(string identificacao, decimal area, decimal permilagem, decimal quota, Condominio condominio, Condomino proprietario, Condomino? inquilino = null)
        {
            if (string.IsNullOrEmpty(identificacao) || permilagem <= 0 || condominio == null || proprietario == null)
                throw new ArgumentException("Dados inválidos. Identificação, permilagem, condomínio e proprietário são obrigatórios.");

            FracaoAutonoma novaFracao = new FracaoAutonoma(identificacao, area, permilagem, quota, condominio, proprietario, inquilino);
            _fracoes.Add(novaFracao);
        }

        // Método para listar todas as frações autónomas
        public List<FracaoAutonoma> ListarTodasFracoes()
        {
            return _fracoes;
        }

        // Método para listar frações por condomínio
        public List<FracaoAutonoma> ListarFracoesPorCondominio(Condominio condominio)
        {
            return _fracoes.Where(f => f.Condominio == condominio).ToList();
        }

        // Método para listar frações por condómino (proprietário ou inquilino)
        public List<FracaoAutonoma> ListarFracoesPorCondomino(Condomino condomino)
        {
            return _fracoes.Where(f => f.Proprietario == condomino || f.Inquilino == condomino).ToList();
        }

        // Método para atualizar uma fração existente
        public bool AtualizarFracao(string identificacao, decimal? novaPermilagem = null, Condominio? novoCondominio = null, Condomino? novoProprietario = null, Condomino? novoInquilino = null)
        {
            var fracao = _fracoes.FirstOrDefault(f => f.Identificacao == identificacao);
            if (fracao == null)
                return false;

            if (novaPermilagem.HasValue)
                fracao.Permilagem = novaPermilagem.Value;
            if (novoCondominio != null)
                fracao.Condominio = novoCondominio;
            if (novoProprietario != null)
                fracao.Proprietario = novoProprietario;
            if (novoInquilino != null)
                fracao.Inquilino = novoInquilino;

            return true;
        }

        // Método para remover uma fração pelo identificador
        public bool RemoverFracao(string identificacao)
        {
            var fracao = _fracoes.FirstOrDefault(f => f.Identificacao == identificacao);
            if (fracao == null)
                return false;

            _fracoes.Remove(fracao);
            return true;
        }



        // Método para calcular e atribuir a permilagem para cada fração em um condomínio específico
        public void CalcularPermilagensParaCondominio(Condominio condominio)
        {
            // Filtrar as frações que pertencem ao condomínio e extrair as áreas
            var fracoesDoCondominio = _fracoes.Where(fracao => fracao.Condominio == condominio).ToList();
            var areasDasFracoes = fracoesDoCondominio.Select(fracao => fracao.Area);

            // Calcular a área total do condomínio
            decimal areaTotalCondominio = CalculosFinanceirosService.CalcularAreaTotalCondominio(areasDasFracoes);

            // Calcular e atribuir a permilagem para cada fração
            foreach (var fracao in fracoesDoCondominio)
            {
                fracao.Permilagem = CalculosFinanceirosService.CalcularPermilagem(fracao.Area, areaTotalCondominio);
            }
        }

        // Método para calcular a quota de condomínio para cada fração
        public void CalcularQuotaFracao(decimal orcamentoAnual, Condominio condominio)
        {
            var fracoesDoCondominio = _fracoes.Where(fracao => fracao.Condominio == condominio);

            foreach (var fracao in fracoesDoCondominio)
            {
                fracao.Quota = CalculosFinanceirosService.CalcularQuota(orcamentoAnual, fracao.Permilagem);
            }
        }


        // Método para calcular multa por atraso de pagamento
        public decimal CalcularMultaAtrasoPagamento(FracaoAutonoma fracao, int diasAtraso, decimal taxaMultaDiaria)
        {
            return CalculosFinanceirosService.CalcularMulta(fracao.Quota, diasAtraso, taxaMultaDiaria);
        }

        // Método para gerar notificação de pagamento
        public string GerarNotificacaoPagamento(DateTime dataVencimento)
        {
            return CalculosFinanceirosService.GerarNotificacaoPagamento(dataVencimento);
        }

        #endregion
    }
}
