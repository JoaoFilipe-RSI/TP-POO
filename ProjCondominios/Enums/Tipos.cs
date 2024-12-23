using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCondominios.Enums
{    public enum TipoCondomino
    {
        Proprietario = 0,
        Inquilino = 1
    }
    public enum TipoCondominio
    {
        Residencial,
        Comercial,
        Industrial,
        Misto
    }
    public enum TipoFracao
    {
        Residencia,
        Garagem,
        Loja,
        Pavilhão,
        Vazia
    }

    public enum TipoDespesa
    {
        Reparacoes,
        Limpeza,
        Jardinagem,
        Agua,
        Eletricidade,
        Outros
    }
    public enum TipoReserva

    {
        SalaoFestas,
        SalaReunioes,
        Piscina,
        AreaChurrasco,
        AreaDesportiva,
        ParqueInfantil,        
        Outros
    }
}
