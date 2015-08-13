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
    public class LineaRepository : GenericRepository<Linea>, ILineaRepository
    {
        public LineaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Linea> ReadLinea()
        {
            return Get();
        }

        public GridResult<Linea> ReadLinea(GridSettings grid)
        {
            return Get(grid);
        }

        public Linea ReadLineaById(long id)
        {
            return GetById(id);
        }

        public void CreateLinea(Linea linea)
        {
            Add(linea);
        }

        public void UpdateLinea(Linea linea)
        {
            Edit(linea);
        }

        public void DeleteLinea(Linea linea)
        {
            Remove(linea);
        }

    }
}
