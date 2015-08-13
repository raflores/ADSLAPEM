using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IEquipoRepository
    {
        IQueryable<Equipo> ReadEquipo();
        IQueryable<Equipo> ReadEquipo(Expression<Func<Equipo, bool>> exp);
        GridResult<Equipo> ReadEquipo(GridSettings grid);
        Equipo ReadEquipoById(long id);
        void CreateEquipo(Equipo equipo);
        void UpdateEquipo(Equipo equipo);
        void DeleteEquipo(Equipo equipo);
    }
}
