using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class AtributoDRepository : GenericRepository<AtributoDetalle>, IAtributoDRepository
    {
        public AtributoDRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<AtributoDetalle> ReadAtributoDetalle()
        {
            return Get();
        }

        public IQueryable<AtributoDetalle> ReadAtributoDetalle(Expression<Func<AtributoDetalle, bool>> exp)
        {
            return Get(exp);
        }

        public AtributoDetalle ReadAtributoDetalleById(long id)
        {
            return GetById(id);
        }
    }
}
