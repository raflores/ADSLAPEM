﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IEnsayoEquipoRepository
    {
        IQueryable<EnsayoEquipo> ReadEnsayoEquipo();
        GridResult<EnsayoEquipo> ReadEnsayoEquipo(GridSettings grid);
        EnsayoEquipo ReadEnsayoEquipoById(long id);
        void CreateEnsayoEquipo(EnsayoEquipo ensayoEquipo);
        void UpdateEnsayoEquipo(EnsayoEquipo ensayoEquipo);
        void DeleteEnsayoEquipo(EnsayoEquipo ensayoEquipo);
    }
}
