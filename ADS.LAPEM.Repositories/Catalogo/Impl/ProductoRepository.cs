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
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {

        ProductoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Producto> ReadProducto()
        {
            return Get();
        }

        public GridResult<Producto> ReadProducto(GridSettings grid)
        {
            return Get(grid);
        }

        public Producto ReadProductoById(long id)
        {
            return GetById(id);
        }

        public void CreateProducto(Producto producto)
        {
            Add(producto);
        }

        public void UpdateProducto(Producto producto)
        {
            Edit(producto);
        }

        public void DeleteProducto(Producto producto)
        {
            Remove(producto);
        }
    }
}
