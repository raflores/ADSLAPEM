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

namespace ADS.LAPEM.Repositories.Seguridad.Impl
{
    public class PerfilMenuRepository : GenericRepository<PerfilMenu>, IPerfilMenuRepository
    {
        public PerfilMenuRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<PerfilMenu> ReadPerfilMenu()
        {
            return Get();
        }

        public IQueryable<PerfilMenu> ReadPerfilMenu(Expression<Func<PerfilMenu, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<PerfilMenu> ReadPerfilMenu(GridSettings grid)
        {
            return Get(grid);
        }

        public PerfilMenu ReadPerfilMenuById(long id)
        {
            return GetById(id);
        }

        public void CreatePerfilMenu(PerfilMenu perfilMenu)
        {
            Add(perfilMenu);
        }

        public void UpdatePerfilMenu(PerfilMenu perfilMenu)
        {
            Edit(perfilMenu);
        }

        public void DeletePerfilMenu(PerfilMenu perfilMenu)
        {
            Remove(perfilMenu);
        }
    }
}
