using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class EquipoRepository : GenericRepository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Equipo> ReadEquipo()
        {
            return Get();
        }

        public IQueryable<Equipo> ReadEquipo(Expression<Func<Equipo, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<Equipo> ReadEquipo(GridSettings grid)
        {
            return Get(grid);
        }

        public Equipo ReadEquipoById(long id)
        {
            return GetById(id);
        }

        public void CreateEquipo(Equipo equipo)
        {
            Add(equipo);
        }

        public void UpdateEquipo(Equipo equipo)
        {
            Edit(equipo);
        }

        public void DeleteEquipo(Equipo equipo)
        {
            Remove(equipo);
        }
    }
}
