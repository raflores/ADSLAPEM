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
    public class SiloRepository : GenericRepository<Silo>, ISiloRepository
    {
        public SiloRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Silo> ReadSilo()
        {
            return Get();
        }

        public GridResult<Silo> ReadSilo(GridSettings grid)
        {
            return Get(grid);
        }

        public Silo ReadSiloById(long id)
        {
            return GetById(id);
        }

        public void CreateSilo(Silo silo)
        {
            Add(silo);
        }

        public void UpdateSilo(Silo silo)
        {
            Edit(silo);
        }

        public void DeleteSilo(Silo silo)
        {
            Remove(silo);
        }
    }
}
