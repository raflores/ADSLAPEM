using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IResultadoImagenService
    {
        IEnumerable<ResultadoDetalle> ReadResultadoDetalle();
        GridResult<ResultadoDetalle> ReadResultadoDetalle(GridSettings grid);
        ResultadoDetalle ReadResultadoById(long id);
    }
}
