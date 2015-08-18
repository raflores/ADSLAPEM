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
    public class NormaEnsayoValorMmRepository : GenericRepository<NormaEnsayoValorMm>, INormaEnsayoValorMmRepository
    {
        public NormaEnsayoValorMmRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<NormaEnsayoValorMm> ReadNormaMm()
        {
            return Get();
        }

        public GridResult<NormaEnsayoValorMm> ReadNormaMm(GridSettings grid)
        {
            return Get(grid);
        }

        public NormaEnsayoValorMm ReadNormaMmById(long id)
        {
            return GetById(id);
        }

        public void CreateNormaMm(NormaEnsayoValorMm norma)
        {
            Add(norma);
        }

        public void UpdateNormaMm(NormaEnsayoValorMm norma)
        {
            Edit(norma);
        }

        public void DeleteNormaMm(NormaEnsayoValorMm norma)
        {
            Remove(norma);
        }
    }
}
