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
    public class EspecificacionRepository : GenericRepository<Especificacion>, IEspecificacionRepository
    {
        public EspecificacionRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Especificacion> ReadEspecificacion()
        {
            return Get();
        }

        public GridResult<Especificacion> ReadEspecificacion(GridSettings grid)
        {
            return Get(grid);
        }

        public Especificacion ReadEspecificacionById(long id)
        {
            return GetById(id);
        }

        public void CreateEspecificacion(Especificacion especificacion)
        {
            Add(especificacion);
        }

        public void UpdateEspecificacion(Especificacion especificacion)
        {
            Edit(especificacion);
        }

        public void DeleteEspecificacion(Especificacion especificacion)
        {
            Remove(especificacion);
        }
    }
}
