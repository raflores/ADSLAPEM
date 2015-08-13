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
    public class ResultadoService : IResultadoService
    {
        protected IResultadoRepository ResultadoRepository { get; set; }

        public IQueryable<Resultado> ReadResultado()
        {
            return ResultadoRepository.ReadResultado();
        }

        public IQueryable<Resultado> ReadResultadoByLote(long id)
        {
            return ResultadoRepository.ReadResultado(x => x.LoteId == id);
        }

        public GridResult<Resultado> ReadResultado(GridSettings grid)
        {
            return ResultadoRepository.ReadResultado(grid);
        }

        public Resultado ReadResultadoById(long id)
        {
            return ResultadoRepository.ReadResultadoById(id);
        }
    }
}
