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
    public class TurnoService : ITurnoService
    {
        protected ITurnoRepository TurnoRepository { get; set; }

        public IEnumerable<Turno> ReadTurno()
        {
            return TurnoRepository.ReadTurno();
        }

        public GridResult<Turno> ReadTurno(GridSettings grid)
        {
            return TurnoRepository.ReadTurno(grid);
        }

        public Turno ReadTurnoById(long id)
        {
            return TurnoRepository.ReadTurnoById(id);
        }

        public void CreateTurno(Turno Turno)
        {
            TurnoRepository.CreateTurno(Turno);
        }

        public void UpdateTurno(Turno Turno)
        {
            TurnoRepository.UpdateTurno(Turno);
        }

        public void DeleteTurno(Turno Turno)
        {
            TurnoRepository.DeleteTurno(Turno);
        }
    }
}
