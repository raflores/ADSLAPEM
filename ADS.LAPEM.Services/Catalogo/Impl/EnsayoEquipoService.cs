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
    public class EnsayoEquipoService : IEnsayoEquipoService
    {
        protected IEnsayoEquipoRepository EnsayoEquipoRepository { get; set; }

        public IEnumerable<EnsayoEquipo> ReadEnsayoEquipo()
        {
            return EnsayoEquipoRepository.ReadEnsayoEquipo();
        }

        public GridResult<EnsayoEquipo> ReadEnsayoEquipo(GridSettings grid)
        {
            return EnsayoEquipoRepository.ReadEnsayoEquipo(grid);
        }

        public EnsayoEquipo ReadEnsayoEquipoById(long id)
        {
            return EnsayoEquipoRepository.ReadEnsayoEquipoById(id);
        }

        public void CreateEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            EnsayoEquipoRepository.CreateEnsayoEquipo(ensayoEquipo);
        }

        public void UpdateEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            EnsayoEquipoRepository.UpdateEnsayoEquipo(ensayoEquipo);
        }

        public void DeleteEnsayoEquipo(EnsayoEquipo ensayoEquipo)
        {
            EnsayoEquipoRepository.DeleteEnsayoEquipo(ensayoEquipo);
        }
    }
}
