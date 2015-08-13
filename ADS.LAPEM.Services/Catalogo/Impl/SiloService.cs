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
    public class SiloService : ISiloService
    {
        protected ISiloRepository SiloRepository { get; set; }

        public IEnumerable<Silo> ReadSilo()
        {
            return SiloRepository.ReadSilo();
        }

        public GridResult<Silo> ReadSilo(GridSettings grid)
        {
            return SiloRepository.ReadSilo(grid);
        }

        public Silo ReadSiloById(long id)
        {
            return SiloRepository.ReadSiloById(id);
        }

        public void CreateSilo(Silo silo)
        {
            SiloRepository.CreateSilo(silo);
        }

        public void UpdateSilo(Silo silo)
        {
            SiloRepository.UpdateSilo(silo);
        }

        public void DeleteSilo(Silo silo)
        {
            SiloRepository.DeleteSilo(silo);
        }
    }
}
