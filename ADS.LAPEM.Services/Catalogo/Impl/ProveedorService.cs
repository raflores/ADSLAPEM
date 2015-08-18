using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Catalogo;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo.Impl
{
    public class ProveedorService : IProveedorService
    {
        protected IProveedorRepository ProveedorRepository { get; set; }

        public IEnumerable<Proveedor> ReadProveedor()
        {
            return ProveedorRepository.ReadProveedor();
        }

        public GridResult<Proveedor> ReadProveedor(GridSettings grid)
        {
            return ProveedorRepository.ReadProveedor(grid);
        }

        public Proveedor ReadProveedorById(long id)
        {
            return ProveedorRepository.ReadProveedorById(id);
        }

        public void CreateProveedor(Proveedor proveedor)
        {
            ProveedorRepository.CreateProveedor(proveedor);
        }

        public void UpdateProveedor(Proveedor proveedor)
        {
            ProveedorRepository.UpdateProveedor(proveedor);
        }

        public void DeleteProveedor(Proveedor proveedor)
        {
            ProveedorRepository.DeleteProveedor(proveedor);
        }

    }
}
