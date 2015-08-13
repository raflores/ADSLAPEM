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
    public class EnsayoRepository : GenericRepository<Ensayo>, IEnsayoRepository
    {
        public EnsayoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Ensayo> ReadEnsayo()
        {
            return Get();
        }

        public GridResult<Ensayo> ReadEnsayo(GridSettings grid)
        {
            return Get(grid);
        }

        public Ensayo ReadEnsayoById(long id)
        {
            return GetById(id);
        }

        public void CreateEnsayo(Ensayo ensayo)
        {
            Add(ensayo);
        }

        public void UpdateEnsayo(Ensayo ensayo)
        {
            Edit(ensayo);
        }

        public void DeleteEnsayo(Ensayo ensayo)
        {
            Remove(ensayo);
        }
    }
}
