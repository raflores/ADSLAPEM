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
    public class AtributoDService : IAtributoDService
    {
        protected IAtributoDRepository AtributoDRepository { get; set; }

        public IEnumerable<AtributoDetalle> ReadAtributoDetalle()
        {
            return AtributoDRepository.ReadAtributoDetalle();
        }

        public IEnumerable<AtributoDetalle> ReadAtributoDetalleByResultadoId(long id)
        {
            return AtributoDRepository.ReadAtributoDetalle(x => x.ResultadoDetalleId == id);
        }

        public AtributoDetalle ReadAtributoDetalleById(long id)
        {
            return AtributoDRepository.ReadAtributoDetalleById(id);
        }
    }
}
