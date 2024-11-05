using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;

namespace ProjCondominios.Services
{
    public class FracaoAutonomaService
    {
        #region Propriedades Privadas
        private readonly List<FracaoAutonoma> _fracoes;
        #endregion


        #region Construtor
        public FracaoAutonomaService()
        {
            _fracoes = new List<FracaoAutonoma>();
        }
        #endregion

        #region Métodos

        // Método para adicionar uma fração autónoma
        public void AdicionarFracao(string identificacao, double area, double permilagem, Condominio condominio, Condomino proprietario, Condomino? inquilino = null)
        {
            if (string.IsNullOrEmpty(identificacao) || permilagem <= 0 || condominio == null || proprietario == null)
                throw new ArgumentException("Dados inválidos. Identificação, permilagem, condomínio e proprietário são obrigatórios.");

            FracaoAutonoma novaFracao = new FracaoAutonoma(identificacao, area, permilagem, condominio, proprietario, inquilino);
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
        public bool AtualizarFracao(string identificacao, double? novaPermilagem = null, Condominio? novoCondominio = null, Condomino? novoProprietario = null, Condomino? novoInquilino = null)
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

        #endregion
    }
}
