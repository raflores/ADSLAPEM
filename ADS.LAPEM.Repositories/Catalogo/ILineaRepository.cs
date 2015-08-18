using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ILineaRepository
    {
        IQueryable<Linea> ReadLinea();
        GridResult<Linea> ReadLinea(GridSettings grid);
        Linea ReadLineaById(long id);
        void CreateLinea(Linea linea);
        void UpdateLinea(Linea linea);
        void DeleteLinea(Linea linea);
    }
}
