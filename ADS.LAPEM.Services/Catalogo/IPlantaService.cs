﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IPlantaService
    {
        IEnumerable<Planta> ReadPlanta();
        GridResult<Planta> ReadPlanta(GridSettings grid);
        Planta ReadPlantaById(long id);
        void CreatePlanta(Planta planta);
        void UpdatePlanta(Planta planta);
        void DeletePlanta(Planta planta);
    }
}
