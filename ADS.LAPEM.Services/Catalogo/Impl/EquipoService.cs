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
    public class EquipoService : IEquipoService
    {
        protected IEquipoRepository EquipoRepository { get; set; }

        public IEnumerable<Equipo> ReadEquipo()
        {
            return EquipoRepository.ReadEquipo();
        }

        public IEnumerable<Equipo> ReadEquipoByActivo(bool activo)
        {
            return EquipoRepository.ReadEquipo(x => x.Activo == activo);
        }

        public GridResult<Equipo> ReadEquipo(GridSettings grid)
        {
            return EquipoRepository.ReadEquipo(grid);
        }

        public Equipo ReadEquipoById(long id)
        {
            return EquipoRepository.ReadEquipoById(id);
        }

        public void CreateEquipo(Equipo equipo)
        {
            EquipoRepository.CreateEquipo(equipo);
        }

        public void UpdateEquipo(Equipo equipo)
        {
            EquipoRepository.UpdateEquipo(equipo);
        }

        public void DeleteEquipo(Equipo equipo)
        {
            EquipoRepository.DeleteEquipo(equipo);
        }
    }
}
