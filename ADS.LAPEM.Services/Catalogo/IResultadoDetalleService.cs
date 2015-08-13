using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IResultadoDetalleService
    {
        IEnumerable<ResultadoDetalle> ReadResultadoDetalle();
        IEnumerable<ResultadoDetalle> ReadResultadoDetalleByResultadoId(long id);
        GridResult<ResultadoDetalle> ReadResultadoDetalle(GridSettings grid);
        ResultadoDetalle ReadResultadoById(long id);
    }
}
