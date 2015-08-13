using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Seguridad
{
    public interface IMenuRepository
    {
        IQueryable<Menu> ReadMenu();
        GridResult<Menu> ReadMenu(GridSettings grid);
        Menu ReadMenuById(long id);
    }
}
