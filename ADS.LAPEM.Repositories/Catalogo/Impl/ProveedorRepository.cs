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
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Proveedor> ReadProveedor()
        {
            return Get();
        }

        public GridResult<Proveedor> ReadProveedor(GridSettings grid)
        {
            return Get(grid);
        }

        public Proveedor ReadProveedorById(long id)
        {
            return GetById(id);
        }

        public void CreateProveedor(Proveedor proveedor)
        {
            Add(proveedor);
        }

        public void UpdateProveedor(Proveedor proveedor)
        {
            Edit(proveedor);
        }

        public void DeleteProveedor(Proveedor proveedor)
        {
            Remove(proveedor);
        }

    }
}
