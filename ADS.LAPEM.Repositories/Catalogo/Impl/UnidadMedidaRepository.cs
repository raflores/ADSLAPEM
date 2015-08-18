using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class UnidadMedidaRepository : GenericRepository<UnidadMedida>, IUnidadMedidaRepository
    {
        public UnidadMedidaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<UnidadMedida> ReadUM()
        {
            return Get();
        }

        public GridResult<UnidadMedida> ReadUM(GridSettings grid)
        {
            return Get(grid);
        }

        public UnidadMedida ReadUMById(long id)
        {
            return GetById(id);
        }
    }
}
