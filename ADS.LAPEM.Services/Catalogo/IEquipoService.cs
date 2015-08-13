using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IEquipoService
    {
        IEnumerable<Equipo> ReadEquipo();
        IEnumerable<Equipo> ReadEquipoByActivo(bool activo);
        GridResult<Equipo> ReadEquipo(GridSettings grid);        
        Equipo ReadEquipoById(long id);
        void CreateEquipo(Equipo equipo);
        void UpdateEquipo(Equipo equipo);
        void DeleteEquipo(Equipo equipo);
    }
}
