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
    public class CalibracionRepository : GenericRepository<Calibracion>, ICalibracionRepository
    {
        public CalibracionRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Calibracion> ReadCalibracion()
        {
            return Get();
        }

        public GridResult<Calibracion> ReadCalibracion(GridSettings grid)
        {
            return Get(grid);
        }

        public Calibracion ReadCalibracionById(long id)
        {
            return GetById(id);
        }

        public void CreateCalibracion(Calibracion calibracion)
        {
            Add(calibracion);
        }

        public void UpdateCalibracion(Calibracion calibracion)
        {
            Edit(calibracion);
        }

        public void DeleteCalibracion(Calibracion calibracion)
        {
            Remove(calibracion);
        }
    }
}
