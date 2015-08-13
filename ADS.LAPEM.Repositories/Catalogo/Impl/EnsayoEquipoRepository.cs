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
    public class EnsayoEquipoRepository : GenericRepository<EnsayoEquipo>, IEnsayoEquipoRepository
    {
        public EnsayoEquipoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<EnsayoEquipo> ReadEnsayoEquipo()
        {
            return Get();
        }

        public GridResult<EnsayoEquipo> ReadEnsayoEquipo(GridSettings grid)
        {
            return Get(grid);
        }

        public EnsayoEquipo ReadEnsayoEquipoById(long id)
        {
            return GetById(id);
        }

        public void CreateEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            Add(ensayoEquipo);
        }

        public void UpdateEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            Edit(ensayoEquipo);
        }

        public void DeleteEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            Remove(ensayoEquipo);
        }

    }
}
