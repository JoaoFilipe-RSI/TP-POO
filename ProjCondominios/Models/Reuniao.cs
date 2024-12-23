using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Models
{
    public class Reuniao
    {
        #region Propriedades Privadas

        private List<Condomino> _participantes;

        #endregion

        #region Propriedades Públicas

        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string Pauta { get; set; }
        public List<Condomino> Participantes => _participantes;

        #endregion

        #region Construtores

        public Reuniao(DateTime dataHora, string local, string pauta)
        {
            DataHora = dataHora;
            Local = local;
            Pauta = pauta;
            _participantes = new List<Condomino>();
        }

        #endregion

        #region Métodos

        public void AdicionarParticipante(Condomino condomino) => _participantes.Add(condomino);
        public void RemoverParticipante(Condomino condomino) => _participantes.Remove(condomino);
        public IEnumerable<Condomino> ListarParticipantes() => _participantes;

        #endregion
    }
}

