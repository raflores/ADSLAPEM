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
    public class TipoEnsayoRepository : GenericRepository<TipoEnsayo>, ITipoEnsayoRepository
    {
        TipoEnsayoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<TipoEnsayo> ReadTipoEnsayo()
        {
            return Get();
        }

        public GridResult<TipoEnsayo> ReadTipoEnsayo(GridSettings grid)
        {
            return Get(grid);
        }

        public TipoEnsayo ReadTipoEnsayoById(long id)
        {
            return GetById(id);
        }
    }
}
