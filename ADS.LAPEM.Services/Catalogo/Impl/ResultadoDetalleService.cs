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
    public class ResultadoDetalleService : IResultadoDetalleService
    {
        protected IResultadoDetalleRepository ResultadoDetalleRepository { get; set; }

        public IEnumerable<ResultadoDetalle> ReadResultadoDetalle()
        {
            return ResultadoDetalleRepository.ReadResultadoDetalle();
        }

        public IEnumerable<ResultadoDetalle> ReadResultadoDetalleByResultadoId(long id)
        {
            return ResultadoDetalleRepository.ReadResultadoDetalle(x => x.ResultadoId == id);
        }

        public GridResult<ResultadoDetalle> ReadResultadoDetalle(GridSettings grid)
        {
            return ResultadoDetalleRepository.ReadResultadoDetalle(grid);
        }

        public ResultadoDetalle ReadResultadoById(long id)
        {
            return ResultadoDetalleRepository.ReadResultadoDetalleById(id);
        }
    }
}
