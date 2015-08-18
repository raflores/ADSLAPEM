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
    public class NormaProductoService : INormaProductoService
    {
        protected INormaProductoRepository NormaProductoRepository { get; set; }

        public IEnumerable<NormaProducto> ReadNormaProducto()
        {
            return NormaProductoRepository.ReadNormaProducto();
        }

        public GridResult<NormaProducto> ReadNormaProducto(GridSettings grid)
        {
            return NormaProductoRepository.ReadNormaProducto(grid);
        }

        public NormaProducto ReadNormaProductoById(long id)
        {
            return NormaProductoRepository.ReadNormaProductoById(id);
        }

        public void CreateNormaProducto(NormaProducto normaProducto)
        {
            NormaProductoRepository.CreateNormaProducto(normaProducto);
        }

        public void UpdateNormaProducto(NormaProducto normaProducto)
        {
            NormaProductoRepository.UpdateNormaProducto(normaProducto);
        }

        public void DeleteNormaProducto(NormaProducto normaProducto)
        {
            NormaProductoRepository.DeleteNormaProducto(normaProducto);
        }
    }
}
