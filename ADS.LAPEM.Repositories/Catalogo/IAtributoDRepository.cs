using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IAtributoDRepository
    {
        IQueryable<AtributoDetalle> ReadAtributoDetalle();
        IQueryable<AtributoDetalle> ReadAtributoDetalle(Expression<Func<AtributoDetalle, bool>> exp);
        AtributoDetalle ReadAtributoDetalleById(long id);
        
    }
}
