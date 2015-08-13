using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ITipoPruebaRepository
    {
        IQueryable<TipoPrueba> ReadTipoPrueba();
        GridResult<TipoPrueba> ReadTipoPrueba(GridSettings grid);
        TipoPrueba ReadTipoPruebaById(long id);
        void CreateTipoPrueba(TipoPrueba tPrueba);
        void UpdateTipoPrueba(TipoPrueba tPrueba);
        void DeleteTipoPrueba(TipoPrueba tPrueba);
    }
}
