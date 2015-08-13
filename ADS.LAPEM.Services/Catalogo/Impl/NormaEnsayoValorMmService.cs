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
    public class NormaEnsayoValorMmService : INormaEnsayoValorMmService
    {

        protected INormaEnsayoValorMmRepository NormaEnsayoValorMmRepository { get; set; }

        public IEnumerable<NormaEnsayoValorMm> ReadNormaMm()
        {
            return NormaEnsayoValorMmRepository.ReadNormaMm();
        }

        public GridResult<NormaEnsayoValorMm> ReadNormaMm(GridSettings grid)
        {
            return NormaEnsayoValorMmRepository.ReadNormaMm(grid);
        }

        public NormaEnsayoValorMm ReadNormaMmById(long id)
        {
            return NormaEnsayoValorMmRepository.ReadNormaMmById(id);
        }

        public void CreateNormaMm(NormaEnsayoValorMm norma)
        {
            NormaEnsayoValorMmRepository.CreateNormaMm(norma);
        }

        public void UpdateNormaMm(NormaEnsayoValorMm norma)
        {
            NormaEnsayoValorMmRepository.UpdateNormaMm(norma);
        }

        public void DeleteNormaMm(NormaEnsayoValorMm norma)
        {
            NormaEnsayoValorMmRepository.DeleteNormaMm(norma);
        }

    }
}
