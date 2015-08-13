using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class AvisoPruebaRepository : GenericRepository<AvisoPrueba>, IAvisoPruebaRepository
    {
        public AvisoPruebaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<AvisoPrueba> ReadAvisoPrueba()
        {
            return Get();
        }

        public GridResult<AvisoPrueba> ReadAvisoPrueba(GridSettings grid)
        {
            return Get(grid);
        }

        public AvisoPrueba ReadAvisoPruebaById(long id)
        {
            return GetById(id);
        }

        public void CreateAvisoPrueba(AvisoPrueba aviso)
        {
            Add(aviso);
        }
    }
}
