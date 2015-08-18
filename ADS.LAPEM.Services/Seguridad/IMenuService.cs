using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Seguridad
{
    public interface IMenuService
    {
        IEnumerable<Menu> ReadMenu();
        GridResult<Menu> ReadMenu(GridSettings grid);
        Menu ReadMenuById(long id);
    }
}
