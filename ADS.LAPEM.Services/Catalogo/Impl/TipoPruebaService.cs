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
    public class TipoPruebaService : ITipoPruebaService
    {
        protected ITipoPruebaRepository TipoPruebaRepository { get; set; }

        public IEnumerable<TipoPrueba> ReadTipoPrueba()
        {
            return TipoPruebaRepository.ReadTipoPrueba();
        }

        public GridResult<TipoPrueba> ReadTipoPrueba(GridSettings grid)
        {
            return TipoPruebaRepository.ReadTipoPrueba(grid);
        }

        public TipoPrueba ReadTipoPruebaById(long id)
        {
            return TipoPruebaRepository.ReadTipoPruebaById(id);
        }

        public void CreateTipoPrueba(TipoPrueba tipoPrueba)
        {
            TipoPruebaRepository.CreateTipoPrueba(tipoPrueba);
        }

        public void UpdateTipoPrueba(TipoPrueba tipoPrueba)
        {
            TipoPruebaRepository.UpdateTipoPrueba(tipoPrueba);
        }

        public void DeleteTipoPrueba(TipoPrueba tipoPrueba)
        {
            TipoPruebaRepository.DeleteTipoPrueba(tipoPrueba);
        }
    }
}
