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
    public interface IResultadoRepository
    {
        IQueryable<Resultado> ReadResultado();
        IQueryable<Resultado> ReadResultado(Expression<Func<Resultado, bool>> exp);
        GridResult<Resultado> ReadResultado(GridSettings grid);
        Resultado ReadResultadoById(long Id);
    }
}
