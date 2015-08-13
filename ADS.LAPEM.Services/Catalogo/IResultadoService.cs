using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IResultadoService
    {
        IQueryable<Resultado> ReadResultado();
        IQueryable<Resultado> ReadResultadoByLote(long id);
        GridResult<Resultado> ReadResultado(GridSettings grid);
        Resultado ReadResultadoById(long id);
    }
}
