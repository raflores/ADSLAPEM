using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface INormaProductoRepository
    {
        IQueryable<NormaProducto> ReadNormaProducto();
        GridResult<NormaProducto> ReadNormaProducto(GridSettings grid);
        NormaProducto ReadNormaProductoById(long id);
        void CreateNormaProducto(NormaProducto normaProducto);
        void UpdateNormaProducto(NormaProducto normaProducto);
        void DeleteNormaProducto(NormaProducto normaProducto);
    }
}
