using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class TurnoRepository : GenericRepository<Turno>, ITurnoRepository
    {
        public TurnoRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Turno> ReadTurno()
        {
            return Get();
        }

        public GridResult<Turno> ReadTurno(GridSettings grid)
        {
            return Get(grid);
        }

        public Turno ReadTurnoById(long id)
        {
            return GetById(id);
        }

        public void CreateTurno(Turno turno)
        {
            Add(turno);
        }

        public void UpdateTurno(Turno turno)
        {
            Edit(turno);
        }

        public void DeleteTurno(Turno turno)
        {
            Remove(turno);
        }
    }
}
