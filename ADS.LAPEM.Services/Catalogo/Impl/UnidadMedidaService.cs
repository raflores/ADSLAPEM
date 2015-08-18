using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Catalogo;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo.Impl
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        protected IUnidadMedidaRepository UnidadMedidaRepository { get; set; }

        public IEnumerable<UnidadMedida> ReadUM()
        {
            return UnidadMedidaRepository.ReadUM();
        }

        public GridResult<UnidadMedida> ReadUM(GridSettings grid)
        {
            return UnidadMedidaRepository.ReadUM(grid);
        }

        public UnidadMedida ReadUMById(long id)
        {
            return UnidadMedidaRepository.ReadUMById(id);
        }
    }
}
