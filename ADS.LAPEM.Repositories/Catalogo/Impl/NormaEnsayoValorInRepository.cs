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
    public class NormaEnsayoValorInRepository : GenericRepository<NormaEnsayoValorIn>, INormaEnsayoValorInRepository
    {
        public NormaEnsayoValorInRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<NormaEnsayoValorIn> ReadNormaIn()
        {
            return Get();
        }

        public GridResult<NormaEnsayoValorIn> ReadNormaIn(GridSettings grid)
        {
            return Get(grid);
        }

        public NormaEnsayoValorIn ReadNormaInById(long id)
        {
            return GetById(id);
        }

        public void CreateNormaIn(NormaEnsayoValorIn norma)
        {
            Add(norma);
        }

        public void UpdateNormaIn(NormaEnsayoValorIn norma)
        {
            Edit(norma);
        }

        public void DeleteNormaIn(NormaEnsayoValorIn norma)
        {
            Remove(norma);
        }
    }
}
