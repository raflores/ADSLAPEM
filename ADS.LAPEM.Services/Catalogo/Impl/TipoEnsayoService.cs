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
    public class TipoEnsayoService : ITipoEnsayoService
    {
        protected ITipoEnsayoRepository TipoEnsayoRepository { get; set; }

        public IEnumerable<TipoEnsayo> ReadTipoEnsayo()
        {
            return TipoEnsayoRepository.ReadTipoEnsayo();
        }

        public GridResult<TipoEnsayo> ReadTipoEnsayo(GridSettings grid)
        {
            return TipoEnsayoRepository.ReadTipoEnsayo(grid);
        }

        public TipoEnsayo ReadTipoEnsayoById(long id)
        {
            return TipoEnsayoRepository.ReadTipoEnsayoById(id);
        }
    }
}
