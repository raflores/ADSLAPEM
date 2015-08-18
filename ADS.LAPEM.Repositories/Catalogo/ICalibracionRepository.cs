using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ICalibracionRepository
    {
        IQueryable<Calibracion> ReadCalibracion();
        GridResult<Calibracion> ReadCalibracion(GridSettings grid);
        Calibracion ReadCalibracionById(long id);
        void CreateCalibracion(Calibracion calibracion);
        void UpdateCalibracion(Calibracion calibracion);
        void DeleteCalibracion(Calibracion calibracion);
    }
}
