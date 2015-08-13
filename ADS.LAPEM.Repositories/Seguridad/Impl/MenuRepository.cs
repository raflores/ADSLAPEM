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
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Menu> ReadMenu()
        {
            return Get();
        }

        public GridResult<Menu> ReadMenu(GridSettings grid)
        {
            return Get(grid);
        }

        public Menu ReadMenuById(long id)
        {
            return GetById(id);
        }

    }
}
