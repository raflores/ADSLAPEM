using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface INormaEnsayoValorMmService
    {
        IEnumerable<NormaEnsayoValorMm> ReadNormaMm();
        GridResult<NormaEnsayoValorMm> ReadNormaMm(GridSettings grid);
        NormaEnsayoValorMm ReadNormaMmById(long id);
        void CreateNormaMm(NormaEnsayoValorMm norma);
        void UpdateNormaMm(NormaEnsayoValorMm norma);
        void DeleteNormaMm(NormaEnsayoValorMm norma);
    }
}
