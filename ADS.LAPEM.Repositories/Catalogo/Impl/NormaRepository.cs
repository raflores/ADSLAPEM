using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class NormaRepository : GenericRepository<Norma>, INormaRepository
    {
        public NormaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Norma> ReadNorma()
        {
            return Get();
        }

        public IQueryable<Norma> ReadNorma(Expression<Func<Norma, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<Norma> ReadNorma(GridSettings grid)
        {
            return Get(grid);
        }

        public Norma ReadNormaById(long id)
        {
            return GetById(id);
        }

        public void CreateNorma(Norma norma)
        {
            Add(norma);
        }

        public void UpdateNorma(Norma norma)
        {
            Edit(norma);
        }

        public void DeleteNorma(Norma norma)
        {
            Remove(norma);
        }




    }
}
