using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Seguridad
{
    public interface IPerfilMenuService
    {
        IEnumerable<PerfilMenu> ReadPerfilMenu();
        IEnumerable<PerfilMenu> ReadPerfilMenuByPerfilId(long id);
        GridResult<PerfilMenu> ReadPerfilMenu(GridSettings grid);
        PerfilMenu ReadPerfilMenuById(long id);
        void CreatePerfilMenu(PerfilMenu perfilMenu);
        void UpdatePerfilMenu(PerfilMenu perfilMenu);
        void DeletePerfilMenu(PerfilMenu perfilMenu);        
    }
}
