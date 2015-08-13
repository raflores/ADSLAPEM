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
    public class TipoProductoService : ITipoProductoService
    {
        protected ITipoProductoRepository TipoProductoRepository { get; set; }

        public IEnumerable<TipoProducto> ReadTipoProducto()
        {
            return TipoProductoRepository.ReadTipoProducto();
        }

        public GridResult<TipoProducto> ReadTipoProducto(GridSettings grid)
        {
            return TipoProductoRepository.ReadTipoProducto(grid);
        }

        public TipoProducto ReadTipoProductoById(long id)
        {
            return TipoProductoRepository.ReadTipoProductoById(id);
        }

        public void CreateTipoProducto(TipoProducto tipoProducto)
        {
            TipoProductoRepository.CreateTipoProducto(tipoProducto);
        }

        public void UpdateTipoProducto(TipoProducto tipoProducto)
        {
            TipoProductoRepository.UpdateTipoProducto(tipoProducto);
        }

        public void DeleteTipoProducto(TipoProducto tipoProducto)
        {
            TipoProductoRepository.DeleteTipoProducto(tipoProducto);
        }
    }
}
