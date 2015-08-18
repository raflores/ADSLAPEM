using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IProveedorService
    {
        IEnumerable<Proveedor> ReadProveedor();
        GridResult<Proveedor> ReadProveedor(GridSettings grid);
        Proveedor ReadProveedorById(long id);
        void CreateProveedor(Proveedor proveedor);
        void UpdateProveedor(Proveedor proveedor);
        void DeleteProveedor(Proveedor proveedor);
    }
}
