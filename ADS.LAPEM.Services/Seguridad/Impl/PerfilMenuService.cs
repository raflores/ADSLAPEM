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
    public class PerfilMenuService : IPerfilMenuService
    {
        protected IPerfilMenuRepository PerfilMenuRepository { get; set; }

        public IEnumerable<PerfilMenu> ReadPerfilMenu()
        {
            return PerfilMenuRepository.ReadPerfilMenu();
        }

        public GridResult<PerfilMenu> ReadPerfilMenu(GridSettings grid)
        {
            return PerfilMenuRepository.ReadPerfilMenu(grid);
        }

        public IEnumerable<PerfilMenu> ReadPerfilMenuByPerfilId(long id)
        {
            //return PerfilMenuRepository.ReadPerfilMenu(x => x.PerfilId == id && x.Activo == true);
            return PerfilMenuRepository.ReadPerfilMenu(x => x.PerfilId == id);
        }

        public PerfilMenu ReadPerfilMenuById(long id)
        {
            return PerfilMenuRepository.ReadPerfilMenuById(id);
        }

        public void CreatePerfilMenu(PerfilMenu perfilMenu)
        {
            PerfilMenuRepository.CreatePerfilMenu(perfilMenu);
        }

        public void UpdatePerfilMenu(PerfilMenu perfilMenu)
        {
            PerfilMenuRepository.UpdatePerfilMenu(perfilMenu);
        }

        public void DeletePerfilMenu(PerfilMenu perfilMenu)
        {
            PerfilMenuRepository.DeletePerfilMenu(perfilMenu);
        }
    }
}
