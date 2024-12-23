using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;

namespace ProjCondominios.Services
{
    public class CondominoService
    {
        #region Propriedades Privadas
        private List<Condomino> _condominos;
        private readonly FileService _jsonFileService;
        #endregion

        #region Propriedades Públicas
        public List<Condomino> Condominos => _condominos;
        #endregion

        #region Construtores
        public CondominoService()
        {
            _jsonFileService = new FileService(); // Inicializa o serviço de persistência
            _condominos = _jsonFileService.CarregarCondominos() ?? new List<Condomino>(); // Garante lista não nula
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona um novo condômino à lista e persiste no arquivo.
        /// </summary>
        public void Adicionar(Condomino condomino)
        {
            if (condomino == null)
                throw new ArgumentNullException(nameof(condomino));

            _condominos.Add(condomino);
            PersistirAlteracoes();
        }

        /// <summary>
        /// Remove um condómino da lista com base no ID e salva as alterações.
        /// </summary>
        public void Remover(int id)
        {
            var condomino = BuscarPorId(id);
            if (condomino == null)
                throw new InvalidOperationException($"Condômino com ID {id} não encontrado.");

            _condominos.Remove(condomino);
            PersistirAlteracoes();
        }

        /// <summary>
        /// Retorna a lista completa de condóminos.
        /// </summary>
        public List<Condomino> ListarTodos() => _condominos;

        /// <summary>
        /// Filtra um condómino pelo ID.
        /// </summary>
        public Condomino? BuscarPorId(int id)
        {
           return _condominos.FirstOrDefault(c => c.Id == id)
           ?? throw new Exception($"Condomino com ID {id} não encontrado.");
        }

        /// <summary>
        /// Atualiza os dados de um condómino existente.
        /// </summary>
        public void Atualizar(Condomino condominoAtualizado)
        {
            if (condominoAtualizado == null)
                throw new ArgumentNullException(nameof(condominoAtualizado));

            var condominoExistente = BuscarPorId(condominoAtualizado.Id);

            if (condominoExistente == null)
                throw new InvalidOperationException($"Condómino com ID {condominoAtualizado.Id} não encontrado.");

            // Atualiza as propriedades do condómino
            condominoExistente.Nome = condominoAtualizado.Nome;
            condominoExistente.NIF = condominoAtualizado.NIF;
            condominoExistente.Contato = condominoAtualizado.Contato;
            condominoExistente.TipoCondomino = condominoAtualizado.TipoCondomino;

            PersistirAlteracoes();
        }

        /// <summary>
        /// Persiste as alterações na lista de condôminos.
        /// </summary>
        private void PersistirAlteracoes()
        {
            _jsonFileService.SalvarCondominos(_condominos.ToList());
        }

        #endregion
    }
}
