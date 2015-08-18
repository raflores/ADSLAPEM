using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    class ResultadoDetalleRepository :GenericRepository<ResultadoDetalle>, IResultadoDetalleRepository
    {
        public ResultadoDetalleRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<ResultadoDetalle> ReadResultadoDetalle()
        {
            return Get();
        }

        public IQueryable<ResultadoDetalle> ReadResultadoDetalle(Expression<Func<ResultadoDetalle, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<ResultadoDetalle> ReadResultadoDetalle(GridSettings grid)
        {
            return Get(grid);
        }

        public ResultadoDetalle ReadResultadoDetalleById(long id)
        {
            return GetById(id);
        }
    }
}
