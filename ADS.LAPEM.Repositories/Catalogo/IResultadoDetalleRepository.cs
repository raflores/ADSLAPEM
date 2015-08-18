using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IResultadoDetalleRepository
    {
        IQueryable<ResultadoDetalle> ReadResultadoDetalle();
        IQueryable<ResultadoDetalle> ReadResultadoDetalle(Expression<Func<ResultadoDetalle, bool>> exp);
        GridResult<ResultadoDetalle> ReadResultadoDetalle(GridSettings grid);
        ResultadoDetalle ReadResultadoDetalleById(long id);
    }
}
