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
    public interface ILoteRepository
    {
        IQueryable<Lote> ReadLote();
        GridResult<Lote> ReadLote(GridSettings grid);
        IQueryable<Lote> ReadLote(Expression<Func<Lote, bool>> exp);
        Lote ReadLoteById(long id);
        void CreateLote(Lote lote);
        void UpdateLote(Lote lote);
        void DeleteLote(Lote lote);
    }
}
