using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Repositories.Seguridad;

namespace ADS.LAPEM.Services.Seguridad.Impl
{
    public class MenuService : IMenuService
    {
        protected IMenuRepository MenuRepository { get; set; }

        public IEnumerable<Menu> ReadMenu()
        {
            return MenuRepository.ReadMenu();
        }

        public GridResult<Menu> ReadMenu(GridSettings grid)
        {
            return MenuRepository.ReadMenu(grid);
        }

        public Menu ReadMenuById(long id)
        {
            return MenuRepository.ReadMenuById(id);
        }
    }
}
