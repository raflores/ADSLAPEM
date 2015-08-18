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
    public class ResultadoRepository : GenericRepository<Resultado>, IResultadoRepository
    {
        public ResultadoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Resultado> ReadResultado()
        {
            return Get();
        }

        public IQueryable<Resultado> ReadResultado(Expression<Func<Resultado, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<Resultado> ReadResultado(GridSettings grid)
        {
            return Get(grid);
        }

        public Resultado ReadResultadoById(long id)
        {
            return GetById(id);
        }
    }
}
