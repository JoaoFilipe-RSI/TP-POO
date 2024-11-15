using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjCondominios.Models;

namespace ProjCondominios.Interfaces
{
    public interface IRelatorioService
    {
        string GerarRelatorioPagamentos();
        string GerarRelatorioDespesas();
        string GerarRelatorioReservas();
        string GerarRelatorioFinanceiro();
        string GerarAtaReuniao(Reuniao reuniao);
    }
}

