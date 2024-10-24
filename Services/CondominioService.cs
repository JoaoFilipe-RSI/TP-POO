using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Enums;
using ProjCondominios.Models;

namespace ProjCondominios.Services
{
    public static class CondominioService
    {
        #region Propriedades Privadas
        private static List<Condominio> condominios = new List<Condominio>();
        #endregion

        #region Métodos

        public static List<Condominio> ObterCondominios()
        {
            return condominios;
        }

        #endregion
    }
}
