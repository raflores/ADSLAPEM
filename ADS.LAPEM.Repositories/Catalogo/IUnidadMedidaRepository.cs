using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IUnidadMedidaRepository
    {
        IQueryable<UnidadMedida> ReadUM();
        GridResult<UnidadMedida> ReadUM(GridSettings grid);
        UnidadMedida ReadUMById(long id);
    }
}
