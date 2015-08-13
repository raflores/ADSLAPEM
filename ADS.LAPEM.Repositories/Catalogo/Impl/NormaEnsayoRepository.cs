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
    public class NormaEnsayoRepository : GenericRepository<NormaEnsayo>, INormaEnsayoRepository
    {
        public NormaEnsayoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<NormaEnsayo> ReadNormaEnsayo()
        {
            return Get();
        }

        public IQueryable<NormaEnsayo> ReadNormaEnsayo(string properties)
        {
            return Get(properties);
        }

        public GridResult<NormaEnsayo> ReadNormaEnsayo(GridSettings grid)
        {
            return Get(grid);
        }

        public NormaEnsayo ReadNormaEnsayoById(long id)
        {
            return GetById(id);
        }

        public void CreateNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            Add(normaEnsayo);
        }

        public void UpdateNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            Edit(normaEnsayo);
        }

        public void DeleteNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            Remove(normaEnsayo);
        }            


    }
}
