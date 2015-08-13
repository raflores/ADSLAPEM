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
    public class LineaService : ILineaService
    {
        protected ILineaRepository LineaRepository { get; set; }

        public IEnumerable<Linea> ReadLinea()
        {
            return LineaRepository.ReadLinea();
        }

        public GridResult<Linea> ReadLinea(GridSettings grid)
        {
            return LineaRepository.ReadLinea(grid);
        }

        public Linea ReadLineaById(long id)
        {
            return LineaRepository.ReadLineaById(id);
        }

        public void CreateLinea(Linea linea)
        {
            LineaRepository.CreateLinea(linea);
        }

        public void UpdateLinea(Linea linea)
        {
            LineaRepository.UpdateLinea(linea);
        }

        public void DeleteLinea(Linea linea)
        {
            LineaRepository.DeleteLinea(linea);
        }
    }
}
