using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ISiloRepository
    {
        IQueryable<Silo> ReadSilo();
        GridResult<Silo> ReadSilo(GridSettings grid);
        Silo ReadSiloById(long id);
        void CreateSilo(Silo silo);
        void UpdateSilo(Silo silo);
        void DeleteSilo(Silo silo);
    }
}
