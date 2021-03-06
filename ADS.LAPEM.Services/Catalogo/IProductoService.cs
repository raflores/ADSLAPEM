﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IProductoService
    {
        IEnumerable<Producto> ReadProducto();
        GridResult<Producto> ReadProducto(GridSettings grid);
        Producto ReadProductoById(long id);
        void CreateProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(Producto producto);
    }
}
