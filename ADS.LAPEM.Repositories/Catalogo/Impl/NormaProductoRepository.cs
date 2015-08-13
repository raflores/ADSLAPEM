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
    public class NormaProductoRepository : GenericRepository<NormaProducto>, INormaProductoRepository
    {
        public NormaProductoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<NormaProducto> ReadNormaProducto()
        {
            return Get();
        }

        public GridResult<NormaProducto> ReadNormaProducto(GridSettings grid)
        {
            return Get(grid);
        }

        public NormaProducto ReadNormaProductoById(long id)
        {
            return GetById(id);
        }

        public void CreateNormaProducto(NormaProducto normaProducto)
        {
            Add(normaProducto);
        }

        public void UpdateNormaProducto(NormaProducto normaProducto)
        {
            Edit(normaProducto);
        }

        public void DeleteNormaProducto(NormaProducto normaProducto)
        {
            Remove(normaProducto);
        }

    }
}
