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
    public class NormaEnsayoService : INormaEnsayoService
    {
        protected INormaEnsayoRepository NormaEnsayoRepository { get; set; }
        protected INormaEnsayoValorInRepository NormaValorInRepository { get; set; }
        protected INormaEnsayoValorMmRepository NormaValorMmRepository { get; set; }

        public IEnumerable<NormaEnsayo> ReadNormaEnsayo()
        {
            return NormaEnsayoRepository.ReadNormaEnsayo();
        }

        public GridResult<NormaEnsayo> ReadNormaEnsayo(GridSettings grid)
        {            
            return NormaEnsayoRepository.ReadNormaEnsayo(grid);
        }

        public NormaEnsayo ReadNormaEnsayoById(long id)
        {
            return NormaEnsayoRepository.ReadNormaEnsayoById(id);
        }

        public void CreateNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            NormaEnsayoRepository.CreateNormaEnsayo(normaEnsayo);
        }

        public void UpdateNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            NormaEnsayoRepository.UpdateNormaEnsayo(normaEnsayo);
            //NormaEnsayoRepository.UpdateNormaEnsayo(normaEnsayo);
            //foreach (NormaEnsayoValorIn norma in normaEnsayo.NormasValorIn)
            //{
            //    norma.NormaEnsayoId = normaEnsayo.Id;
            //    NormaValorInRepository.UpdateNormaIn(norma);
            //}

            //foreach (NormaEnsayoValorMm norma in normaEnsayo.NormasValorMm)
            //{
            //    norma.NormaEnsayoId = normaEnsayo.Id;
            //    NormaValorMmRepository.UpdateNormaMm(norma);
            //}
        }

        public void DeleteNormaEnsayo(NormaEnsayo normaEnsayo)
        {
            NormaEnsayoRepository.DeleteNormaEnsayo(normaEnsayo);
        }

    }
}
