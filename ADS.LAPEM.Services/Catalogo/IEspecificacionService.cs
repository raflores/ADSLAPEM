﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;


namespace ADS.LAPEM.Services.Catalogo
{
    public interface IEspecificacionService
    {
        IEnumerable<Especificacion> ReadEspecificacion();
        GridResult<Especificacion> ReadEspecificacion(GridSettings grid);
        Especificacion ReadEspecificacionById(long id);
        void CreateEspecificacion(Especificacion especificacion);
        void UpdateEspecificacion(Especificacion especificacion);
        void DeleteEspecificacion(Especificacion especificacion);
    }
}
