using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ITipoEnsayoRepository
    {
        IQueryable<TipoEnsayo> ReadTipoEnsayo();
        GridResult<TipoEnsayo> ReadTipoEnsayo(GridSettings grid);
        TipoEnsayo ReadTipoEnsayoById(long id);
    }
}
