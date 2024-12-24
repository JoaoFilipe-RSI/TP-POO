using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;
using CalculadoraFinanceira;
using ProjCondominios.Enums;

namespace ProjCondominios.Services
{
    public class FracaoAutonomaService
    {
        #region Propriedades Privadas
        private readonly CondominioService _condominioService;
        private readonly CondominoService _condominoService;
        private readonly List<FracaoAutonoma> _fracoes;
        private readonly FileService _jsonFileService;
        #endregion

        #region Construtor
        public FracaoAutonomaService(
            CondominioService condominioService,
            CondominoService condominoService,
            FileService fileService,
            List<FracaoAutonoma>? fracoes = null)
        {
            _condominioService = condominioService ?? throw new ArgumentNullException(nameof(condominioService));
            _condominoService = condominoService ?? throw new ArgumentNullException(nameof(condominoService));
            _jsonFileService = fileService ?? throw new ArgumentNullException(nameof(fileService));

            _fracoes = fracoes ?? _jsonFileService.CarregarFracoes(); 
            CorrigirDadosFracoes(); 
        }
        #endregion

        #region Métodos

        // Método para carregar os dados do JSON
        public List<FracaoAutonoma> CarregarFracoes()
        {
            try
            {
                if (_jsonFileService == null)
                {
                    throw new InvalidOperationException("O serviço de arquivos JSON não foi inicializado.");
                }

                // Carrega as frações, condomínios e condóminos dos arquivos JSON
                var fracoes = _jsonFileService.CarregarFracoes();
                var condominios = _jsonFileService.CarregarCondominios();
                var condominos = _jsonFileService.CarregarCondominos();

                _fracoes.Clear();

                foreach (var fracao in fracoes)
                {
                    var condominio = _condominioService.ObterPorId(fracao.CondominioId);
                    var proprietario = _condominoService.BuscarPorId(fracao.ProprietarioId);
                    var inquilino = fracao.InquilinoId.HasValue
                        ? _condominoService.BuscarPorId(fracao.InquilinoId.Value)
                        : null;

                    if (condominio == null)
                        throw new Exception($"Condomínio não encontrado para a fração {fracao.Identificacao}.");

                    if (proprietario == null)
                        throw new Exception($"Proprietário não encontrado para a fração {fracao.Identificacao}.");

                    fracao.AssociarObjetos(condominio, proprietario, inquilino);

                    _fracoes.Add(fracao);
                }

                return _fracoes; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar as frações do arquivo: {ex.Message}");
            }
        }

        // Método para adicionar uma fração autónoma
        public void AdicionarFracao(string identificacao, decimal area, decimal permilagem, decimal quota,TipoFracao tipoFracao, int condominioId, int proprietarioId, int? inquilinoId)
                {
                try
                {
                    if (string.IsNullOrWhiteSpace(identificacao))
                        throw new ArgumentException("Identificação é obrigatória.");

                    if (area <= 0 || permilagem <= 0 || quota < 0)
                        throw new ArgumentException("Valores inválidos para área, permilagem ou quota.");

                    if (condominioId <= 0 || proprietarioId <= 0)
                        throw new ArgumentException("IDs inválidos para condomínio ou proprietário.");

                    var condominio = _condominioService.ObterPorId(condominioId)
                        ?? throw new Exception($"Condomínio com ID {condominioId} não encontrado.");

                    var proprietario = _condominoService.BuscarPorId(proprietarioId)
                     ?? throw new Exception($"Proprietário com ID {proprietarioId} não encontrado.");

                    var inquilino = inquilinoId.HasValue
                        ? _condominoService.BuscarPorId(inquilinoId.Value)
                        : null;

                    var novaFracao = new FracaoAutonoma(
                        identificacao, area, permilagem, quota, tipoFracao, condominioId, proprietarioId, inquilinoId
                    );

                    novaFracao.AssociarObjetos(condominio, proprietario, inquilino);

                    _fracoes.Add(novaFracao);

                    // Salvar no arquivo JSON
                    SalvarFracoes(_fracoes);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao adicionar fração: {ex.Message}");
                }
            }

        // Método salvar os dados
        public void SalvarFracoes(List<FracaoAutonoma> fracoes)
        {
            try
            {
                _jsonFileService.SalvarFracoes(fracoes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar frações no arquivo: {ex.Message}");
            }
        }

        // Método para corrigir dados de entrada
        public void CorrigirDadosFracoes()
        {
            foreach (var fracao in _fracoes)
            {
                if (fracao.Condominio != null)
                {
                    fracao.CondominioId = fracao.Condominio.Id; 
                }
            }
        }

        // Método para listar todas as frações autónomas
        public List<FracaoAutonoma> ListarTodasFracoes()
        {
            foreach (var fracao in _fracoes)
            {
                if (fracao.Condominio == null)
                    fracao.Condominio = _condominioService.ObterPorId(fracao.CondominioId);

                if (fracao.Proprietario == null)
                    fracao.Proprietario = _condominoService.BuscarPorId(fracao.ProprietarioId);

                if (fracao.Inquilino == null && fracao.InquilinoId.HasValue)
                    fracao.Inquilino = _condominoService.BuscarPorId(fracao.InquilinoId.Value);
            }
            return _fracoes ?? new List<FracaoAutonoma>();
        }
        
        // Método para listar condomínios
        public List<Condominio> ListarCondominios()
        {
            var todosCondominios = _condominioService.ObterCondominios();
            var condominiosComFracoes = _fracoes
                .Where(f => f.Condominio != null)
                .Select(f => f.Condominio)
                .Distinct();

            return todosCondominios.Union(condominiosComFracoes).ToList();
        }

        // Método para listar frações por condominio
        public List<FracaoAutonoma> ListarFracoesPorCondominio(int condominioId)
        {
            var fracoesFiltradas = _fracoes.Where(fracao => fracao.CondominioId == condominioId).ToList();

            foreach (var fracao in fracoesFiltradas)
            {
                if (fracao.Condominio == null)
                    fracao.Condominio = _condominioService.ObterPorId(fracao.CondominioId);

                if (fracao.Proprietario == null)
                    fracao.Proprietario = _condominoService.BuscarPorId(fracao.ProprietarioId);

                if (fracao.Inquilino == null && fracao.InquilinoId.HasValue)
                    fracao.Inquilino = _condominoService.BuscarPorId(fracao.InquilinoId.Value);
            }
            return fracoesFiltradas;
        }

        // Método para atualizar uma fração existente
        public bool AtualizarFracao(string identificacao, decimal? novaArea = null, decimal? novaPermilagem = null, decimal? novaQuota = null, int? novoCondominioId = null,  int? novoProprietarioId = null, int? novoInquilinoId = null)
        {
            var fracao = _fracoes.FirstOrDefault(f => f.Identificacao == identificacao);
            if (fracao == null)
                return false;

            if (novaArea.HasValue)
                fracao.Area = novaArea.Value;

            if (novaPermilagem.HasValue)
                fracao.Permilagem = novaPermilagem.Value;

            if (novaQuota.HasValue)
                fracao.Quota = novaQuota.Value;

            if (novoCondominioId.HasValue)
            {
                var condominio = _condominioService.ObterPorId(novoCondominioId.Value);
                if (condominio == null)
                    throw new ArgumentException("Condomínio inválido.");
                fracao.Condominio = condominio;
                fracao.CondominioId = condominio.Id;
            }

            if (novoProprietarioId.HasValue)
            {
                var proprietario = _condominoService.BuscarPorId(novoProprietarioId.Value);
                if (proprietario == null)
                    throw new ArgumentException("Proprietário inválido.");
                fracao.Proprietario = proprietario;
                fracao.ProprietarioId = proprietario.Id;
            }

            if (novoInquilinoId.HasValue)
            {
                if (novoInquilinoId == 0) // Trata a opção "N/A"
                {
                    fracao.Inquilino = null;
                    fracao.InquilinoId = null;
                }
                else
                {
                    var inquilino = _condominoService.BuscarPorId(novoInquilinoId.Value);
                    if (inquilino == null)
                        throw new ArgumentException("Inquilino inválido.");
                    fracao.Inquilino = inquilino;
                    fracao.InquilinoId = inquilino.Id;
                }
            }

            // Salvar alterações no arquivo JSON
            _jsonFileService.SalvarFracoes(_fracoes);
            return true;
        }

        // Método para remover uma fração pelo identificador
        public bool RemoverFracao(int condominioId, string identificacaoFracao)
        {
            var fracao = _fracoes.FirstOrDefault(f =>
                f.CondominioId == condominioId && f.Identificacao == identificacaoFracao);

            if (fracao != null)
            {
                _fracoes.Remove(fracao);
                _jsonFileService.SalvarFracoes(_fracoes);

                return true; 
            }
            return false; 
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
