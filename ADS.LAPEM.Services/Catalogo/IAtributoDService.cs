using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IAtributoDService
    {
        IEnumerable<AtributoDetalle> ReadAtributoDetalle();
        AtributoDetalle ReadAtributoDetalleById(long id);
        IEnumerable<AtributoDetalle> ReadAtributoDetalleByResultadoId(long id);
    }
}
