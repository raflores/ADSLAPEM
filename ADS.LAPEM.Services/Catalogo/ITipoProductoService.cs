﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface ITipoProductoService
    {
        IEnumerable<TipoProducto> ReadTipoProducto();
        GridResult<TipoProducto> ReadTipoProducto(GridSettings grid);
        TipoProducto ReadTipoProductoById(long id);
        void CreateTipoProducto(TipoProducto tipoProducto);
        void UpdateTipoProducto(TipoProducto tipoProducto);
        void DeleteTipoProducto(TipoProducto tipoProducto);
    }
}
