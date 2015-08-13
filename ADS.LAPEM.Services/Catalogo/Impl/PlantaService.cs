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
    public class PlantaService : IPlantaService
    {
        protected IPlantaRepository PlantaRepository { get; set; }

        public IEnumerable<Planta> ReadPlanta()
        {
            return PlantaRepository.ReadPlanta();
        }

        public GridResult<Planta> ReadPlanta(GridSettings grid)
        {
            return PlantaRepository.ReadPlanta(grid);
        }

        public Planta ReadPlantaById(long id)
        {
            return PlantaRepository.ReadPlantaById(id);
        }

        public void CreatePlanta(Planta planta)
        {
            PlantaRepository.CreatePlanta(planta);
        }
        
        public void UpdatePlanta(Planta planta)
        {
            PlantaRepository.UpdatePlanta(planta);
        }

        public void DeletePlanta(Planta planta)
        {
            PlantaRepository.DeletePlanta(planta);
        }
    }
}
