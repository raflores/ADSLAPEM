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
    public interface IPerfilMenuRepository
    {
        IQueryable<PerfilMenu> ReadPerfilMenu();
        IQueryable<PerfilMenu> ReadPerfilMenu(Expression<Func<PerfilMenu, bool>> exp);
        GridResult<PerfilMenu> ReadPerfilMenu(GridSettings grid);        
        PerfilMenu ReadPerfilMenuById(long id);
        void CreatePerfilMenu(PerfilMenu perfilMenu);
        void UpdatePerfilMenu(PerfilMenu perfilMenu);
        void DeletePerfilMenu(PerfilMenu perfilMenu);
    }
}
