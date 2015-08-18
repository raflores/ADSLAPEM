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
    public class TipoPruebaRepository : GenericRepository<TipoPrueba>, ITipoPruebaRepository
    {
        public TipoPruebaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<TipoPrueba> ReadTipoPrueba()
        {
            return Get();
        }

        public GridResult<TipoPrueba> ReadTipoPrueba(GridSettings grid)
        {
            return Get(grid);
        }

        public TipoPrueba ReadTipoPruebaById(long id)
        {
            return GetById(id);
        }

        public void CreateTipoPrueba(TipoPrueba tipoPrueba)
        {
            Add(tipoPrueba);
        }

        public void UpdateTipoPrueba(TipoPrueba tipoPrueba)
        {
            Edit(tipoPrueba);
        }

        public void DeleteTipoPrueba(TipoPrueba tipoPrueba)
        {
            Remove(tipoPrueba);
        }


    }
}
