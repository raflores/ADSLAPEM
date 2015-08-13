﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface INormaEnsayoValorInService
    {
        IEnumerable<NormaEnsayoValorIn> ReadNormaIn();
        GridResult<NormaEnsayoValorIn> ReadNormaIn(GridSettings grid);
        NormaEnsayoValorIn ReadNormaInById(long id);
        void CreateNormaIn(NormaEnsayoValorIn norma);
        void UpdateNormaIn(NormaEnsayoValorIn norma);
        void DeleteNormaIn(NormaEnsayoValorIn norma);
    }
}
