using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface ITipoPruebaService
    {
        IEnumerable<TipoPrueba> ReadTipoPrueba();
        GridResult<TipoPrueba> ReadTipoPrueba(GridSettings grid);
        TipoPrueba ReadTipoPruebaById(long id);
        void CreateTipoPrueba(TipoPrueba tprueba);
        void UpdateTipoPrueba(TipoPrueba tprueba);
        void DeleteTipoPrueba(TipoPrueba tprueba);
    }
}
