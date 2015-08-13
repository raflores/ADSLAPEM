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
    public class PlantaRepository : GenericRepository<Planta>, IPlantaRepository
    {
        public PlantaRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Planta> ReadPlanta()
        {
            return Get();
        }

        public GridResult<Planta> ReadPlanta(GridSettings grid)
        {
            return Get(grid);
        }

        public Planta ReadPlantaById(long id)
        {
            return GetById(id);
        }

        public void CreatePlanta(Planta planta)
        {
            Add(planta);
        }

        public void UpdatePlanta(Planta planta)
        {
            Edit(planta);
        }

        public void DeletePlanta(Planta planta)
        {
            Remove(planta);
        }
    }
}
