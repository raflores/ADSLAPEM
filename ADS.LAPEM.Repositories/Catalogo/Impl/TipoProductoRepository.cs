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
    public class TipoProductoRepository : GenericRepository<TipoProducto>, ITipoProductoRepository
    {
        public TipoProductoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<TipoProducto> ReadTipoProducto()
        {
            return Get();
        }

        public GridResult<TipoProducto> ReadTipoProducto(GridSettings grid)
        {
            return Get(grid);
        }

        public TipoProducto ReadTipoProductoById(long id)
        {
            return GetById(id);
        }

        public void CreateTipoProducto(TipoProducto tipoProducto)
        {
            Add(tipoProducto);
        }

        public void UpdateTipoProducto(TipoProducto tipoProducto)
        {
            Edit(tipoProducto);
        }

        public void DeleteTipoProducto(TipoProducto tipoProducto)
        {
            Remove(tipoProducto);
        }
    }
}
