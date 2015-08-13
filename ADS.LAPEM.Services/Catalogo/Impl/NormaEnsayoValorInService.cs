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
    public class NormaEnsayoValorInService : INormaEnsayoValorInService
    {

        protected INormaEnsayoValorInRepository NormaEnsayoValorInRepository { get; set; }

        public IEnumerable<NormaEnsayoValorIn> ReadNormaIn()
        {
            return NormaEnsayoValorInRepository.ReadNormaIn();
        }

        public GridResult<NormaEnsayoValorIn> ReadNormaIn(GridSettings grid)
        {
            return NormaEnsayoValorInRepository.ReadNormaIn(grid);
        }

        public NormaEnsayoValorIn ReadNormaInById(long id)
        {
            return NormaEnsayoValorInRepository.ReadNormaInById(id);
        }

        public void CreateNormaIn(NormaEnsayoValorIn norma)
        {
            NormaEnsayoValorInRepository.CreateNormaIn(norma);
        }

        public void UpdateNormaIn(NormaEnsayoValorIn norma)
        {
            NormaEnsayoValorInRepository.UpdateNormaIn(norma);
        }

        public void DeleteNormaIn(NormaEnsayoValorIn norma)
        {
            NormaEnsayoValorInRepository.DeleteNormaIn(norma);
        }

    }
}
