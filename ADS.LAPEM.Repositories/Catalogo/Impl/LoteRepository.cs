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
    public class LoteRepository : GenericRepository<Lote>, ILoteRepository
    {
        public LoteRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Lote> ReadLote()
        {
            return Get();
        }

        public GridResult<Lote> ReadLote(GridSettings grid)
        {
            return Get(grid);
        }

        public IQueryable<Lote> ReadLote(Expression<Func<Lote, bool>> exp)
        {
            return Get(exp);
        }

        public Lote ReadLoteById(long id)
        {
            return GetById(id);
        }

        public void CreateLote(Lote lote)
        {
            Add(lote);
        }

        public void UpdateLote(Lote lote)
        {
            Edit(lote);
        }

        public void DeleteLote(Lote lote)
        {
            Remove(lote);
        }
    }
}
